using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Backgrounds : MonoBehaviour {
	public float speed = 0.1f;
	Renderer renderer;
	// Use this for initialization
	void Start () {
		renderer = GetComponent<Renderer> ();
	}
	
	// Update is called once per frame
	void Update () {
		// Theo thời gian,giá trị của Y sẽ thay đổi từ 0 -> 1 và từ 1 trở về 0. Lặp đi lặp lại
		//print ("Time    " + Time.time);
		float y = Mathf.Repeat (Time.time * speed, 1);
		//print ("Y =  "+ y);
		// khoảng cách giá trị sai lệch của trục Y
		Vector2 offset = new Vector2 (0, y);
		// khoảng cách giá trị sai lệch của trục Y
		renderer.sharedMaterial.SetTextureOffset ("_MainTex", offset);
	}
}