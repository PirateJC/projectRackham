using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class namePick : MonoBehaviour {

	public Material notClicked;
	public Material Clicked;
	public GameObject nameManager;
	private List<string> nameList;
	private string lastNameHit;
	private bool nameFound = false;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		nameList = nameManager.GetComponent<namesForHat>().names;
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;

		if(Input.GetMouseButtonDown(0)){
			if (Physics.Raycast(ray, out hit, 100) && (hit.collider.tag == "nameCube")){ 
				lastNameHit = hit.collider.GetComponentInChildren<TextMesh>().text;
				//Debug.DrawLine(ray.origin, hit.point, Color.green);

				if(nameFound==false && hit.collider.GetComponent<Renderer>().material.name=="Blue (Instance)"){
					hit.collider.GetComponent<Renderer>().material = Clicked; 
					nameManager.GetComponent<namesForHat>().names.Add(lastNameHit);
				}
				else if(nameFound==false && hit.collider.GetComponent<Renderer>().material.name=="Red (Instance)"){
					hit.collider.GetComponent<Renderer>().material = notClicked; 
					nameManager.GetComponent<namesForHat>().names.Remove(lastNameHit);
				}
				nameFound=false;
			}
		}
	}
}
