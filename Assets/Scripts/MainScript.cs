using UnityEngine;
using System.Collections;
using System.Xml;
using System.Xml.Serialization;

public class MainScript : MonoBehaviour {
	
	public GameObject Zombie_Main, Zombie;
	public float moveSpeed, turnSpeed;
	public GameObject game_over;
	public Font myFont;
	public int coins;
	public static int lifes=1,id=0 ,refresh=0;
	private GameObject Zombie_Main_Var;
	private Vector3 moveDirection;
	private int score;
	private double time=0;
	private bool dead=false,first_3_seconds=true;
	public static bool pause=false;
	public static int[] dx = new int[6] ;
	public static int[] dy = new int[6];
	public static int[] dl = new int[6];
	// Use this for initialization
	void Start () {
	    //Zombie_Main = GameObject.Instantiate(Zombie_Main,transform.position, transform.rotation) as GameObject;
		//Zombie_Main.name = "Zombie_Main";

		coins = PlayerPrefs.GetInt("Coins");

		Time.timeScale = 1;
		moveDirection = Vector3.right;

		Instantiate (Zombie, transform.position, transform.rotation);
		dx [0] = 0; dy [0] = 0;
		dx [1] = 5; dy [1] = 2;
		dx [2] = 3; dy [2] = -2;
		dx [3] = 3; dy [3] = 1;
		dx [4] = 2; dy [4] = 2;
		dx [5] = 1; dy [5] = 3;

		dl [0] = 1; dl [1] = 0; dl[2]=0; dl [3] = 0; dl [4] = 0; dl [5] = 0;
	}
	
	// Update is called once per frame
	void Update () {
			
		// Playerul a dat rety
		if (Zombie_Main == null) 
		{
			Zombie_Main = GameObject.Find ("Zombie_Main");
			Instantiate (Zombie, transform.position, transform.rotation);
			Time.timeScale = 1;
			refresh = 1;
		}
		else 
			refresh=0;

		//Playerul a murit , resetez TOTUL !!
		if ( lifes <= 0) {
			//Salvez jocul

			Vector2 pos_camera = Camera.mainCamera.gameObject.transform.position ;
			pos_camera.y-=+0.2f;
			Instantiate (game_over, pos_camera, Camera.mainCamera.gameObject.transform.rotation);

			//Restez valori
			Time.timeScale = 0;
			lifes=1;
			moveSpeed = 5;
			first_3_seconds=true;
			time=0;
			coins = PlayerPrefs.GetInt("Coins");
		}
		// Numarul de coins 
		if (ZombieController.coins > coins) {
			coins = ZombieController.coins;
			PlayerPrefs.SetInt("Coins", coins);
				}


		//Numarul de metri parcursi
		Vector3 poz= GameObject.Find("Zombie_Main").transform.position;
		score = (int) poz.x / 2 ;
	
		//Directie & Rotatie zombie sef
		Vector3 currentPosition = Zombie_Main.transform.position;
		
		if( Input.GetButton("Fire1") ) {
			Vector3 moveToward = Camera.main.ScreenToWorldPoint( Input.mousePosition );
			moveDirection = moveToward - currentPosition;
			moveDirection.z = 0; 
			moveDirection.Normalize();
			
		}
		
		Vector3 target = moveDirection * moveSpeed + currentPosition;
		Zombie_Main.transform.position = Vector3.Lerp( currentPosition, target, Time.deltaTime );
		
		float targetAngle = Mathf.Atan2(moveDirection.y, moveDirection.x) * Mathf.Rad2Deg;
		Zombie_Main.transform.rotation = 
			Quaternion.Slerp( Zombie_Main.transform.rotation, 
			                 Quaternion.Euler( 0, 0, targetAngle ), 
			                 turnSpeed * Time.deltaTime );

		//Vieza creste la 20 secunde 
		time += Time.deltaTime;
		if (time >= 3)
			first_3_seconds = false;
		if (time >= 20 && moveSpeed<9) {
			time=0;
			moveSpeed++;
				}

	}
	
	// Scris 
	void OnGUI () {
		GUI.matrix = Matrix4x4.TRS(Vector3.zero,Quaternion.identity,new Vector3(Screen.width/960f,Screen.height/600f,1f));
		// Make a group on the center of the screen
		if (dead == false) {
			GUI.backgroundColor = Color.clear;
			GUI.BeginGroup (new Rect (1, 1, 1000, 500));
			// All rectangles are now adjusted to the group. (0,0) is the topleft corner of the group.
			
			// We'll make a box so you can see where the group is on-screen.
			GUI.skin.label.font = myFont;
			GUI.skin.label.fontSize=38;
			GUI.Label (new Rect (0, 0, 600, 500), " Meters : " + score.ToString ());
			GUI.Label (new Rect (900, 0, 300, 100), " " + coins.ToString ());
			if(first_3_seconds==true)
			{
				GUI.color = Color.black;
				GUI.skin.label.fontSize=42;
				GUI.Label (new Rect (250, 100, 500, 500), " Next level in 500 Meters ! ");
			}
			// End the group we started above. This is very important to remember!
			GUI.EndGroup ();
		} 
		else {
			GUI.backgroundColor = Color.clear;
			GUI.BeginGroup (new Rect (320, 0, 1400, 1300));
			// All rectangles are now adjusted to the group. (0,0) is the topleft corner of the group.
			
			// We'll make a box so you can see where the group is on-screen.
			
			GUI.skin.label.font = myFont;
			GUI.skin.label.fontSize=38;
			GUI.Label (new Rect (0, 0, 600, 500), " Meters : " + score.ToString ());
			GUI.Label (new Rect (0, 45, 600, 500), " HighScore : To-Do");
			
			// End the group we started above. This is very important to remember!
			GUI.EndGroup ();
		
		}
	}

	public void Awake()
	{
		DontDestroyOnLoad(this);
		
		if (FindObjectsOfType(GetType()).Length > 1)
		{
			Destroy(gameObject);
		}
	}
}

