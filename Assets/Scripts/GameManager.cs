using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	/*public FirstPersonController playerPrefab;
	private FirstPersonController playerInstance;*/

	public OVRPlayerController playerPrefab;
	private OVRPlayerController playerInstance;

	public Trophy trophyPrefab;
	private Trophy trophyInstance;

	public Spawner [] scaryPrefab;
	private Spawner [] scaryInstance;

	public Maze mazePrefab;
	private Maze mazeInstance;

	// Use this for initialization
	void Start () {
		StartCoroutine(BeginGame ());
		scaryInstance = scaryPrefab;
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
		SpawnHorror (30);
		playerInstance = Instantiate (playerPrefab) as OVRPlayerController;
		playerInstance.SetLocation (mazeInstance.GetCell (new IntVector2 (0, 19)));
		trophyInstance = Instantiate (trophyPrefab) as Trophy;
		trophyInstance.SetLocation (mazeInstance.GetCell (new IntVector2 (19, 0)));
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

	private void SpawnHorror(int limit){
		for (int i = 0; i < limit; i++) {
			int index = Random.Range (0, scaryPrefab.Length);
			scaryInstance[index] = Instantiate (scaryPrefab[index]) as Spawner;
			scaryInstance[index].SetLocation (mazeInstance.GetCell (mazeInstance.RandomCoordinates));
		}
	}
}
