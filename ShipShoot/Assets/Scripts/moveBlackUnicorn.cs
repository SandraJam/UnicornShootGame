using UnityEngine;
using System.Collections;

public class moveBlackUnicorn : MonoBehaviour {
	private Vector2 movement;
	private Vector3 bg;
	private Vector3 hd;
	private Vector3 bd;
	private Vector3 size;
	private float x;
	private float y;
	private float direction;
	private float direction2;
	private bool inWindows = false;

	/*
	 * Initialisation
	 * */
	void Start () {
		bg = Camera.main.ViewportToWorldPoint (new Vector3 (0, 0, 0));
		bd = Camera.main.ViewportToWorldPoint (new Vector3 (1, 0, 0));
		hd = Camera.main.ViewportToWorldPoint (new Vector3 (1, 1, 0));
		movement = new Vector2 (-10f, 0f);
		size.x = gameObject.GetComponent<SpriteRenderer> ().bounds.size.x;
		size.y = gameObject.GetComponent<SpriteRenderer> ().bounds.size.y;
		direction = 0;
	}
	
	/**
	 * Mise a jour a chaque tour
	 * */
	void Update () {
		// Ajoute du mouvement
		GetComponent<Rigidbody2D> ().velocity = movement;
		x = transform.position.x;
		// Permet de verifier si BU ne dépasse pas de l'ecran
		if (x < bd.x - size.x / 2 && x > bg.x + size.x/2){
			inWindows = true;
		}
		// BU rebondit sur les bords de l'écran en changeant de direction.
		if (((x <= bg.x + size.x / 2) || (x >= bd.x - size.x / 2)) && inWindows) {
			inWindows = false;
			movement.x = -movement.x;
			GetComponent<Rigidbody2D> ().velocity = movement;
			direction2 = Random.Range (-0.2f, 0.2f);
			if ((direction2 > 0 && direction < 0) || (direction2 < 0 && direction > 0)){
				direction = direction2;
			}else{
				direction = -direction2;
			}
		}
		y = transform.position.y+direction;
		if ((y > hd.y - size.y / 2)  ||(y < bd.y + size.y / 2)) {
			direction = -direction;
			y = transform.position.y+direction;
		}
		transform.position = new Vector3 (x, y, transform.position.z);
		// Tourne sur lui meme
		transform.Rotate (Vector3.forward * 5);
	}
}
