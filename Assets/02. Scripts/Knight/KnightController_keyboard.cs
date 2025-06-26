using UnityEngine;

public class KnightController_keyboard : MonoBehaviour
{
    private Animator _animator;
    private Rigidbody2D _knightRb;

    private Vector3 _inputDir;
    [SerializeField] private float moveSpeed = 3f;
    [SerializeField] private float jumpPower = 13f;

    private bool _isGround;
    private bool _isCombo;
    private bool _isAttack;
    // private float _atkDamage = 3f;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _knightRb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        InputKeyBoard();
        Jump();
        Attack();
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
    }

    private void Move()
    {
        if (_inputDir.x != 0)
        {
            _knightRb.linearVelocityX = _inputDir.x * moveSpeed;
            var scaleX = _inputDir.x > 0 ? 1f : -1f;
            transform.localScale = new Vector3(scaleX, 1, 1);
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

    private void Attack()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            if (!_isAttack)
            {
                _isAttack = true;
                // _atkDamage = 3f;
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
            // _atkDamage = 5f;
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
}