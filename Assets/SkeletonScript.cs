using UnityEngine;
using System.Collections;

public class SkeletonScript : MonoBehaviour {

    protected Animator myAnimation;
    public float speed = 0.15f;
	// Use this for initialization
	void Start () {
        myAnimation = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        this.gameObject.transform.Translate(Vector3.forward * Time.deltaTime * speed);
	}
}
