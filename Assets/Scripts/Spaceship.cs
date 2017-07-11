using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public abstract class Spaceship : MonoBehaviour {
	public float speed;
	public float shotDelay;
	public GameObject bullet;
	public bool canShot;
	//Prefab phat no
	public GameObject explosion;
	//Animator Component
	public Animator animator;


	//Tao GO phat no
	public void Explosion(){
		Instantiate (explosion, transform.position, transform.rotation);
	}

	public void Shot(Transform origin){
		Instantiate (bullet, origin.position, origin.rotation);
	}


	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public Animator GetAminator(){
		return animator;
	}

	public abstract void Move (Vector2 direction);
}
