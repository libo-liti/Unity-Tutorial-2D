using UnityEngine;
using UnityEngine.InputSystem.XR.Haptics;
using UnityEngine.UI;

public class KnightController_keyboard : MonoBehaviour, IDamageble
{
    private Animator _animator;
    private Rigidbody2D _knightRb;
    private Collider2D _knightCol;
    [SerializeField] private Image hpBar;

    private Vector3 _inputDir;
    
    [SerializeField] private float moveSpeed = 3f;
    [SerializeField] private float jumpPower = 13f;
    [SerializeField] private float dashPower = 5f;

    private bool _isGround;
    private bool _isCombo;
    private bool _isAttack;
    private bool _isLadder;
    private bool _isDash;
    private float _atkDamage = 4f;
    private float _hp = 30f;
    private float _curHp;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _knightRb = GetComponent<Rigidbody2D>();
        _knightCol = GetComponent<Collider2D>();

        _curHp = _hp;
        hpBar.fillAmount = _curHp / _hp;
    }

    private void Update()
    {
        InputKeyBoard();
        Jump();
        Attack();
        Dash();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void InputKeyBoard()
    {
        var h = Input.GetAxisRaw("Horizontal");
        var v = Input.GetAxisRaw("Vertical");

        _inputDir = new Vector3(h, v, 0).normalized;

        _animator.SetFloat("JoystickX", _inputDir.x);
        _animator.SetFloat("JoystickY", _inputDir.y);

        if (_inputDir.y < 0)
        {
            GetComponent<CapsuleCollider2D>().size = new Vector2(0.5f, 1.2f);
            GetComponent<CapsuleCollider2D>().offset = new Vector2(0, 0.6f);

        }
        else
        {
            GetComponent<CapsuleCollider2D>().size = new Vector2(0.5f, 1.7f);
            GetComponent<CapsuleCollider2D>().offset = new Vector2(0, 0.85f);
        }
    }

    private void Move()
    {
        if (_isDash)
            return;
        
        if (_inputDir.x != 0)
        {
            _knightRb.linearVelocityX = _inputDir.x * moveSpeed;
            var scaleX = _inputDir.x > 0 ? 1f : -1f;
            transform.localScale = new Vector3(scaleX, 1, 1);
        }
        else
            _knightRb.linearVelocityX = 0f;


        if (_isLadder && _inputDir.y != 0)
        {
            _knightRb.linearVelocityY = _inputDir.y + moveSpeed;
        }
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && _isGround)
        {
            _animator.SetTrigger("Jump");
            _knightRb.AddForceY(jumpPower, ForceMode2D.Impulse);
        }
    }

    private void Dash()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift) && !_isDash)
        {
            _isDash = true;
            float direction = transform.localScale.x;
            _knightRb.AddForceX(dashPower * direction, ForceMode2D.Impulse);
            Invoke("Dashing", 0.1f);
        }
    }

    private void Dashing()
    {
        _isDash = false;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            _animator.SetBool("isGround", true);
            _isGround = true;
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            _animator.SetBool("isGround", false);
            _isGround = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Monster"))
        {
            if (other.GetComponent<IDamageble>() != null)
            {
                other.GetComponent<IDamageble>().TakeDamage(_atkDamage);
                other.GetComponent<Animator>().SetTrigger("Hit");
            }
        }

        if (other.CompareTag("Ladder"))
        {
            _isLadder = true;
            _knightRb.gravityScale = 0f;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Ladder"))
        {
            _isLadder = false;
            _knightRb.gravityScale = 3f;
            _knightRb.linearVelocity = Vector2.zero;
        }
    }

    private void Attack()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            if (!_isAttack)
            {
                _isAttack = true;
                _atkDamage = 3f;
                _animator.SetTrigger("isAttack");
            }
            else
            {
                _isCombo = true;
            }
        }
    }

    public void CheckCombo()
    {
        if (_isCombo)
        {
            _animator.SetBool("isCombo", true);
            _atkDamage = 5f;
        }
        else
        {
            _isAttack = false;
            _animator.SetBool("isCombo", false);
        }
    }

    public void EndAttackCombo()
    {
        _isAttack = false;
        _isCombo = false;
    }

    public void TakeDamage(float damage)
    {
        _curHp -= damage;
        hpBar.fillAmount = _curHp / _hp;
        if (_curHp <= 0f)
        {
            Death();
        }
    }

    public void Death()
    {
        _animator.SetTrigger("Death");
        _knightCol.enabled = false;
        _knightRb.gravityScale = 0f;
    }
}