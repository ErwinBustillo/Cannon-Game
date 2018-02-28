using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonController : MonoBehaviour {

	public int token;
	public float speed = 5f;
	//public float minAngle = 0;
	//public float maxAngle = 360f;

	float horizontal=0f; 
	float vertical=0f; 
	float angle=0f;

	public bool isFiring;

    public GameObject prefabBullet;
    public Transform muzzle;
	public ForceMode tipoDeFuerza=ForceMode.Impulse;
  

	void OnDisable(){
		isFiring = false;
		//Debug.Log ("APAGADO");
	}
	// Update is called once per frame
	void Update () {
		GetInputs (); 
		if (isFiring ==false) {
			handleMovement ();
		}

       /* if (Input.GetMouseButtonDown(0))
        {
			Fire(forceSpeed);
        }*/
	}

	void GetInputs(){
		horizontal = Input.GetAxisRaw ("Horizontal");
		vertical = Input.GetAxisRaw ("Vertical");
	}

	void handleMovement(){
		if (token==2) {
			horizontal = horizontal * -1;
		}
		Vector3 direction = new Vector3 (horizontal,vertical,0f);
     	transform.Translate (direction * speed * Time.deltaTime);
	}

	public void handleRotation(float angleValue){
		//angle += horizontal;
		//angle = angleValue;
		Transform pivot = transform.Find("Pivot"); // referencia del pivote
		if (angleValue != null) {
			this.angle = 0;
			this.angle = angleValue;
			Debug.Log("angulo "+angle);
			//pivot.Rotate(0f,0f,angle);
			if (token == 2) {
				angle = angle * -1;
			}
			pivot.eulerAngles = new Vector3 (0f, 0f, angle);
		}

		//OLD V
		//angle = Mathf.Clamp( angle, minAngle, maxAngle ); // LIMITA el angulo de inclinacion entre -y,y
		//pivot.rotation= Quaternion.AngleAxis(angle, Vector3.forward);
		//pivot.Rotate(0f,0f,angle);

	}

	public void Fire(float forceSpeed) {
		isFiring = true;
        GameObject go = Instantiate(prefabBullet, muzzle.position,Quaternion.identity);
        go.GetComponent<Rigidbody>().AddForce(muzzle.forward*forceSpeed,tipoDeFuerza);
		Bullet bullet = go.GetComponent<Bullet> ();
		bullet.owner = name;
		bullet.speed = forceSpeed;
    }

}
