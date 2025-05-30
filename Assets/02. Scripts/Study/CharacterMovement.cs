using System;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    private Camera _mainCam;
    
    private Rigidbody2D _characterRb;
    public SpriteRenderer[] renderers;
    
    private float _direct;
    private float _dashTimer = 0f;
    public float dashDuration;
    public float moveSpeed;
    public float jumpPower;
    public float dashPower;
    
    private int _jumpCount = 0;

    private bool _isGround = true;
    private bool _isDash;
    
    private void Awake()
    {
        _mainCam = Camera.main;
        _characterRb = GetComponent<Rigidbody2D>();
        renderers = GetComponentsInChildren<SpriteRenderer>(true);
    }
    private void Update()
    {
        _direct = Input.GetAxisRaw("Horizontal");
        Jump();
        Dash();

        // 대쉬를 짧게 하기 위한 시간 계산
        if (_isDash)
        {
            _dashTimer += Time.deltaTime;
            if (_dashTimer >= dashDuration)
            {
                _characterRb.linearVelocityX = 0;
                _dashTimer = 0;
                _isDash = false;
            }
        }

        // 카메라 움직임
        _mainCam.transform.position =
            new Vector3(Mathf.Lerp(_mainCam.transform.position.x, transform.position.x, 0.1f), 1, -10f);
    }

    private void FixedUpdate()
    {
        Move();
    }

    /// <summary>
    /// 캐릭터 움직임에 따라 이미지의 Flip 상태가 변하는 코드
    /// </summary>
    private void Move()
    {
        if (_isDash)
            return;
        
        // 움직일때
        if (_direct != 0)
        {
            renderers[0].gameObject.SetActive(false);
            renderers[1].gameObject.SetActive(true && _isGround);
            
            _characterRb.linearVelocityX = _direct * moveSpeed;

            if (_direct > 0)
                CharacterFlip(renderers, false);
            else if (_direct < 0)
                CharacterFlip(renderers, true);
        }// 멈춰 있을때
        else if(_direct == 0)
        {
            if (!_isDash)
                _characterRb.linearVelocityX = 0;
            
            renderers[0].gameObject.SetActive(true && _isGround);
            renderers[1].gameObject.SetActive(false);
        }
    }

    private void Jump()
    {
        if (Input.GetButtonDown("Jump") && _jumpCount < 2)
        {
            _jumpCount++;
            _characterRb.AddForceY(jumpPower, ForceMode2D.Impulse);
        }
    }

    private void Dash()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            _isDash = true;
            
            if (renderers[0].flipX)
                _characterRb.AddForceX(-dashPower, ForceMode2D.Impulse);
            else
                _characterRb.AddForceX(dashPower, ForceMode2D.Impulse);
        }
    }

    void CharacterFlip(SpriteRenderer[] spriteRenderers, bool flag)
    {
        foreach (var sprite in spriteRenderers)
            sprite.flipX = flag;
    }
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            _jumpCount = 0;
            _isGround = true;
            
            renderers[2].gameObject.SetActive(false);
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            _isGround = false;
            
            renderers[0].gameObject.SetActive(false);
            renderers[1].gameObject.SetActive(false);
            renderers[2].gameObject.SetActive(true);
        }
    }
}
