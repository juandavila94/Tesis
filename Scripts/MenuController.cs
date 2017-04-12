using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public GameObject MainMenu;
    public Text HIGHSCORE;
    public int HighscoreScore = 0;
    public AudioClip MusicaMenu;
    private AudioSource Audio;

    //twitter
    public string mensaje = "Crees que puedes superar mi puntaje  en este juego ? ";
    public string twitterDescriptionParam = "";
    private const string TWITTER_ADDRESS = "http://twitter.com/intent/tweet";
    private const string TWITTER_LANGUAGE = "es";
    public string APP_STORE_LINK_ANDROID = "https://play.google.com/store/apps/details?id=com.Company.Tesisbeta2";
    // Use this for initialization
    void Start()
    { 
        Audio = GetComponent<AudioSource>();
        MainMenu.SetActive(true);
        //Time.timeScale = 0.0f;
        HighscoreScore = PlayerPrefs.GetInt("Highscore", 0);
        Audio.loop = true;
        Audio.clip = MusicaMenu;
        Audio.Play();

    }

    // Update is called once per frame
    void Update()
    {
        HIGHSCORE.text = "Puntaje mas alto " + HighscoreScore;
        //Time.timeScale = 0.0f;
    }

    public void ClickedStart()
    {
        //Time.timeScale = 1.0f;
        Audio.Stop();
        SceneManager.LoadScene("Main");  
    }

    public void ClickedQuit()
    {
        Application.Quit();
    }

    public void ClickedTwitter()
    {
        Application.OpenURL(TWITTER_ADDRESS + "?text=" + WWW.EscapeURL(mensaje + "\n" +
            HighscoreScore+"\n" + "Descárgalo en la tienda de Google: " + APP_STORE_LINK_ANDROID));
    }
    public void ClickedFacebook()
    {

    }

  


}
