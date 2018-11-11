using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitRoom : MonoBehaviour {

    public GameObject target;

    void Start() {

    }

    void Update() {

    }

    void OnTriggerEnter2D(Collider2D other)
    { 
        //stop movement, and move position
        other.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0,0);
        other.gameObject.transform.position = target.transform.position;
    }

}
