using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalHandler : MonoBehaviour {

	public GameObject bulletPrefab;
	public static PortalHandler PH;
	public Portal[] portales;
	int portal_count;
	// Use this for initialization
	void Start () {
		PH = this;
		portal_count = portales.Length;
	}

	public void SetBallDestination(Rigidbody bullet){
		int rand = Random.Range (0, portal_count);
		float bulletVelocity = bullet.GetComponent<Bullet>().speed;
		Destroy (bullet.gameObject);
		Transform muzzle = portales [rand].transform.Find ("Muzzle");
		GameObject go = Instantiate (bulletPrefab, muzzle.position, muzzle.rotation);
		Rigidbody bala = go.GetComponent<Rigidbody> ();
		bala.AddForce (muzzle.forward*bulletVelocity,ForceMode.VelocityChange);
	}
}
