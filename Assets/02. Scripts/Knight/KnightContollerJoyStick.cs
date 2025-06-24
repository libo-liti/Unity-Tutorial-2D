using UnityEngine;
using UnityEngine.UIElements;
using Button = UnityEngine.UI.Button;

public class KnightContollerJoyStick : MonoBehaviour
{
    private Animator _animator;
    private Rigidbody2D _knightRb;

    [SerializeField] private Button jumpButton;
    [SerializeField] private Button attackButton;
    
    private Vector3 _inputDir;
    [SerializeField] private float moveSpeed = 3f;
    [SerializeField] private float jumpPower = 13f;

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

    void InputKeyBoard()
    {
        Jump();
        // SetAnimation();
    }

    public void InputJoystick(float x, float y)
    {
        _inputDir = new Vector3(x, y, 0).normalized;
        _animator.SetFloat("JoystickX", _inputDir.x);
        _animator.SetFloat("JoystickY", _inputDir.y);
        
        if (_inputDir.x != 0)
        {
            var scaleX = _inputDir.x > 0 ? 1f : -1f;
            transform.localScale = new Vector3(scaleX, 1, 1);
        }
    }
    void Move()
    {
        if (_inputDir.x != 0)
            _knightRb.linearVelocityX = _inputDir.x * moveSpeed;
    }

    void Jump()
    {
        if (_isGround)
        {
            _animator.SetTrigger("Jump");
            _knightRb.AddForceY(jumpPower, ForceMode2D.Impulse);
            Debug.Log("점프");
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
            Debug.Log("Exit");
        }
    }
    void Attack()
    {
        _isCombo = false;
        if (!_isAttack)
        {
            _isAttack = true;
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
            _animator.SetBool("isCombo", true);
        else
        {
            _animator.SetBool("isCombo", false);
        }
        _isAttack = false;
    }
}
