using UnityEngine;
using UnityEngine.UI;

public class KnightContollerJoyStick : MonoBehaviour
{
    private Animator _animator;
    private Rigidbody2D _knightRb;

    [SerializeField] private Button jumpButton;
    [SerializeField] private Button attackButton;

    private Vector3 _inputDir;
    [SerializeField] private float moveSpeed = 3f;
    [SerializeField] private float jumpPower = 13f;

    // private float _atkDamage = 3f;

    private bool _isGround;
    private bool _isCombo;
    private bool _isAttack;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _knightRb = GetComponent<Rigidbody2D>();

        jumpButton.onClick.AddListener(Jump);
        attackButton.onClick.AddListener(Attack);
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void InputKeyBoard()
    {
        Jump();
        // SetAnimation();
    }

    public void InputJoystick(float x, float y)
    {
        _inputDir = new Vector3(x, y, 0).normalized;
        _animator.SetFloat("JoystickX", _inputDir.x);
        _animator.SetFloat("JoystickY", _inputDir.y);
    }

    private void Move()
    {
        if (_inputDir.x != 0)
        {
            var scaleX = _inputDir.x > 0 ? 1f : -1f;
            transform.localScale = new Vector3(scaleX, 1, 1);

            _knightRb.linearVelocity = _inputDir * moveSpeed;
        }
    }

    private void Jump()
    {
        if (_isGround)
        {
            _animator.SetTrigger("Jump");
            _knightRb.AddForceY(jumpPower, ForceMode2D.Impulse);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Monster")) Debug.Log("공격 확인");
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
        if (!_isAttack)
        {
            _isAttack = true;
            // _atkDamage = 3f;
            _animator.SetTrigger("Attack");
        }
        else
        {
            _isCombo = true;
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