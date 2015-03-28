using UnityEngine;
using System.Collections;

public class moveBK : MonoBehaviour {
	private Vector2 movement;
	private Vector3 size;
	private Vector3 bg;
	public float positionRestartX;

	/**
	 * Initialisation
	 **/
	void Start () {
		bg = Camera.main.ViewportToWorldPoint (new Vector3 (0, 0, 0));
		movement = new Vector2 ( -2f, 0f);
	}

	/**
	 * Mise a jour à chaque tour
	 * */
	void Update(){
		GetComponent<Rigidbody2D>().velocity = movement;
		size.x = gameObject.GetComponent<SpriteRenderer> ().bounds.size.x;
		size.y = gameObject.GetComponent<SpriteRenderer> ().bounds.size.y;
		 // Remet le fond dépassé au début. Permet une boucle de fond.
		if (transform.position.x < bg.x - (size.x/2)){
			transform.position= new Vector3(positionRestartX,transform.position.y,transform.position.z);
		}
	}
}
