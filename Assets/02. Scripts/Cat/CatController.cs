using UnityEngine;
using Cat;

public class CatController : MonoBehaviour
{
    public SoundManager soundManager;
    
    private Rigidbody2D catRb;
    private Animator CatAnima;
    
    public float jumpPower = 10f;
    public bool isGround = false;
    public int jumpCount = 0;
    void Start()
    {
        catRb = GetComponent<Rigidbody2D>();
        CatAnima = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && jumpCount < 2)
        {
            CatAnima.SetTrigger("Jump");
            CatAnima.SetBool("isGround", false);
            catRb.AddForceY(jumpPower, ForceMode2D.Impulse);
            jumpCount++;
            
            soundManager.OnJumpSound();
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            CatAnima.SetBool("isGround", true);
            isGround = true;
            jumpCount = 0;
        }
    }

    void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isGround = false;
        }
    }
}
