using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {

	private MazeCell currentCell;
	private Transform target;
	public FirstPersonController player;


	// Use this for initialization
	void Start () {
		target = player.transform;
	}
	
	// Update is called once per frame
	void Update () {
		//this.transform.LookAt (target);
	}

	void FixedUpdate(){
		this.transform.LookAt (target);
	}

	public void SetLocation (MazeCell cell) {
		currentCell = cell;
		transform.localPosition = cell.transform.localPosition;
		transform.localPosition.Set (transform.localPosition.x + 0.4f, transform.localPosition.y, transform.localPosition.z + 0.4f);
	}
}
