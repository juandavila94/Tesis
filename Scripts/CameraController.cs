using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

    public GameObject Player;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        transform.position = new Vector3(Player.transform.position.x + 2, 0, 0);
       
	}
}
