using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public Pregunta[] preguntas;
    private static List<Pregunta> preguntasSinResponder;
    private Pregunta preguntaActual;
    [SerializeField]
    private Text textoPregunta;
    [SerializeField]
    private Text respuestaA;
    [SerializeField]
    private Text respuestaB;
    [SerializeField]
    private Text respuestaC;
    [SerializeField]
    private Image imagen;

    [SerializeField]
    private Animator animador;

    [SerializeField]
    private float tiempoEntrePreguntas = 1f;

    [SerializeField]
    private Text textoOpcionA;
    [SerializeField]
    private Text textoOpcionB;
    [SerializeField]
    private Text textoOpcionC;

    public string loadLevel;
    [SerializeField]
    public static int contador = 4;
    private void Start()
    {
        if (preguntasSinResponder == null || preguntasSinResponder.Count == 0)
        {
            preguntasSinResponder = preguntas.ToList<Pregunta>();
        }
        if (contador >= 0)
        {
            FijarPreguntaAleatorio();
        }
        else
        {
            contador = 4;
            SceneManager.LoadScene("Main");
           
        }
    }

    private void FijarPreguntaAleatorio()
    {
        int randomId = Random.Range(0, preguntasSinResponder.Count);
        preguntaActual = preguntasSinResponder[randomId];
        textoPregunta.text = preguntaActual.pregunta;
        textoOpcionA.text = preguntaActual.opcionA;
        textoOpcionB.text = preguntaActual.opcionB;
        textoOpcionC.text = preguntaActual.opcionC;
        imagen.sprite= preguntaActual.sprite;

        if (preguntaActual.respuesta.Equals("a"))
        {
            respuestaA.text = "CORRECTO";
            respuestaA.color = Color.green; 
            respuestaB.text = "INCORRECTO";
            respuestaB.color = Color.red;
            respuestaC.text = "INCORRECTO";
            respuestaC.color = Color.red;
        }
        if (preguntaActual.respuesta.Equals("b"))
        {
            respuestaA.text = "INCORRECTO";
            respuestaA.color = Color.red;
            respuestaB.text = "CORRECTO";
            respuestaB.color = Color.green;
            respuestaC.text = "INCORRECTO";
            respuestaC.color = Color.red;
        }
        if (preguntaActual.respuesta.Equals("c"))
        {
            respuestaA.text = "INCORRECTO";
            respuestaA.color = Color.red;
            respuestaB.text = "INCORRECTO";
            respuestaB.color = Color.red;
            respuestaC.text = "CORRECTO";
            respuestaC.color = Color.green;
        }
        contador--;
    }

    IEnumerator TransicionSiguientePregunta()
    {
        preguntasSinResponder.Remove(preguntaActual);
        yield return new WaitForSeconds(tiempoEntrePreguntas);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);     
    }


    public void SeleccionaA()
    {
        animador.SetTrigger("a");
        if (preguntaActual.respuesta.Equals("a"))
        {
            Debug.Log("Bien");
        }
        else
        {
            Debug.Log("Mal");
        }

        StartCoroutine(TransicionSiguientePregunta());
    }


    public void SeleccionaB()
    {
        animador.SetTrigger("b");
        if (preguntaActual.respuesta.Equals("b"))
        {
            Debug.Log("Bien");
        }
        else
        {
            Debug.Log("Mal");
        }

        StartCoroutine(TransicionSiguientePregunta());
    }

    public void SeleccionaC()
    {
        animador.SetTrigger("c");
        if (preguntaActual.respuesta.Equals("c"))
        {
            Debug.Log("Bien");
        }
        else
        {
            Debug.Log("Mal");
        }

        StartCoroutine(TransicionSiguientePregunta());
    }
}