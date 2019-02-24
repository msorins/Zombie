using UnityEngine;
using System.Collections;

public class Score : MonoBehaviour {

	public int score;
	public Font myFont;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 poz= GameObject.Find("Zombie").transform.position;
		score = (int) poz.x / 2 ;
	}

	void OnGUI () {
		// Make a group on the center of the screen
		GUI.backgroundColor = Color.clear;
		GUI.BeginGroup (new Rect (1, 1, 130, 30));
		// All rectangles are now adjusted to the group. (0,0) is the topleft corner of the group.
		
		// We'll make a box so you can see where the group is on-screen.
		GUI.skin.label.fontSize = 25;
		GUI.skin.label.font = myFont;
		GUI.Label (new Rect (0,0,130,30), " Meters : " + score.ToString());

		// End the group we started above. This is very important to remember!
		GUI.EndGroup ();
	}

}
