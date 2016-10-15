using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	/*public FirstPersonController playerPrefab;
	private FirstPersonController playerInstance;*/

	public OVRPlayerController playerPrefab;
	private OVRPlayerController playerInstance;

	public Maze mazePrefab;
	private Maze mazeInstance;

	// Use this for initialization
	void Start () {
		StartCoroutine(BeginGame ());
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Space)) {
			RestartGame ();
		}
	}

	private IEnumerator BeginGame() {
		mazeInstance = Instantiate (mazePrefab) as Maze;
		yield return StartCoroutine(mazeInstance.Generate ());
		playerInstance = Instantiate (playerPrefab) as OVRPlayerController;
		playerInstance.SetLocation (mazeInstance.GetCell (mazeInstance.RandomCoordinates));
	}

	private void RestartGame() {
		StopAllCoroutines ();
		Destroy (mazeInstance.gameObject);
		//BeginGame ();

		if (playerInstance != null) {
			Destroy (playerInstance.gameObject);
		}

		StartCoroutine (BeginGame ());
	}
}
