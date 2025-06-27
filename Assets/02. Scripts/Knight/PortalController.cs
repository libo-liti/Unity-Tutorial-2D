using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PortalController : MonoBehaviour
{
    public FadePanel fade;
    public GameObject portalEffect;
    public GameObject loadingImage;

    public Image progressBar;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(PortalRoutine());
        }
    }

    private IEnumerator PortalRoutine()
    {
        portalEffect.SetActive(true);
        yield return StartCoroutine(fade.Fade(3f, Color.white, true));
        
        loadingImage.SetActive(true);
        yield return StartCoroutine(fade.Fade(3f, Color.white, false));

        while (progressBar.fillAmount < 1f)
        {
            progressBar.fillAmount += Time.deltaTime * 0.3f;
            yield return null;
        }

        SceneManager.LoadScene(1);
    }
}
