using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Grid : MonoBehaviour {

	public int numRows = 4; 
	public int numCols = 4;
	public Circle circle;
	public float widthBufferPercent = 5;
	public float heightBufferPercent = 5;
	private float gridWidth;
	private float gridHeight;
	private List<Circle> circles;
	private static Grid activeGrid;

	// Use this for initialization
	void Start () {
		if (widthBufferPercent > 1)
		{
			widthBufferPercent/=100;
		}
		if (heightBufferPercent > 1)
		{
			heightBufferPercent /=100;
		}
		InitializeCircles();
		DeactivateAllCircles();
	}
	
	void InitializeCircles()
	{
		circles = new List<Circle>();
		circle.transform.position = Vector3.zero;
		Debug.Log ("Height = " + Screen.height);
		Debug.Log ("Width = " + Screen.width);
		
		gridWidth = Screen.width - 2*(Screen.width * widthBufferPercent);
		gridHeight = Screen.height - 2*(Screen.height * heightBufferPercent) - circle.texture.pixelInset.height/2f;
		
		Debug.Log ("GridHeight = " + gridHeight);
		Debug.Log ("GridWidth = " + gridWidth);
		
		for (int i = numCols-1; i >=0; i--)
		{
			float yOffset = gridHeight/(numCols - 1) * i + Screen.height*heightBufferPercent/2f;
			
			for (int j = 0; j < numRows; j++)
			{
				float xOffset = gridWidth/(numRows-1) * j + Screen.width*widthBufferPercent/2f;
				//if (j > 0)		
				xOffset += circle.texture.pixelInset.width/2f; 
				Circle thisCircle = ((GameObject) Instantiate(circle.gameObject, Vector3.zero, Quaternion.identity)).GetComponent<Circle>();
				thisCircle.name = "Circle " + (j+1) + "-" + (i+1); 
				thisCircle.transform.parent = transform;
				thisCircle.SetOffsets(xOffset, yOffset);
				thisCircle.ActivateGameObject();
				circles.Add(thisCircle);
			}
		}
	}
	
	void DeactivateAllCircles()
	{
		foreach(Circle circle in circles)
		{
			circle.Deactivate();
		}
		
	}
	
	public List<Circle> GetCircles()
	{
		return circles;
	}
	// Update is called once per frame
	void Update () {
	
	}
	public static Grid GetInstance()
	{
		if (activeGrid == null)
			activeGrid = GameObject.FindObjectOfType<Grid>();
		return activeGrid;
	}
}
