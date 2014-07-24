using UnityEngine;
using System.Collections;

public class GameScore : MonoBehaviour {

	public int numHit;
	public int numMissed;
	public static GameScore activeScore;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public static GameScore GetInstance()
	{
		if (activeScore == null)
			activeScore = GameObject.FindObjectOfType<GameScore>();
		return activeScore;
	}
}
