using UnityEngine;
using UnityEngine.Audio;
using System.Collections;

public class AudioManager : MonoBehaviour {

	public AudioSource sfx;
	public AudioSource sfx2;
	public AudioClip[] soundtrack;
	public AudioClip[] monsterSounds;


		// Use this for initialization
		void Start ()
		{
		
		/*soundtrack1 = new AudioClip[] {(AudioClip)Resources.Load ("Sound/soundeffect1.mp3"), 
			(AudioClip)Resources.Load ("Sound/soundeffect2.mp3"),
			(AudioClip)Resources.Load ("Sound/soundeffect3.mp3"),
			(AudioClip)Resources.Load ("Sound/soundeffect4.mp3"),
			(AudioClip)Resources.Load ("Sound/soundeffect5.mp3"),
			(AudioClip)Resources.Load ("Sound/soundeffect6.mp3"),
			(AudioClip)Resources.Load ("Sound/soundeffect7.mp3"),
			(AudioClip)Resources.Load ("Sound/soundeffect8.mp3"),
			(AudioClip)Resources.Load ("Sound/soundeffect9.mp3"),
			(AudioClip)Resources.Load ("Sound/soundeffect10.mp3"),
		};*/
					
		}

		// Update is called once per frame
		void Update ()
		{
		if (sfx.isPlaying==false)
			{
				sfx.clip = soundtrack[Random.Range(0, soundtrack.Length)];
				sfx.Play(44100*3);
			}
	
		if (sfx2.isPlaying==false)
	{
		sfx2.clip = soundtrack[Random.Range(0, soundtrack.Length)];
		sfx2.Play(44100*10);
	}
}

}
