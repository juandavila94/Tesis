using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using System.Linq;

public class UIcontroller : MonoBehaviour {
    //preguntas
    public Pregunta[] preguntas;
    private static List<Pregunta> preguntasSinResponder;
    private Pregunta preguntaActual;
    public GameObject Jugador;
    [SerializeField]
    private Text textoOpcionA;
    [SerializeField]
    private Text textoOpcionB;
    [SerializeField]
    private Text textoOpcionC;
    [SerializeField]
    private Text textoPregunta;
    [SerializeField]
    private Image imagen;
    public float timerPregunta=10;
    [SerializeField]
    private Animator animador;
    [SerializeField]
    private Animator animador2;
    public bool preguntaRespondida;
    //

    public int HighscoreScore=0;
    public int Score;
    public Text score;
    public GameObject youdied;
    public GameObject panelPegunta;
    private int health = 3;
    public GameObject health1;
    public GameObject health2;
    public GameObject health3;
    public GameObject health4;
    public GameObject health5;
    public int Coins;
    public Text coins;
    public int Bank;
    public Text bank;

    public AudioClip MusicaPreguntas;
    public AudioClip RespuestaCorrecta;
    public AudioClip RespuestaIncorrecta;
    public AudioClip MusicaGamplay;
    public AudioClip MusicaMenu;
    private AudioSource Audio;
    // Use this for initialization
    void Start ()
    {
        Audio = GetComponent<AudioSource>();
        Bank = PlayerPrefs.GetInt("Bank", 0);
        health1.SetActive(false);
        health2.SetActive(false);
        health3.SetActive(false);
        health4.SetActive(false);
        health5.SetActive(false);
        panelPegunta.SetActive(false);
        youdied.SetActive(false);
        //Time.timeScale = 0.0f;
        HighscoreScore = PlayerPrefs.GetInt("Highscore",0);
        Audio.PlayOneShot(MusicaGamplay, 0.2f);
    }
	
	// Update is called once per frame
	void Update () {
       
            score.text = "Puntaje: " + Score;
            bank.text = "" ;
            coins.text = "Monedas: " + Coins;
            if (health == 5)
            {
                health1.SetActive(true);
                health2.SetActive(true);
                health3.SetActive(true);
                health4.SetActive(true);
                health5.SetActive(true);
            }
            if (health == 4)
            {
                health1.SetActive(true);
                health2.SetActive(true);
                health3.SetActive(true);
                health4.SetActive(true);
                health5.SetActive(false);
            }
            if (health == 3)
            {
                health1.SetActive(true);
                health2.SetActive(true);
                health3.SetActive(true);
                health4.SetActive(false);
                health5.SetActive(false);
            }
            if (health == 2)
            {
                health1.SetActive(true);
                health2.SetActive(true);
                health3.SetActive(false);
                health4.SetActive(false);
                health5.SetActive(false);
            }
            if (health == 1)
            {
                health1.SetActive(true);
                health2.SetActive(false);
                health3.SetActive(false);
                health4.SetActive(false);
                health5.SetActive(false);
            }
            if (health == 0)
            {
                health1.SetActive(false);
                health2.SetActive(false);
                health3.SetActive(false);
                health4.SetActive(false);
                health5.SetActive(false);
            }
            if (health <= 0)
            {
                
                youdied.SetActive(true);
                Time.timeScale = 0.0f;
                
            }
        }
    

    public void ScorePlus(int NewScore)
    {
        Score += NewScore;
        if (Score >= HighscoreScore)
        {
            HighscoreScore = Score;
            PlayerPrefs.SetInt("Highscore", HighscoreScore);
        }
    }

    public void CoinPlus(int newCoin)
    {
        Coins += newCoin;
        Bank += newCoin;
        PlayerPrefs.SetInt("Bank",Bank);
    }
    public void TakeDamage()
    {
        health--;
        // PlayerPrefs.DeleteAll();
    }

