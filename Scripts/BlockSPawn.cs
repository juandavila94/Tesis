using UnityEngine;
using System.Collections;

public class BlockSPawn : MonoBehaviour {

    public GameObject[] Blocks;
    public Transform BlockSpawnerPos;
    public int BlockCount=0;
    public float NewPos=5.0f;

    private int randomNum;
    private float waitTime = 0.5f;
    private GameObject block;
    
	// Use this for initialization
	void Start () {
        Block();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void Block()
    {
        block = Instantiate (Blocks[Random.Range(0, 5)], BlockSpawnerPos.position,Quaternion.identity) as GameObject;
        Vector3 temp = BlockSpawnerPos.position;
        temp.y = 0;
        temp.x += 5;
        temp.z = 0;
        BlockSpawnerPos.position = temp;
        StartCoroutine(wait());
    }
    
    IEnumerator wait()
    {
        yield return new WaitForSeconds(waitTime);
        BlockCount += 1;
        Block();
    }
}
