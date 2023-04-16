using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour 
{

	public float moveSpeed = 100f;

	GameObject my_object;
	
	// Use this for initialization
	void Start () {
	

		my_object = GameObject.FindWithTag ("Yellow");
	}
	
	// Update is called once per frame
	void Update () {
	
		if (Input.GetKey (KeyCode.UpArrow))
			my_object.transform.Translate (Vector3.forward * moveSpeed * Time.deltaTime);
		
		if (Input.GetKey (KeyCode.DownArrow))
			my_object.transform.Translate (-Vector3.forward * moveSpeed * Time.deltaTime);
		
		if (Input.GetKey (KeyCode.LeftArrow))
			my_object.transform.Translate (Vector3.left * moveSpeed * Time.deltaTime);
		
		if (Input.GetKey (KeyCode.RightArrow))
			my_object.transform.Translate (Vector3.right * moveSpeed * Time.deltaTime);
		
		if (Input.GetKey("escape"))
			Application.Quit();


	}
}
