using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour {

    public Camera myCamera;
    public GameObject target;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        myCamera.gameObject.transform.position = new Vector3(target.transform.position.x, target.transform.position.y, myCamera.gameObject.transform.position.z);//dont change z
    }

}
