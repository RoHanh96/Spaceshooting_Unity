using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Emitter : MonoBehaviour {
	public GameObject[] waves;
	private int currentWave;
	private Manager manager;
	// Use this for initialization
	IEnumerator Start () {
		if(waves.Length == 0){
			yield break;
		}
		manager = FindObjectOfType<Manager> ();
		while(true){
			//Khi title hien thi thi doi
			while (manager.IsPlaying() == false){
				yield return new WaitForEndOfFrame ();
			}
			//Tao wave
			GameObject wave = (GameObject)Instantiate (waves [currentWave], transform.position, Quaternion.identity);
			//Thiet dat wave thanh con cua Emitter
			wave.transform.parent = transform;
			//Doi toi khi tat ca Enemy bi xoa het
			while(wave.transform.childCount !=0){
				yield return new WaitForEndOfFrame ();
			}
			//Xoa Wave
			Destroy (wave);
			//Neu tat ca cac wave da deu dc thuc hien thi set currentWave = 0
			if(waves.Length <= ++currentWave){
				currentWave = 0;
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