    public IEnumerator PresetarPregunta()
    {
        Player.esTrivia = true;
        preguntaRespondida = false;
        Audio.Stop();
        Audio.loop = true;
        Audio.clip = MusicaPreguntas;
        Audio.Play();
        Jugador = GameObject.FindGameObjectWithTag("Player");
        Time.timeScale = 0.0f;
        Jugador.layer = 4;
        if (preguntasSinResponder == null || preguntasSinResponder.Count == 0)
        {
            preguntasSinResponder = preguntas.ToList<Pregunta>();
        }
        int randomId = Random.Range(0, preguntasSinResponder.Count);
        preguntaActual = preguntasSinResponder[randomId];
        textoPregunta.text = preguntaActual.pregunta;
        textoOpcionA.text = preguntaActual.opcionA;
        textoOpcionB.text = preguntaActual.opcionB;
        textoOpcionC.text = preguntaActual.opcionC;
        imagen.sprite = preguntaActual.sprite;
        panelPegunta.SetActive(true);
        preguntasSinResponder.Remove(preguntaActual);

        yield return StartCoroutine(CoroutineUtil.WaitForRealSeconds(10));
        if (preguntaRespondida == false)
        {
            Time.timeScale = 1.0f;
            Audio.Stop();
            Audio.PlayOneShot(RespuestaIncorrecta, 0.2f);
            panelPegunta.SetActive(false);
            Audio.PlayOneShot(MusicaGamplay, 0.2f);
            Player.esTrivia = false;
        }
    }
    IEnumerator Example()
    {
       
        yield return new WaitForSecondsRealtime(5);
        
    }
    public void ClickedRestart()
    {
        Time.timeScale = 1f;
        health = 3;
        Application.LoadLevel("Menu");
    }

    public void SeleccionaA()
    {
    
        Audio.Stop();
        if (preguntaActual.respuesta.Equals("a"))
        {
            if (health == 5)
            {
                ScorePlus(5);
                Audio.PlayOneShot(RespuestaCorrecta, 0.2f);
            }
            else
            {
                health++;
                Audio.PlayOneShot(RespuestaCorrecta, 0.2f);
            }
        }
        else {
            Audio.PlayOneShot(RespuestaIncorrecta, 0.2f);
        }
        panelPegunta.SetActive(false);
        Time.timeScale = 1.0f;
        Audio.PlayOneShot(MusicaGamplay, 0.2f);
        preguntaRespondida = true;
        Player.esTrivia = false;
    }


    public void SeleccionaB()
    {
     
        Audio.Stop();
        if (preguntaActual.respuesta.Equals("b"))
        {
            if (health == 5)
            {
                ScorePlus(5);
                Audio.PlayOneShot(RespuestaCorrecta, 0.2f);
            }
            else
            {
                health++;
                Audio.PlayOneShot(RespuestaCorrecta, 0.2f);
            }
        }
        else
        {
            Audio.PlayOneShot(RespuestaIncorrecta, 0.2f);
        }
        panelPegunta.SetActive(false);
        Time.timeScale = 1.0f;
        Audio.PlayOneShot(MusicaGamplay, 0.2f);
        preguntaRespondida = true;
        Player.esTrivia = false;
    }

    public void SeleccionaC()
    {
      
        Audio.Stop();
        if (preguntaActual.respuesta.Equals("c"))
        {
            if (health == 5)
            {
                ScorePlus(5);
                Audio.PlayOneShot(RespuestaCorrecta, 0.2f);
            }
            else
            {
                Audio.PlayOneShot(RespuestaCorrecta, 0.2f);
                health++;
            }
        }
        else
        {
            Audio.PlayOneShot(RespuestaIncorrecta, 0.2f);
        }
        panelPegunta.SetActive(false);
        Time.timeScale = 1.0f;
        Audio.PlayOneShot(MusicaGamplay, 0.2f);
        preguntaRespondida = true;
        Player.esTrivia = false;
    }

}



public static class CoroutineUtil
{
    public static IEnumerator WaitForRealSeconds(float time)
    {

        float start = Time.realtimeSinceStartup;
        while (Time.realtimeSinceStartup < start + time)
        {
            yield return null; 
        }
   
    }
}