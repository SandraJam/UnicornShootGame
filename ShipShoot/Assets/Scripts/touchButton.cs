using UnityEngine;
using System.Collections;

public class touchButton : MonoBehaviour {

	void Start () {
	
	}
	
	/**
	 * Mise a jour: Si appui, lancement du jeu
	 * */
	void Update () {
		if (Input.touchCount > 0) {
			sound.Instance.touchButtonMenuSound();
			Invoke ("goScene3", 0.88f);
		} else if (Input.GetMouseButtonDown(0)){
			sound.Instance.touchButtonMenuSound();
			Invoke ("goScene3", 0.88f);
		}
	}

	/*
	 * Passage a la scene de jeu
	 * */
	void goScene3(){
		Application.LoadLevel ("scene3-Jeu");
		score.Instance.debutPartie();
		score.Instance.debutUnicorn();
	}
}
