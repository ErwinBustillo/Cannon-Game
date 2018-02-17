using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour {

	public static GameManager GM;
	public Text winnerText;
	public Text turnText;
	public bool turnForPlayer1; 
	public bool turnForPlayer2;
	public GameObject holderInfoP1;
	public GameObject holderInfoP2;
	public GameObject JP1;
	public GameObject JP2;
	public bool winner=false; //Determina si hay un ganador
	int randomTurn;

	// Use this for initialization
	void Start () {
		GM = this;
		randomTurn = Random.Range (0, 2);
		if (randomTurn == 0) {
			turnText.text="TURN : P1";
			JP1.GetComponent<CannonController> ().enabled = true;
			JP2.GetComponent<CannonController> ().enabled = false;
			turnForPlayer1 = true;
			holderInfoP1.SetActive (true);
		} else {
			turnText.text="TURN : P2";
			JP1.GetComponent<CannonController> ().enabled = false;
			JP2.GetComponent<CannonController> ().enabled = true;
			turnForPlayer2 = true;
			holderInfoP2.SetActive (false);
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (!turnForPlayer1 && turnForPlayer2) {
			turnText.text="TURN : P2";
			holderInfoP1.SetActive (false);
			holderInfoP2.SetActive (true);
		}
		if (!turnForPlayer2 && turnForPlayer1) {
			turnText.text="TURN : P1";
			holderInfoP1.SetActive (true);
			holderInfoP2.SetActive (false);
		}
		if (winner) {
			holderInfoP1.SetActive (false);
			holderInfoP2.SetActive (false);
			if (JP1 == null) {
				winnerText.text= "WINNER PLAYER 2";
				Debug.Log ("JUGADOR 2 Gano");
			} else {
				if (JP2 == null) {
					winnerText.text= "WINNER PLAYER 1";
					Debug.Log ("JUGADOR 1 Gano");
				}
			}
		}

		//Para recargar el juego
		if (Input.GetKeyDown(KeyCode.R)) {
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
		}
	}

	public void winCondition(){
		winner = true;
		winnerText.gameObject.SetActive (true);
	}

	public void ChangeTurn(bool x){


		if (turnForPlayer1) {
			Debug.Log ("TURNO JUGADOR 2");
			turnForPlayer1 = false;
			turnForPlayer2 = true;
			if (JP2) {
				JP1.GetComponent<CannonController> ().enabled = false;
				JP2.GetComponent<CannonController> ().enabled = true;
			}
		} else {
			if (turnForPlayer2) {
				Debug.Log ("TURNO JUGADOR 1");
				turnForPlayer2 = false;
				turnForPlayer1 = true;
				if (JP1) {
					JP2.GetComponent<CannonController> ().enabled = false;
					JP1.GetComponent<CannonController> ().enabled = true;
				}
			}
		}

	}
}
