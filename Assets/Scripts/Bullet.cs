using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
	public int speed;
	public float lifeTime;
	public int power = 1;
	// Use this for initialization
	void Start () {
		GetComponent<Rigidbody2D> ().velocity = transform.up.normalized * speed;
		Destroy (gameObject, lifeTime);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
