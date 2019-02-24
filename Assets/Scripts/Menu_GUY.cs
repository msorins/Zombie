using UnityEngine;
using System.Collections;

public class Menu_GUY : MonoBehaviour {

	// Use this for initialization
	private int coins;
	public Font myFont;
	public static bool come_Menu_Guy;
	void Start () {
		coins = PlayerPrefs.GetInt("Coins");
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnGUI () {
		GUI.matrix = Matrix4x4.TRS(Vector3.zero,Quaternion.identity,new Vector3(Screen.width/960f,Screen.height/600f,1f));
		// Make a group on the center of the screen
		GUI.backgroundColor = Color.clear;
		GUI.BeginGroup (new Rect (1, 1, 1000, 500));
		// All rectangles are now adjusted to the group. (0,0) is the topleft corner of the group.

		// We'll make a box so you can see where the group is on-screen.
		GUI.skin.label.font = myFont;
		GUI.skin.label.fontSize=42;
		GUI.Label (new Rect (800, 0, 300, 300), "Coins: " + coins.ToString ());
		// End the group we started above. This is very important to remember!
		GUI.EndGroup ();
		} 

	}
