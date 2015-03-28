using System;
using UnityEngine;
using System.Collections;

public class moveShip : MonoBehaviour {
	private float vitesse;
	private float x;
	private float y;
	private Vector3 size;
	private Vector3 bg;
	private Vector3 hd;
	private Vector3 bd;
	private DateTime lastShoot;

	/**
	 * Initialisation
	 * */
	void Start () {
		vitesse = 0.5f;
		size.x = gameObject.GetComponent<SpriteRenderer> ().bounds.size.x;
		size.y = gameObject.GetComponent<SpriteRenderer> ().bounds.size.y;
		bg = Camera.main.ViewportToWorldPoint (new Vector3 (0, 0, 0));
		bd = Camera.main.ViewportToWorldPoint (new Vector3 (1, 0, 0));
		hd = Camera.main.ViewportToWorldPoint (new Vector3 (1, 1, 0));
		lastShoot = DateTime.Now;
	}

	/**
	 * Deplace le vaisseau
	 * */
	void Update() {
		x = transform.position.x + Input.GetAxis ("Horizontal") * vitesse;
		y = transform.position.y + Input.GetAxis ("Vertical") * vitesse;
		if (x > bd.x - size.x / 2)
			x = bd.x - size.x / 2;
		if (x < bg.x + size.x / 2)
			x = bg.x + size.x / 2;
		if (y > hd.y - size.y / 2)
			y = hd.y - size.y / 2;
		if (y < bd.y + size.y / 2)
			y = bd.y + size.y / 2;

		transform.position = new Vector3 (x, y, transform.position.z);

	}

	/**
	 * Verifie les collisions avec des ennemis 
	 * */
	void OnTriggerEnter2D(Collider2D other) {
		long delta = (long)((TimeSpan)(DateTime.Now - lastShoot)).TotalSeconds;
		if ((other.tag.Equals ("asteroid") || other.tag.Equals ("blackUnicorn") || other.tag.Equals ("blueShoot")) && (delta > 0.5)) {
			lastShoot = DateTime.Now;
			if (GameObject.FindGameObjectWithTag ("life1"))	  	  
				GameObject.FindGameObjectWithTag ("life1").AddComponent<fadeOut> ();
			else if (GameObject.FindGameObjectWithTag ("life2"))
				GameObject.FindGameObjectWithTag ("life2").AddComponent<fadeOut> ();
			else if (GameObject.FindGameObjectWithTag ("life3"))
				GameObject.FindGameObjectWithTag ("life3").AddComponent<fadeOut> ();
			else if (GameObject.FindGameObjectWithTag ("life4"))
				GameObject.FindGameObjectWithTag ("life4").AddComponent<fadeOut> ();
			else if (GameObject.FindGameObjectWithTag ("life5")) {
				GameObject.FindGameObjectWithTag ("life5").AddComponent<fadeOut> ();
				Destroy (gameObject);
				Application.LoadLevel ("scene4-Fin");
			}
		} else if (other.tag.Equals ("hurt")) {
			// Recupere le bonus
			score.Instance.ajoutShoot();
			Destroy(other.gameObject);
		}
	}
}
