using UnityEngine;
using System.Collections;

public class ZombieController : MonoBehaviour {

	public GameObject Zombie;
	public GameObject game_over;
	private Vector3 game_over_pos;
	private bool dead=false;
	public int score;
	private int id;
	public Font myFont;
	public static int coins;
	public AudioClip coin_sound, death_sound;
	
	Transform bar;
	// Use this for initialization
	void Start () {
		coins = PlayerPrefs.GetInt("Coins");
		 bar = GameObject.Find("Zombie_Main").transform;
		 id = MainScript.id;
	}
	
	// Update is called once per frame
	void Update () {
		if(id!=0)
			transform.position = new Vector3 (bar.position.x+3/MainScript.dx[id], Mathf.Max ( Mathf.Min( bar.position.y+3/MainScript.dy[id], 3), -3 ) , bar.position.z);
		else
			transform.position = new Vector3 (bar.position.x, bar.position.y, bar.position.z);
		Vector3 nou = bar.transform.eulerAngles;
		transform.eulerAngles = nou;
	}
	//Testes sa nu fie vreo coliziune 
	void OnCollisionEnter2D(Collision2D other)
	{
		GameObject obj = other.gameObject;
		if (obj.name == "Acid(Clone)" || obj.name == "Fire(Clone)") {
			Die();
				}
		if (obj.name == "Coin" || obj.name == "Coin 1") {
			DestroyObject (obj);
			coins++;
			audio.PlayOneShot(coin_sound);
				}
		if (obj.name == "Victim" || obj.name == "Victim(Clone)") {
			MainScript.lifes++;
			DestroyObject (obj);
			Vector3 new_poz=transform.position;
			for(int i=0; i<=5; i++)
			{
				if(MainScript.dl[i]==0)
				{
					MainScript.id=i;
					MainScript.dl[i]=1;
					break;
				}
			}
			GameObject Zombie_New = GameObject.Instantiate(Zombie,new_poz,Camera.mainCamera.gameObject.transform.rotation) as GameObject;

			/*
			Zombie_New.GetComponent<ZombieController>().id=++id;
			ZombieController la = Zombie_New.GetComponent<ZombieController>();
			la.random=1;
			*/
		}
	}

	void Die()
	{
		audio.PlayOneShot(death_sound);
		Debug.Log (death_sound.name);
		if (MainScript.lifes != 1) {
			Destroy (Zombie);
				}

		MainScript.lifes--;
		MainScript.dl[id]=0;

	}
}
