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
    public float bedUp;
    public float z1Up;
    public float z2Up;
    public float sUp;



    // Use this for initialization
    void Start () {
		StartCoroutine(BeginGame ());
		scaryInstance = scaryPrefab;


       


    }

    // Update is called once per frame
    void Update () {
		if (Input.GetKeyDown ("joystick button 3")) {
			RestartGame ();
		}

        if (Input.GetKeyDown("joystick button 1"))
        {
            Attack();
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


        Vector3 temp;
        var beds = GameObject.FindGameObjectsWithTag("bed");
        var m1s = GameObject.FindGameObjectsWithTag("m1");
        var m2s = GameObject.FindGameObjectsWithTag("m2");
        var m3s = GameObject.FindGameObjectsWithTag("m3");

        foreach (GameObject bed in beds)
        {
            temp = bed.transform.position;
            temp.y = temp.y + bedUp;
            bed.transform.position = temp;
        }

        foreach (GameObject m1 in m1s)
        {
            temp = m1.transform.position;
            temp.y = temp.y + z1Up;
            m1.transform.position = temp;
        }
        foreach (GameObject m2 in m2s)
        {
            temp = m2.transform.position;
            temp.y = temp.y + z2Up;
            m2.transform.position = temp;
        }
        foreach (GameObject m3 in m3s)
        {
            temp = m3.transform.position;
            temp.y = temp.y + sUp;
            m3.transform.position = temp;
        }

    }


    void Attack()
    {
       

    }
}
