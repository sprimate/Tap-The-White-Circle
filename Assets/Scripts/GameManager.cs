using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {
	
	public float originalTimeUntilSwitch = 3f;
	public int originalMaxNumActive = 3;
	public int originalMinNumActive = 2;
	private float timeOfLastSwitch = 0;
	public float speedModifier = 120; //The higher the number, the slower the difficulty increase
	private float speedModifierOffset;
	private List<Circle> activeCircles;
	public float timeUntilSwitch;
	private float gameStartTime;
	private int maxNumActive;
	private int minNumActive;
	public Grid grid;
	private int numMissed;
	private int numHit;
	public GUIText timeText;
	
	// Use this for initialization
	void Start () {
		if (grid == null)
			grid = Grid.GetInstance();
		activeCircles = new List<Circle>();
		maxNumActive = originalMaxNumActive;
		minNumActive = originalMinNumActive;
		timeUntilSwitch = originalTimeUntilSwitch;
		speedModifierOffset = speedModifier/originalTimeUntilSwitch;
		gameStartTime = Time.time;
		
	}
	
	// Update is called once per frame
	void Update () {
		IncreaseSpeed();
		if (ShouldSwitch())
		{
			DeactivateActiveCircles(true);
			Switch();
			//IncreaseSpeed();
		}
		UpdateTimeText();
	}
	
	void UpdateTimeText()
	{
		timeText.text = Mathf.FloorToInt(Time.time - gameStartTime).ToString();
	}
	
	void IncreaseSpeed() //after 
	{
		timeUntilSwitch = speedModifier/(speedModifierOffset + Time.time - gameStartTime);
		
		//timeUntilSwitch -= speedIncreasePerSwitch;
	}
	
	void DeactivateActiveCircles(bool keepScore)
	{
		foreach(Circle circle in activeCircles)
		{
			if (keepScore)
				circle.DeactivateUpdateScore(false);
			else
				circle.Deactivate();
		}
	}
	
	bool ShouldSwitch()
	{
		return timeOfLastSwitch + timeUntilSwitch <= Time.time;
	}
	public void Switch()
	{
		timeOfLastSwitch = Time.time;
		int numToSwitch = Random.Range(minNumActive, maxNumActive+1);
		List<Circle> circles = grid.GetCircles();
		activeCircles = new List<Circle>();
		for (int i = 0; i < numToSwitch; i++)
		{
			
			int switchIndex = 0;
			bool foundCircleToActivate = false;
			while (!foundCircleToActivate){
				switchIndex = Random.Range(0, circles.Count);
				if (activeCircles.Contains(circles[switchIndex]))
					foundCircleToActivate = false;
				else
					foundCircleToActivate = true;
			}
			circles[switchIndex].Activate();
			activeCircles.Add(circles[switchIndex]);
		}
		
		
	}
}
