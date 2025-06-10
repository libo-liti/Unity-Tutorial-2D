using System;
using UnityEngine;
using Cat;
using UnityEditor;
using UnityEngine.Video;

public class CatController : MonoBehaviour
{
    public GameObject happyVideo;
    public GameObject sadVideo;
    
    public SoundManager soundManager;

    public GameObject gameOverUI;
    public GameObject fadeUI;
    
    private Rigidbody2D catRb;
    private Animator CatAnima;

    public float limitPower = 9f;
    public float jumpPower = 10f;
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
                
                Invoke("HappyVideo", 5f);
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
            Invoke("SadVideo", 5f);

        }        
        if (other.gameObject.CompareTag("Ground"))
        {
            CatAnima.SetBool("isGround", true);
            jumpCount = 0;
        }
    }

    private void HappyVideo()
    {
        happyVideo.SetActive(true);
        fadeUI.SetActive(false);
        gameOverUI.SetActive(false);
        soundManager.audioSource.mute = true;
    }
    private void SadVideo()
    {
        sadVideo.SetActive(true);
        fadeUI.SetActive(false);
        gameOverUI.SetActive(false);
        soundManager.audioSource.mute = true;
    }
}
