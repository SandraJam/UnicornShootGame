using UnityEngine;
using System.Collections;

public class wait2sec : MonoBehaviour {
	
	void Start () {
	
	}
	
	/*
	 * Logo du début
	 * */
	void Update () {
		Invoke ("goScene2", 1.5f);
	}

	/*
	 * Passe a la scene de Menu
	 * */
	void goScene2(){
		Application.LoadLevel ("scene2-Menu");
	}
}
