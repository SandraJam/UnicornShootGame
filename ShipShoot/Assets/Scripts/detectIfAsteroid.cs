using UnityEngine;
using System.Collections;

public class detectIfAsteroid : MonoBehaviour {
	private Vector3 hd;
	private Vector3 bd;
	private Vector3 size;
	private Vector3 tmpPos;
	private GameObject[] respawns;

	/**
	 * Initialisation
	 **/
	void Start () {
		bd = Camera.main.ViewportToWorldPoint (new Vector3 (1, 0, 0));
		hd = Camera.main.ViewportToWorldPoint (new Vector3 (1, 1, 0));
	}

	/**
	 * Mise a jour a chaque tour
	 **/
	void Update () {

		// Si score 5000 dépassé alors le boss apparait: Black Unicorn
		if (score.Instance.getScorePlayer () > 5000 && score.Instance.getScorePlayer () < 6000) {
			score.Instance.addScorePlayer(1000);
			// Supprime les Asteroids 
			respawns = GameObject.FindGameObjectsWithTag ("asteroid");
			foreach(GameObject res in respawns){
				res.gameObject.AddComponent<fadeOut> ();
			}
			// Place BL et joue sa musique d'introduction
			tmpPos = new Vector3 (bd.x + (size.x / 2),
						                  Random.Range (bd.y + (size.y / 2), hd.y - (size.y / 2)),
						                   transform.position.z);
			Instantiate (Resources.Load ("blackUnicorn"), tmpPos, Quaternion.identity);
			sound.Instance.goBadUnicorn();
		} else if (score.Instance.getScorePlayer () < 5000) {
			respawns = GameObject.FindGameObjectsWithTag ("asteroid");
			// Recupere la taille de l'objet
			if (respawns.Length > 0) {
				size.x = respawns [0].GetComponent<SpriteRenderer> ().bounds.size.x;
				size.y = respawns [0].GetComponent<SpriteRenderer> ().bounds.size.y;
			}
			// Verifie le nombre d'ennemi. Ajoute si trop peu.
			if (respawns.Length < 7) {
				if (Random.Range (1, 100) == 50 || respawns.Length < 4) {
					tmpPos = new Vector3 (bd.x + (size.x / 2),
					                              Random.Range (bd.y + (size.y / 2), hd.y - (size.y / 2)),
					                             transform.position.z);
					Instantiate (Resources.Load ("asteroid"), tmpPos, Quaternion.identity);
				}
			}
		}
		// Créer une corne de MegaShoot
		if (Random.Range (1, 800) == 2) {
			tmpPos = new Vector3 (bd.x + (size.x / 2),
			                      Random.Range (bd.y + (size.y / 2), hd.y - (size.y / 2)),
			                      transform.position.z);
			GameObject gY = Instantiate (Resources.Load ("corne"), tmpPos, Quaternion.identity) as GameObject;
			gY.AddComponent<moveAsteroid>();
		}
	}
}
