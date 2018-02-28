using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour {

	public GameObject muzzle;

	void OnTriggerEnter(Collider other){
		//Debug.Log (other.name);
		PortalHandler.PH.SetBallDestination (other.GetComponent<Rigidbody> ());
	}
}
