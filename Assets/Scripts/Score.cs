using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour {
	public GUIText scoreGUIText;
	public GUIText highScoreGUIText;
	public GUIText lifeGUIText;
	private int score;
	private int highScore;
	//PlayerPrefs
	private string highScoreKey = "highScore";

	// Use this for initialization
	void Start () {
		Initialize ();
	}
	
	// Update is called once per frame
	void Update () {
		if(highScore < score){
			highScore = score;
		}
		scoreGUIText.text = score.ToString ();
		highScoreGUIText.text = "High Score: " + highScore.ToString ();
	}

	//Trang thai khi bat dau game 
	public void Initialize(){
		score = 0;
		highScore = PlayerPrefs.GetInt (highScoreKey, 0);
	}

	//Them point 
	public void AddPoint(int point){
		score = score + point;
	}

	//Luu lai highScore
	public void Save(){
		PlayerPrefs.SetInt (highScoreKey, highScore);
		PlayerPrefs.Save();

		//Quay tro lai trang thai ban dau
		Initialize ();
	}

	//show life
	public void LifeDisplay(int life){
		lifeGUIText.text = "Life: " + life.ToString();
	}
}
