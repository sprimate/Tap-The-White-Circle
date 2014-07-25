using UnityEngine;
using System.Collections;

public class GameScore : MonoBehaviour {

	public int numHit;
	public int numMissed;

	private int highScore;
	public static GameScore activeScore;
	public GUIText hitText;
	public GUIText missedText;
	private string highScoreString = "High Score";
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		CheckHighScore();
		hitText.text = numHit.ToString();
		missedText.text = numMissed.ToString();
	}
	
	public static GameScore GetInstance()
	{
		if (activeScore == null)
			activeScore = GameObject.FindObjectOfType<GameScore>();
		return activeScore;
	}
	
	public void CheckHighScore()
	{
		highScore = PlayerPrefs.GetInt(highScoreString, numHit);
		if (highScore  < numHit)
		{
			highScore = numHit;
			PlayerPrefs.SetInt(highScoreString, numHit);
		}
	}
}
