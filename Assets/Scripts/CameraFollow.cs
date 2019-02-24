using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {
	
	Transform bar;
	
	void Start() {
		bar = GameObject.Find("Zombie_Main").transform;
	}
	
	void Update() {
		transform.position = new Vector3(Mathf.Max(transform.position.x, bar.position.x+3 ), transform.position.y, transform.position.z);
	}
}