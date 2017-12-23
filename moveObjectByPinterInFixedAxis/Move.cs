using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour {
	// Use this for initialization
	void Start ()
	{
		StartCoroutine(OnMouseDown());
	}

	IEnumerator OnMouseDown ()//when we click th collider, call the method
	{
   //transform the world position of the object into its screen position
		Vector3 screenSpace = Camera.main.WorldToScreenPoint (transform.position);
    //the relative position between pointer and object will not change.
		Vector3 offset = transform.position - Camera.main.ScreenToWorldPoint (new Vector3 (Input.mousePosition.x, screenSpace.y, screenSpace.z));
		while (Input.GetMouseButton (0))
    {
      //record the x position of mouse
			Vector3 curScreenSpace = new Vector3 (Input.mousePosition.x, screenSpace.y, screenSpace.z);
			Vector3 curPosition = Camera.main.ScreenToWorldPoint (curScreenSpace) + offset;
			transform.position = curPosition;
			yield return new WaitForFixedUpdate ();
		}
	}
  
}
