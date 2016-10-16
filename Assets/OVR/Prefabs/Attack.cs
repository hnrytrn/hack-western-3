using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Attack : MonoBehaviour
{

    private GameObject m1;
    private GameObject m2;
    private GameObject m3;
    private GameObject toKill;
    private AudioSource diez;
    private AudioSource dies;

    // Use this for initialization
    void Start()
    {
        diez = GameObject.Find("dead").GetComponent< AudioSource >();
        dies = GameObject.Find("deads").GetComponent<AudioSource>();

        GameObject.FindGameObjectWithTag("player1").transform.Rotate(Vector3.up, 180f);
    }

    // Update is called once per frame
    /// <summary>

    Ray ray;
    Ray ray2;
    Ray ray3;
    RaycastHit hit;

    void FixedUpdate()
    {
        Vector3 fwd = transform.TransformDirection(Vector3.forward);


        if (Input.GetKeyDown(KeyCode.K)|| Input.GetKeyDown("joystick button 3"))
        {

            Debug.Log("attack");
            ray = Camera.main.ScreenPointToRay(fwd);
            Vector3 temp = fwd;
            temp.x = fwd.x + (float)-1;
            ray2 = Camera.main.ScreenPointToRay(temp);
            temp.x = fwd.z + (float)-1;
            ray3 = Camera.main.ScreenPointToRay(temp);

            if (Physics.Raycast(ray, out hit)|| Physics.Raycast(ray2, out hit) || Physics.Raycast(ray3, out hit))
            {

                Debug.Log("kill");
                GameObject t = hit.collider.gameObject;

                if (t.tag == "m1")
                {
                    diez.Play();
                    Destroy(t);
                }
                if (t.tag == "m3")
                {
                    dies.Play();
                    Destroy(t);
                }
            }
        }




    }
}
