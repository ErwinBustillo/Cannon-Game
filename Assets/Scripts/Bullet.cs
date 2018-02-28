using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

	[HideInInspector]
	public string owner;
	public float speed;
	public AudioSource audioSource;
	void OnCollisionEnter(Collision other){
		audioSource.Play ();
		if (other.gameObject.tag == "Border") {
			if (GameManager.GM.winner == false) GameManager.GM.ChangeTurn (true);
		} else {
			if (other.transform.root.tag == "Player") {
				//Debug.Log ("EXISTE PLAYER:"+other.transform.root.gameObject.name);
				other.transform.root.gameObject.GetComponent<Health> ().takeDamage(20);// le quito 20 puntos al jugador 
				if (GameManager.GM.winner == false) GameManager.GM.ChangeTurn (true);
			} else {//En otro caso
				if (GameManager.GM.winner == false) GameManager.GM.ChangeTurn (true);
			}
		}

		Destroy (this.gameObject);
	}

}
