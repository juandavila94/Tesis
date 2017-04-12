using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SplashFade : MonoBehaviour {

    public Image splashImage;
    public Text texto;

    IEnumerator Start()
    {
        splashImage.canvasRenderer.SetAlpha(0.0f);
        texto.canvasRenderer.SetAlpha(0.0f);
        FadeIn();
        yield return new WaitForSeconds(2.0f);
        FadeOut();
        yield return new WaitForSeconds(2.1f);
        SceneManager.LoadScene("Menu");
    }

    void FadeIn()
    {
        splashImage.CrossFadeAlpha(1.0f, 1.5f, false);
        texto.CrossFadeAlpha(1.0f, 1.5f, false);
    }

    void FadeOut()
    {
        splashImage.CrossFadeAlpha(0.0f, 2.5f, false);
        texto.CrossFadeAlpha(0.0f, 2.5f, false);
    }
}
