using UnityEngine;
using System.Collections;

public class GenerateBackgroun : MonoBehaviour {

	// Use this for initialization
	public GameObject fundal;
	public int  val=22;
	public double time=0;
	public Vector3 pos;

	void Start () {
		pos = transform.position;
		CreateObstacle ();
	}
	
	// Update is called once per frame
	void Update () {
		if (MainScript.refresh == 1) {
			pos = transform.position;
			time=4;
				}
		time += Time.deltaTime;
		if (time >= 2) 
		{
			CreateObstacle();
			time=0;
		}
	}

	void CreateObstacle()
	{
		pos.x += val;
		Object fundal_aux= Instantiate (fundal, pos, transform.rotation);
		Destroy(fundal_aux, 50);
	}
}
