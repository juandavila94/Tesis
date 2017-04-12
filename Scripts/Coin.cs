using UnityEngine;
using System.Collections;

public class Coin : MonoBehaviour {


    public AudioClip CoinSound;
    private AudioSource Audio;
	// Use this for initialization
	void Start ()
    {
        Audio = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update ()
    {

        GameObject P = GameObject.FindGameObjectWithTag("Player");
        GameObject[] CurrentCoins = GameObject.FindGameObjectsWithTag("Coin");

        foreach(GameObject Coin in CurrentCoins)
        {
            if (Vector3.Distance(Coin.transform.position, P.transform.position) < 0.5)
            {
                Destroy(Coin.gameObject);
                Audio.PlayOneShot(CoinSound, 0.2f);
                GameObject UI = GameObject.FindGameObjectWithTag("UI");
                UI.GetComponent<UIcontroller>().CoinPlus(1);
            }

        }
    }
}
