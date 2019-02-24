using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour {
	
	void Update () {
		if (Input.GetButton("Fire1")) {
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;
			if (Physics.Raycast(ray, out hit)) {
				Time.timeScale = 0;
				if(hit.collider.name=="Play_Again")
					Application.LoadLevel("MainGame");
				if(hit.collider.name=="Play")
					Application.LoadLevel("MainGame");
				if(hit.collider.name=="Level1")
					Application.LoadLevel("MainGame");
				if(hit.collider.name=="Level2")
					Application.LoadLevel("MainGame");
				if(hit.collider.name=="Game_Over")
				{
					GameObject ts = GameObject.Find("Scripts");
					Destroy (ts);
					Application.LoadLevel("Menu");
				}
				Debug.Log ("Name = " + hit.collider.name);
				Debug.Log ("Tag = " + hit.collider.tag);
				Debug.Log ("Hit Point = " + hit.point);
				Debug.Log ("Object position = " + hit.collider.gameObject.transform.position);
				Debug.Log ("--------------");
			}
		}
	}
}