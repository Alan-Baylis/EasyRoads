using UnityEngine;
using System.Collections;

public class GuiRedWin : MonoBehaviour {

	public void OnGUI()
	{
		GUI.Label (new Rect (20, 20, 200, 40), "Red won!");
	}
}
