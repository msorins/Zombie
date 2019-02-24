using UnityEngine;
using System.Collections;

public class GenerateObstacle : MonoBehaviour {
	
	// Use this for initialization
	public GameObject capcana1;
	public GameObject capcana2;
	public GameObject capcana3;
	public double time=0;
	public double req_time;
	private Vector3 pos;
	private Object capcana_aux;
	void Start () {
		req_time=Random.Range (1,5);
		pos = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		time += Time.deltaTime;
		if (time >= req_time) 
		{
			CreateObstacle();
			time=0;
			req_time=Random.Range (1,5);
		}
	}
	
	void CreateObstacle()
	{
		Vector3 poz= GameObject.Find("Zombie_Main").transform.position;
		pos.x=poz.x+10;
		pos.y = poz.y;
		int rr = Random.Range (1, 3);
		if (rr == 1)
			capcana_aux = Instantiate (capcana1, pos, transform.rotation);
		else
			capcana_aux = Instantiate (capcana2, pos, transform.rotation);
		/*	
		else 
			{
				pos.y=0.4f+Random.Range(-1,1)/10;
				capcana_aux= Instantiate (capcana3, pos, transform.rotation);
			}
		*/
		
		Destroy(capcana_aux, 40);

	}
}



