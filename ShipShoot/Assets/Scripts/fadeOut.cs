using UnityEngine;
using System.Collections;

public class fadeOut : MonoBehaviour {

	void Start () {
	
	}
	
	/**
	 * Efface l'objet avant de le detruire
	 * */
	void Update () {
		Color cl = GetComponent<SpriteRenderer> ().color;
		cl.a -= 0.08f;
		GetComponent<SpriteRenderer>().color = cl;
		if (cl.a<0){
			Destroy(gameObject);
		}
	}
}
