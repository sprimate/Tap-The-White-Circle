using UnityEngine;
using System.Collections;

public class Circle : MonoBehaviour {
	
	public GUITexture texture;
	public Color activeColor = Color.white;
	public Color inactiveColor = Color.black;
	private bool active = true;
	private GameScore score;

	// Use this for initialization
	void Start () {
		if (texture == null)
			texture = guiTexture;
		score = GameScore.GetInstance();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButton(0) && texture.HitTest(Input.mousePosition))
		{
			if (active){
				DeactivateUpdateScore(true);
			}
		}
	}
	
	public void SetXOffset(float xOffset)
	{
		texture.pixelInset = new Rect(xOffset, texture.pixelInset.y, texture.pixelInset.width, texture.pixelInset.height);
		
	}
	public void SetYOffset(float yOffset)
	{
		texture.pixelInset = new Rect(texture.pixelInset.y, yOffset, texture.pixelInset.width, texture.pixelInset.height);
		
	}
	
	public void SetOffsets(float xOffset, float yOffset)
	{
		texture.pixelInset = new Rect(xOffset, yOffset, texture.pixelInset.width, texture.pixelInset.height);
	}
	
	public void ActivateGameObject()
	{
		texture.gameObject.SetActive(true);
	}
	public void Activate()
	{
		active = true;
		texture.color = activeColor;
	}
	public void Deactivate()
	{
		active = false;
		texture.color = inactiveColor;
	}
	public void DeactivateUpdateScore(bool deactivatedByPlayer)
	{
		if (active){
			if (deactivatedByPlayer)
				score.numHit++;
			else
				score.numMissed++;
			Deactivate();
		}
	}
}
