using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Health : MonoBehaviour {

	public int tokenPlayer;
	public Text textHealth;
	public int health;
	int currentHealth;
	public ParticleSystem particle;

	// Use this for initialization
	void Start () {
		currentHealth = health;
		if (tokenPlayer == 1) {
			textHealth.text = "PLAYER "+tokenPlayer+":" + currentHealth;
		} else {
			textHealth.text = "PLAYER "+tokenPlayer+":" + currentHealth;
		}

	}
	
	public void takeDamage(int amount){
		currentHealth -= amount;
		if (tokenPlayer==1) {
			textHealth.text = "PLAYER "+tokenPlayer+":" + currentHealth;
		} else {
			textHealth.text = "PLAYER "+tokenPlayer+":" + currentHealth;
		}
		if (currentHealth <= 0)
		{
			currentHealth = 0;
			particle.transform.SetParent (null);
			particle.Play ();
			Destroy (gameObject);
			GameManager.GM.winCondition ();
		}
	}
}
