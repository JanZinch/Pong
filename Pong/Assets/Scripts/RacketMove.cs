using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RacketMove : MonoBehaviour {

    private float vect;
    [SerializeField] private float speed = 30f;
    [SerializeField] private string axis = "Vertical_1";

	void Start () {



	}
	
	void FixedUpdate () {

        vect = Input.GetAxisRaw(axis);
        GetComponent<Rigidbody2D>().velocity = new Vector2(0, vect) * speed;

    }
}
