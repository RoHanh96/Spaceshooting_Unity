using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Spaceship {
	//component SpaceShip
	//Spaceship spaceship;
	public static int life = 2;
	public int life_1 = 2;
	public GUIText life_display;
    IEnumerator Start() {
		//lay component Spaceship
		//spaceship = GetComponent<Spaceship> ();
        while (true) {
			Shot (transform);
			GetComponent<AudioSource> ().Play ();
			yield return new WaitForSeconds (shotDelay);
        }    
    }
	// Use this for initialization
	// Update is called once per frame
	void Update () {
		//Trai-phai
		float x = Input.GetAxisRaw ("Horizontal");
		//Tren-duoi
		float y = Input.GetAxisRaw ("Vertical");
		//huong di chuyen cua GO
		Vector2 direction = new Vector2 (x, y).normalized;
		//di chuyen
		//GetComponent<Rigidbody2D>().velocity = direction * 5;
		Move (direction);
	}
		
	//Dinh nghia lai di chuyen cua player
	public override void Move(Vector2 direction){
		Vector2 min = Camera.main.ViewportToWorldPoint (new Vector2 (0, 0));
		Vector2 max = Camera.main.ViewportToWorldPoint (new Vector2 (1, 1));
		Vector2 pos = transform.position;
		//do dich chuyen 
		pos += direction * speed * Time.deltaTime;
		pos.x = Mathf.Clamp (pos.x, min.x, max.x);
		pos.y = Mathf.Clamp (pos.y, min.y, max.y);
		transform.position = pos;
	}
	//Va cham 
	void OnTriggerEnter2D(Collider2D c){
		string layerName = LayerMask.LayerToName (c.gameObject.layer);
		//Neu ten layer la Bullet(Enemy) thi xoa dan di
		if(layerName == "Bullet(Enemy)"){
			Destroy (c.gameObject);
		}
		//Neu ten layer la Bullet(Enemy) hoac Enemy thi phat no
		if(layerName == "Bullet(Enemy)" || layerName == "Enemy"){
			if(life==0){
				print ("life: " + life);
				FindObjectOfType<Score> ().LifeDisplay (life+1);
				life = life_1;
				FindObjectOfType<Manager> ().GameOver ();
			}
			else{
				Explosion ();
				//Destroy (c.gameObject);
				Destroy (gameObject);
				print ("life: " + life);
				life = life - 1;
				FindObjectOfType<Score> ().LifeDisplay (life+1);
				FindObjectOfType<Manager> ().PlayNext ();
			}
		}
	}
}
