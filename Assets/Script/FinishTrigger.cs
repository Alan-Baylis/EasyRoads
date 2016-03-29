using UnityEngine;
using System.Collections;

public class FinishTrigger : MonoBehaviour {

    byte lapsCounterBlue = 0;
	byte lapsCounterRed = 0;
    public string Tag;
	public GUIText gameOverText;
	public GUITexture gameOverTexture;
	public GUIText redWon;
	public GUIText blueWon;
	public GUIText timer;
	public GUIText timerRed;
	public GUIText timerBlue;
	float raceTime = 0;
	float redTime;
	float blueTime;

	void Start()
	{
		AudioListener.pause = false;
		gameOverText.text = "";
		redWon.text = "";
		blueWon.text = "";
		gameOverTexture.enabled = false;
	}

    void OnTriggerEnter(Collider crossCollider)
    {
        if (crossCollider.gameObject.tag == "Red")
        {
			Debug.Log("Red Crossed");
			lapsCounterRed++;
			if (lapsCounterRed == 2)
			{
				redTime = raceTime;
				timerRed.text = redTime.ToString ("F4");
				if (lapsCounterBlue > 1) 
				{
					GameOver ();
				}
			}
        }
		if (crossCollider.gameObject.tag == "Blue")
		{
			Debug.Log("Blue Crossed");
			lapsCounterBlue++;
			if (lapsCounterBlue == 2)
			{
				blueTime = raceTime;
				timerBlue.text = blueTime.ToString ("F4");
				if (lapsCounterRed > 1) 
				{
					GameOver ();
				}
			}
		}
    }

	public void GameOver()
	{
		gameOverTexture.enabled = true;
		gameOverText.text = "Game Over !";

		if (redTime - blueTime < 0) 
		{
			redWon.text = "Red Won !";
		} 
		else
		{
			blueWon.text = "Blue Won !";
		}	
		Time.timeScale = 0;
		AudioListener.pause = true;
	}

	void Update()
	{
		raceTime = raceTime + 1 * Time.deltaTime;
		timer.text = raceTime.ToString ("F4");
	}
}