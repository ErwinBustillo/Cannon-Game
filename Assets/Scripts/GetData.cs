using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetData : MonoBehaviour {

    public InputField angulo;
    public InputField fuerza;
	public GameObject Player;

    
	public void HandleShootEvent(){
		CannonController jp = Player.GetComponent<CannonController> ();
		if (jp) {
			Debug.Log ("EXISTO");
		}
		if (!angulo) {
			return;
		}
		if (!fuerza) {
			return;
		}
		float angle = float.Parse (angulo.text.ToString ());
		float force = float.Parse (fuerza.text.ToString ());
		jp.handleRotation (angle);
		if (force <0.0f) {
			force = force * -1;

		}
		jp.Fire (force);
		//Debug.Log ("Force:" + force + "," + "Angle: " + angle);
		angulo.text = "";
		fuerza.text = "";
	}
}
