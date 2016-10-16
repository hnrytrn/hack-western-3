using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {

	private MazeCell currentCell;
	private GameObject player;


    // Use this for initialization
    void Start () {
        player = GameObject.FindGameObjectWithTag("player1").gameObject;


    }

	// Update is called once per frame
	void Update () {

        Vector3 lookAtPosition = player.transform.position;
        lookAtPosition.y = transform.position.y;
        this.gameObject.transform.LookAt(lookAtPosition);
	}

	void FixedUpdate(){
	}

	public void SetLocation (MazeCell cell) {

        
        currentCell = cell;
        transform.localPosition = cell.transform.localPosition;
     
        //transform.localPosition.Set (transform.localPosition.x, transform.localPosition.y, transform.localPosition.z + 0.4f);
    }
}
