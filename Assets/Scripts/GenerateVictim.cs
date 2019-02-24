using UnityEngine;
using System.Collections;

public class GenerateVictim : MonoBehaviour {
	
	// Use this for initialization
	public GameObject victim;
	public double time=0;
	public double req_time;
	private Vector3 pos;
	void Start () {
		req_time=Random.Range (10,25);
		pos = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		time += Time.deltaTime;
		if (time >= req_time) 
		{
			CreateObstacle();
			time=0;
			req_time=Random.Range (10,30);
		}
	}
	
	void CreateObstacle()
	{
		Vector3 poz= GameObject.Find("Zombie_Main").transform.position;
		pos.x=poz.x+45;
		//GameObject victim_aux = GameObject.lA.Instantiate (victim, pos, transform.rotation);
		GameObject victim_aux = GameObject.Instantiate( victim, pos, transform.rotation ) as GameObject;
		victim_aux.rigidbody2D.AddForce (Vector3.left * 130);
		Destroy(victim_aux, 50);
	}
}
