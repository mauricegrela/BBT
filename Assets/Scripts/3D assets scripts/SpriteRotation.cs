using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteRotation : MonoBehaviour {
    public Transform target;
	// Use this for initialization
	void Start () {
        /*target = GameObject.FindWithTag("MainCamera").GetComponent<Transform>();
        Vector3 relativePos = target.position - transform.position;

        // the second argument, upwards, defaults to Vector3.up
        Quaternion rotation = Quaternion.LookRotation(relativePos, Vector3.up);
        transform.rotation = rotation;*/

        gameObject.AddComponent<Rigidbody>();
        gameObject.AddComponent<BoxCollider>();

        gameObject.GetComponent<BoxCollider>().size = new Vector3(gameObject.GetComponent<BoxCollider>().size.x,gameObject.GetComponent<BoxCollider>().size.y,0.001f);

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Throw()
    {
        transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, transform.eulerAngles.z);
        float speed = 60;
        //gameObject.AddComponent<Rigidbody>().isKinematic = false;
        Vector3 force = transform.forward;
        force = new Vector3(force.x, 1, force.z);
        gameObject.GetComponent<Rigidbody>().AddForce(force * speed);
    }
}
