using UnityEngine;
using System.Collections;

public class PickUpObject : MonoBehaviour {

	///private bool LookingAtObject;

	// Use this for initialization
	public Material HighlightMaterial;
	public Material UnhighlightMaterial;

	private GameObject HighlightedObject;

	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		CastRayForward ();
		if (Input.GetMouseButtonDown (0)) {
			if(HighlightedObject != null)
				HighlightedObject.transform.parent = this.transform;
		}

		if(Input.GetMouseButtonUp(0)) {
			if(HighlightedObject != null)
				HighlightedObject.GetComponent<Rigidbody>().isKinematic = false;
				HighlightedObject.transform.parent = null;
		}
	}

	void CastRayForward(){
		Vector3 fwd = transform.TransformDirection(Vector3.forward);
		RaycastHit hit;	
		if (Physics.Raycast (transform.position, fwd, out hit)) { 
			if (hit.transform.gameObject.tag == "MovableObject") {
				hit.transform.gameObject.GetComponent<Renderer> ().material = HighlightMaterial;
				HighlightedObject = hit.transform.gameObject;
			}
			else {
				if(HighlightedObject != null){
					HighlightedObject.GetComponent<Renderer>().material = UnhighlightMaterial;
				}
			}
		} 

	}


}
