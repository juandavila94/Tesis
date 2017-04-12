using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Player : MonoBehaviour {


    public float power = 500;
    public int  jumpHeight = 1000;
    public bool isFalling = false;
    public GameObject UI;
    public GameObject blood;
    public GameObject Jugador;
    public AudioClip HitSound;
    public AudioClip JumpSound;
    private AudioSource Audio;

    public int Highscore;
    private bool canDoubleJump;
    private bool jumpOne;
    private bool jumpTwo;

    public Animator anim;
    public Animation animacionSaltar;
    public static bool esTrivia = false;
    void Start()
    {
        Audio = GetComponent<AudioSource>();
        anim = GetComponent<Animator>();
        Highscore = PlayerPrefs.GetInt("Highscore", 0);
        jumpOne = false;
        jumpTwo = false;
        canDoubleJump = false;
    }

    void Update()
    {
     
      
        if (Input.GetKeyDown(KeyCode.Space) && isFalling == false || Input.GetTouch(0).phase == TouchPhase.Began && isFalling == false )
        {

            anim.Play("Jump_01");
            Audio.PlayOneShot(JumpSound, 0.2f);
            jumpOne = true;
            canDoubleJump = true;
            isFalling = true;
      
        }
        if (Input.GetKeyDown(KeyCode.Space) && isFalling == true && canDoubleJump == true && esTrivia == false 
            || Input.GetTouch(0).phase == TouchPhase.Began && isFalling == true && canDoubleJump == true && esTrivia == false)
        {
            anim.Play("Jump_01");
            jumpTwo = true;
            canDoubleJump = false;
            isFalling = true;
            
        }

       
    }

    void FixedUpdate()
    {
        transform.Translate(Vector2.right * power * Time.deltaTime);
        if (jumpOne == true)
        {
            GetComponent<Rigidbody2D>().AddForce(Vector2.up * jumpHeight);
            jumpOne = false;
        }
        if (jumpTwo == true)
        {
            GetComponent<Rigidbody2D>().AddForce(Vector2.up * jumpHeight);
            jumpTwo = false;
        }

    
    }

    void OnCollisionStay2D(Collision2D coll)
    {
        if(coll.gameObject.tag == "Ground")
        {
            isFalling = false;
            canDoubleJump = false;
            anim.Play("Run_02");
        }
        if (coll.gameObject.tag == "Ground"&& Input.GetKeyDown(KeyCode.Space))
        {
            
            anim.Play("Jump_01");
        }
    }
   

    void OnTriggerEnter2D(Collider2D coll)
    {
        if(coll.gameObject.tag=="Death")
        {
            UI = GameObject.FindGameObjectWithTag("UI");
            UI.GetComponent<UIcontroller>().TakeDamage();
            Blood();
            Audio.PlayOneShot(HitSound, 0.2f);
            
        }

        if (coll.gameObject.tag == "Pregunta")
        {
            canDoubleJump = false;
            Jugador = GameObject.FindGameObjectWithTag("Player");
            UI = GameObject.FindGameObjectWithTag("UI");
            StartCoroutine(UI.GetComponent<UIcontroller>().PresetarPregunta());
            //Destroy(UI);
        }
    }

    void Blood()
    {
        GameObject childObject = Instantiate(blood) as GameObject;
        childObject.transform.SetParent(this.transform, false);
        Destroy(childObject,2);
    }
}
