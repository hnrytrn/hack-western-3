using UnityEngine;
using System.Collections;

public class ZombieScript : MonoBehaviour {

    protected Animator myAnimation;
    public float speed = 3.0f;

	// Use this for initialization
	void Start () {
        myAnimation = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        this.gameObject.transform.Translate(Vector3.forward * Time.deltaTime * speed);
	}
}
