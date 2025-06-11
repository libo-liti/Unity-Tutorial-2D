using System.Collections;
using UnityEngine;
using Cat;
using UnityEngine.Video;

public class CatController : MonoBehaviour
{
    public SoundManager soundManager;
    public VideoManager videoManager;

    public GameObject gameOverUI;
    public GameObject fadeUI;
    
    private Rigidbody2D catRb;
    private Animator CatAnima;

    public float limitPower;
    public float jumpPower;
    public int jumpCount = 0;
    void Start()
    {
        catRb = GetComponent<Rigidbody2D>();
        CatAnima = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && jumpCount < 5)
        {
            CatAnima.SetTrigger("Jump");
            CatAnima.SetBool("isGround", false);
            catRb.AddForceY(jumpPower, ForceMode2D.Impulse);
            jumpCount++;
            
            soundManager.OnJumpSound();

            if (catRb.linearVelocityY > limitPower)
                catRb.linearVelocityY = limitPower;

        }
        var catRotation = transform.eulerAngles;
        catRotation.z = catRb.linearVelocityY * 2.5f;
        transform.eulerAngles = catRotation;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag(("Apple")))
        {
            other.gameObject.SetActive(false);
            other.transform.parent.GetComponent<ItemEvent>().particle.SetActive(true);

            GameManager.score++;

            if (GameManager.score == 10)
            {
                fadeUI.SetActive(true);
                fadeUI.GetComponent<FadePanel>().OnFade(3f, Color.white);

                this.GetComponent<CircleCollider2D>().enabled = false;

                StartCoroutine(EndingRoutine(true));
            }
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Pipe"))
        {
            soundManager.OnColliderSound();
            gameOverUI.SetActive(true);
            fadeUI.SetActive(true);
            fadeUI.GetComponent<FadePanel>().OnFade(3f, Color.black);
            
            this.GetComponent<CircleCollider2D>().enabled = false;
            StartCoroutine(EndingRoutine(false));
        }        
        if (other.gameObject.CompareTag("Ground"))
        {
            CatAnima.SetBool("isGround", true);
            jumpCount = 0;
        }
    }

    IEnumerator EndingRoutine(bool isHappy)
    {
        yield return new WaitForSeconds(3.5f);
        videoManager.VideoPlay(isHappy);
        yield return new WaitUntil(() => videoManager.vPlayer.isPlaying);
        
        fadeUI.SetActive(false);
        gameOverUI.SetActive(false);
        soundManager.audioSource.mute = true;
    }
    private void HappyVideo()
    {
        videoManager.VideoPlay(true);
        fadeUI.SetActive(false);
        gameOverUI.SetActive(false);
        soundManager.audioSource.mute = true;
    }
    private void SadVideo()
    {
        videoManager.VideoPlay(false);
        fadeUI.SetActive(false);
        gameOverUI.SetActive(false);
        soundManager.audioSource.mute = true;
    }
}
