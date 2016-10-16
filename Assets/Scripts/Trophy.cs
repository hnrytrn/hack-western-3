using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Trophy : MonoBehaviour {
	
	public Text winText;
	public AudioSource winSound;
	private MazeCell currentCell;

	public void SetLocation (MazeCell cell) {
		currentCell = cell;
		transform.localPosition = cell.transform.localPosition;
	}

	void OnCollisionEnter(Collision collision) {
		if (collision.gameObject.tag == "Player") {
			winSound.Play ();
			winText.text = "You win!";
		}
	}
}
