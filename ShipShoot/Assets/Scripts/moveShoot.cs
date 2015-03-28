using UnityEngine;
using System.Collections;

public class moveShoot : MonoBehaviour {
	private Vector3 bd;
	private Vector3 size;
	private Vector2 movement;

	/**
	 * Initialisation
	 * */
	void Start () {
		size.x = gameObject.GetComponent<SpriteRenderer> ().bounds.size.x;
		size.y = gameObject.GetComponent<SpriteRenderer> ().bounds.size.y;
		bd = Camera.main.ViewportToWorldPoint (new Vector3 (1, 0, 0));
		movement = new Vector2 (8f, 0f);
	}
	
	/**
	 * Mise a jour
	 * */
	void Update () {
		GetComponent<Rigidbody2D> ().velocity = movement;
		// Detruit l'objet si en dehors de l'ecran
		if (transform.position.x + (size.x / 2) > bd.x) {
			Destroy(gameObject);
		}
	}

	void OnTriggerEnter2D( Collider2D collider) {
		// Détruit l'objet et l'ennemi si collision
		if (collider.tag.Equals ("asteroid")) {
			score.Instance.addScorePlayer(100);
			collider.gameObject.AddComponent<fadeOut> ();
			Destroy (gameObject);
		}else
		if (collider.tag.Equals ("blackUnicorn")) {
			score.Instance.addScorePlayer(100);
			score.Instance.touchBlackUnicorn();
			if (score.Instance.getLifeBlackUnicorn() == 0){
				Application.LoadLevel ("scene5-Credits");
			}
			Destroy (gameObject);
		}
	}

}
