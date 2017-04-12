using UnityEngine;
using System.Collections;


public class BlockDelete : MonoBehaviour {

    private float waitTime = 3.0f;
    public GameObject UI;
    void OnTriggerExit2D(Collider2D other)
    {
        StartCoroutine(delete());
        UI = GameObject.FindGameObjectWithTag("UI");
        UI.GetComponent<UIcontroller>().ScorePlus(1);
    }


    IEnumerator delete()
    {
        yield return new WaitForSeconds(waitTime);
        Destroy(gameObject);

    }
	
}
