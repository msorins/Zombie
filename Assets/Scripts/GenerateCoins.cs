using UnityEngine;
using System.Collections;

public class GenerateCoins : MonoBehaviour {
	
	// Use this for initialization
	public GameObject coins,coins2,coins3;
	public int  val=22;
	public double time=1;
	private Vector3 pos;
	private int id=0;
	public float range = 4;
	
	void Start () {
		pos = transform.position;
		CreateObstacle ();
	}
	
	// Update is called once per frame
	void Update () {
		time += Time.deltaTime;
		if (time >= 4) 
		{
			CreateObstacle();
			time=0;
		}
	}
	
	void CreateObstacle()
	{
		pos.x += val;
		pos.y= transform.position.y - range * Random.value+3;
		pos.y = Mathf.Min (pos.y, 3);
		if (id == 0) {
						Object coins_aux = Instantiate (coins, pos, transform.rotation);
						Destroy (coins_aux, 40);
						id++;
				} else
			if (id == 1) {
						Object coins_aux = Instantiate (coins2, pos, transform.rotation);
						Destroy (coins_aux, 40);
						id++;
				} else {
						Object coins_aux = Instantiate (coins3, pos, transform.rotation);
						Destroy (coins_aux, 40);
						id=0;
				}
	}
}
