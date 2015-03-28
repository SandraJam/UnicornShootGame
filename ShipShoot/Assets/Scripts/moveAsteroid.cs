using UnityEngine;
using System.Collections;

public class moveAsteroid : MonoBehaviour {
	private Vector2 movement;
	private Vector3 bg;
	private Vector3 hd;
	private Vector3 bd;
	private Vector3 size;
	private float x;
	private float y;

	/**
	 * Initialisation
	 * */
	void Start () {
		bg = Camera.main.ViewportToWorldPoint (new Vector3 (0, 0, 0));
		bd = Camera.main.ViewportToWorldPoint (new Vector3 (1, 0, 0));
		hd = Camera.main.ViewportToWorldPoint (new Vector3 (1, 1, 0));
		movement = new Vector2 ( Random.Range(-4f, -20f), 0f);
	}
	
	/**
	 * Mise a jour
	 * */
	void Update() {
		size.x = gameObject.GetComponent<SpriteRenderer> ().bounds.size.x;
		size.y = gameObject.GetComponent<SpriteRenderer> ().bounds.size.y;
		// Ajoute du mouvement
		GetComponent<Rigidbody2D> ().velocity = movement;
		// Si en dehors de l'ecran, retour au debut. 
		if (transform.position.x + (size.x / 2) < bg.x) {
			x = (bd.x + (size.x / 2));
			y = Random.Range (bd.y + (size.y / 2), hd.y - (size.y / 2));
			gameObject.transform.position = new Vector3 (x, y, transform.position.z);
			movement = new Vector2 ( Random.Range(-4f, -20f), 0f);
		}
	}

}
