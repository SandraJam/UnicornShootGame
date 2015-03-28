using UnityEngine;
using System.Collections;

public class shootAgain : MonoBehaviour {
	private Vector3 size;
	private Vector3 tmpPos;
	private GameObject gY;

	void Start () {
		size.x = gameObject.GetComponent<SpriteRenderer> ().bounds.size.x;	
		size.y = gameObject.GetComponent<SpriteRenderer> ().bounds.size.y;
	}

	/*
	 * Mise a jour
	 * */
	void Update () {
		int sp2 = Input.touchCount;
		// Si "espace", alors un shoot est créé.
		if (Input.GetKeyDown(KeyCode.Space) || sp2 > 0) {
			Vector3 tmpPos = new Vector3 (transform.position.x + size.x, 
			                             transform.position.y, 
			                             transform.position.z);
			Instantiate (Resources.Load ("shootOrange"), tmpPos, Quaternion.identity);
			sound.Instance.touchButtonSound ();
		}
		// Si "a", alors megashoot
		if ((Input.GetKeyDown (KeyCode.A) || sp2 > 1) && score.Instance.canShoot()) {
			int moins = (int)transform.position.y-2*(int)size.x;
			int plus = (int)transform.position.y+2*(int)size.x;
			for (int i= moins; i <= plus; i++){
				tmpPos = new Vector3 (transform.position.x + size.x, 
				                     i, 
				                      transform.position.z);
				gY = Instantiate (Resources.Load ("corne"), tmpPos, Quaternion.identity) as GameObject;
				gY.AddComponent<moveShoot>();
			}
			sound.Instance.touchButtonSound ();
		}
	}
}