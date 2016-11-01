using UnityEngine;
using System.Collections;
using UnityEngine.UI; 

public class P3Movement : MonoBehaviour {

	public AudioSource boom;

	private float xSpeed;
	private float ySpeed;

	public GameObject msh;

	public Rigidbody rg;

	public GameObject[] balls;

	public LineRenderer[] lr;
	public float points;
	public Vector3[] pos;


	void Start () {

		xSpeed = Random.Range (-6.0f, 6.0f);
		ySpeed = Random.Range (4.0f , 6.0f);
		
		//xSpeed = Random.Range (Random.Range(-7.0f, -5.0f) , Random.Range(5.0f, 7.0f));
		//ySpeed = Random.Range (Random.Range(-7.0f, -5.0f) , Random.Range(5.0f, 7.0f));


	}

	void Update () {

		rg.velocity = new Vector2 (xSpeed , ySpeed);

	}
	

		void OnTriggerEnter(Collider other){
		if (other.gameObject.tag == "CollisionH") {
			print ("BAM H");
			ySpeed *= -1;


			//points keep track on which ball we should activate and how to handle the sequences
			if (points < 3) {
				if (points == 0) {
					//activate first ball and store position 
					balls [0].SetActive (true);
					balls [0].transform.position = transform.position;
					pos [0] = balls [0].transform.position;
					//set line renderer to nothing for now because there is no second point
					lr [0].SetPosition (0, pos [0]);
					lr [0].SetPosition (1, pos [0]);
					boom.Play ();


				}
				if (points == 1) {
					//activate second ball and store position
					balls [1].SetActive (true);
					balls [1].transform.position = transform.position;
					pos [1] = balls [1].transform.position;
					//set line renderer of the first ball point towards the second ball
					lr [1].SetPosition (0, pos [1]);
					lr [1].SetPosition (1, pos [1]);
					lr [0].SetPosition (1, pos [1]);
					boom.Play ();


				}
				if (points == 2) {
					//activate third ball and store position
					balls [2].SetActive (true);
					balls [2].transform.position = transform.position;
					pos [2] = balls [2].transform.position;

					//set line renderer of second ball to point at third ball while 
					//the line renderer on the third ball points to the first ball

					lr [1].SetPosition (1, pos [2]);
					lr [2].SetPosition (1, pos [0]);
					lr [2].SetPosition (0, pos [2]);
					boom.Play ();




					//setup mesh creation
					MeshFilter mf = msh.GetComponent<MeshFilter> ();
					Mesh mesh = new Mesh ();
					mf.mesh = mesh;

					//set vertices with the use of the stored positions from the balls
					Vector3[] vertices = new Vector3[3] {
						pos [0], pos [1], pos [2]
					};


					//set triangles
					int[] tri = new int[3];

					tri [0] = 0;
					tri [1] = 1;
					tri [2] = 2;


					//set normals
					Vector3[] normals = new Vector3[3];

					normals [0] = -Vector3.up;
					normals [1] = -Vector3.up;
					normals [2] = -Vector3.up;


					//set uv
					Vector2[] uv = new Vector2[3];

					uv [0] = pos [0];
					uv [1] = pos [1];
					uv [2] = pos [2];


					//apply all the above towards the mesh
					mesh.vertices = vertices;
					mesh.triangles = tri;
					mesh.normals = normals;
					mesh.uv = uv;
					//apply the mesh to be used as the mesh collider and finally activate the mesh
					msh.GetComponent<MeshCollider> ().sharedMesh = mesh;
					msh.SetActive (true);
				}

			}
			points++;
			if (points == 4) {
				//disable all balls and mesh, then reset
				for (int i = 0; i < balls.Length; i++) {
					balls [i].SetActive (false);
					msh.SetActive (false);
					points = 0;
				}
			}
		}

			else if (other.gameObject.tag == "CollisionW") {
				print ("BAM W");
			xSpeed *= -1;




				//points keep track on which ball we should activate and how to handle the sequences
				if (points < 3) {
					if (points == 0) {
						//activate first ball and store position 
						balls [0].SetActive (true);
						balls [0].transform.position = transform.position;
						pos [0] = balls [0].transform.position;
						//set line renderer to nothing for now because there is no second point
						lr [0].SetPosition (0, pos [0]);
						lr [0].SetPosition (1, pos [0]);
					boom.Play ();


					}
					if (points == 1) {
						//activate second ball and store position
						balls [1].SetActive (true);
						balls [1].transform.position = transform.position;
						pos [1] = balls [1].transform.position;
						//set line renderer of the first ball point towards the second ball
						lr [1].SetPosition (0, pos [1]);
						lr [1].SetPosition (1, pos [1]);
						lr [0].SetPosition (1, pos [1]);
					boom.Play ();


					}
					if (points == 2) {
						//activate third ball and store position
						balls [2].SetActive (true);
						balls [2].transform.position = transform.position;
						pos [2] = balls [2].transform.position;

						//set line renderer of second ball to point at third ball while 
						//the line renderer on the third ball points to the first ball

						lr [1].SetPosition (1, pos [2]);
						lr [2].SetPosition (1, pos [0]);
						lr [2].SetPosition (0, pos [2]);
					boom.Play ();




						//setup mesh creation
						MeshFilter mf = msh.GetComponent<MeshFilter> ();
						Mesh mesh = new Mesh ();
						mf.mesh = mesh;

						//set vertices with the use of the stored positions from the balls
						Vector3[] vertices = new Vector3[3] {
							pos [0], pos [1], pos [2]
						};


						//set triangles
						int[] tri = new int[3];

						tri[0] = 0;
						tri[1] = 1;
						tri[2] = 2;


						//set normals
						Vector3[] normals = new Vector3[3];

						normals[0] = -Vector3.up;
						normals[1] = -Vector3.up;
						normals[2] = -Vector3.up;


						//set uv
						Vector2[] uv = new Vector2[3];

						uv [0] = pos [0];
						uv [1] = pos [1];
						uv [2] = pos [2];


						//apply all the above towards the mesh
						mesh.vertices = vertices;
						mesh.triangles = tri;
						mesh.normals = normals;
						mesh.uv = uv;
						//apply the mesh to be used as the mesh collider and finally activate the mesh
						msh.GetComponent<MeshCollider>().sharedMesh = mesh;
						msh.SetActive (true);
					}

				}
				points++;
				if (points == 4) {
					//disable all balls and mesh, then reset
					for (int i = 0; i < balls.Length; i++) {
						balls [i].SetActive (false);
						msh.SetActive (false);
						points = 0;
					}
				}

		}

	}


	}
