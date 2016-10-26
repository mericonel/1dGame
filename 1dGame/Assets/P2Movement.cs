using UnityEngine;
using System.Collections;
using UnityEngine.UI; 

public class P2Movement : MonoBehaviour {

	private float Speed;
	private float movex = 0f;
	private float movey = 0f;

	private int P1score = 0; 

	public GameObject msh;
	public GameObject P1Point;
	public Text txt;

	public Rigidbody rg;

	public GameObject[] balls;

	public LineRenderer[] lr;
	public float points;
	public Vector3[] pos;

	void Start () {

	}

	void Update () {
		movex = Input.GetAxis ("Horizontal");
		movey = Input.GetAxis ("Vertical");
		Speed = 8;
		rg.velocity = new Vector2 (movex * Speed, movey * Speed);
	


		if (Input.GetKeyDown (KeyCode.H)) {
			if (points < 3) {
				if (points == 0) {
					Speed = 6; 
					balls [0].SetActive (true);
					balls [0].transform.position = transform.position;
					pos [0] = balls [0].transform.position;
					lr [0].SetPosition (0, pos [0]);
					lr [0].SetPosition (1, pos [0]);

				}
				if (points == 1) {
					Speed = 3; 
					balls [1].SetActive (true);
					balls [1].transform.position = transform.position;
					pos [1] = balls [1].transform.position;
					lr [1].SetPosition (0, pos [1]);
					lr [1].SetPosition (1, pos [1]);
					lr [0].SetPosition (1, pos [1]);

				}
				if (points == 2) {
					Speed = 1;
					balls [2].SetActive (true);
					balls [2].transform.position = transform.position;
					pos [2] = balls [2].transform.position;
					lr [1].SetPosition (1, pos [2]);
					lr [2].SetPosition (1, pos [0]);
					lr [2].SetPosition (0, pos [2]);
					 

					MeshFilter mf = msh.GetComponent<MeshFilter> ();
					Mesh mesh = new Mesh ();
					mf.mesh = mesh;

					Vector3[] vertices = new Vector3[3] {
						pos [0], pos [1], pos [2]
					};

					int[] tri = new int[3];

					tri[0] = 0;
					tri[1] = 1;
					tri[2] = 2;

					Vector3[] normals = new Vector3[3];

					normals[0] = -Vector3.up;
					normals[1] = -Vector3.up;
					normals[2] = -Vector3.up;

					Vector2[] uv = new Vector2[3];

					uv [0] = pos [0];
					uv [1] = pos [1];
					uv [2] = pos [2];

					mesh.vertices = vertices;
					mesh.triangles = tri;
					mesh.normals = normals;
					mesh.uv = uv;
					msh.GetComponent<MeshCollider>().sharedMesh = mesh;
					msh.SetActive (true);
				}

			}
			points++;
			if (points == 4) {
				for (int i = 0; i < balls.Length; i++) {
					balls [i].SetActive (false);
					msh.SetActive(false);
					points = 0;
				}
			}

		}

	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Player1") {
			print ("player 1 wins");
			P1score = P1score + 1; 
			txt.gameObject.SetActive (true);
			StartCoroutine("restart");

		}
	}
		IEnumerator restart(){
			yield return new  WaitForSeconds (2);
			Application.LoadLevel(Application.loadedLevel);
		}
	}


	