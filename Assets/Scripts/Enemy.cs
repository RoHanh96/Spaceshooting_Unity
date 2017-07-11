using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Spaceship {
	public int hp = 1; 
	public int point = 10;
	//Spaceship spaceship;
	// Use this for initialization
	IEnumerator Start () {
		//lay component Spaceship
		//spaceship = GetComponent<Spaceship> ();
		//Di chuyen enemy
		animator = GetComponent<Animator> ();
		Move(transform.up * -1);
		//Kiem tra enemy co the ban dan duoc hay khong
		if (canShot == false) {
			yield break;
		}
		while (true) {
			for (int i = 0; i < transform.childCount; i++) {
				Transform shotPosition = transform.GetChild (i);
				Shot (shotPosition);
			}
			yield return new WaitForSeconds (shotDelay);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	//Va cham
	void OnTriggerEnter2D(Collider2D c){
		string layerName = LayerMask.LayerToName (c.gameObject.layer);
		if (layerName != "Bullet(Player)")
			return;
		Transform playerBulletTransform = c.transform.parent;
		Bullet bullet = playerBulletTransform.GetComponent<Bullet> ();
		hp = hp - bullet.power;
		Destroy (c.gameObject);
		if(hp <=0){
			FindObjectOfType<Score> ().AddPoint (point);
			Explosion ();
			Destroy (gameObject);
		}
		else{
			GetAminator ().SetTrigger ("Damage");
		}

	}

	//Ham di chuyen
	public override void Move(Vector2 direction){
		//print (d);
		GetComponent<Rigidbody2D>().velocity = direction * speed;
	}
}
