using UnityEngine;
using System.Collections;

public class score : MonoBehaviour {
	public static score Instance;
	private int scorePlayer = 0;
	private int lifeBlackUnicorn= 50;
	private bool canMegaShoot = false;

	/**
	 * Initialisation
	 * */
	void Start () {
		if (Instance == null) {
			Instance = this;
			DontDestroyOnLoad (Instance.gameObject);
		}
		else if (this != Instance) {
			Destroy (this.gameObject);
		}
	}
	
	/**
	 * Affiche le score
	 * */
	void Update () {
		GameObject[] respawns = GameObject.FindGameObjectsWithTag ("scoreText");
		if (respawns.Length != 0)
			GameObject.FindWithTag("scoreText").GetComponent<GUIText>().text = ""+scorePlayer;
	}

	/**
	 * Ajoute des points au score
	 * */
	public void addScorePlayer(int toAdd) {
		scorePlayer += toAdd;
	}

	/**
	 * Retourne le score courant
	 * */
	public int getScorePlayer(){
		return scorePlayer;
	}

	/**
	 * Remet le score a zero
	 * */
	public void debutPartie(){
		scorePlayer = 0;
	}

	/**
	 * Toucher le Boss
	 * */
	public void touchBlackUnicorn(){
		lifeBlackUnicorn --;
	}

	/**
	 * Remet le score d'une Black Licorne au début
	 * */
	public void debutUnicorn(){
		lifeBlackUnicorn = 50;
	}

	/**
	 * Retourne la vie du Boss
	 * */
	public int getLifeBlackUnicorn(){
		return lifeBlackUnicorn;
	}

	/**
	 * Puis-je lancer une multitude de cornes?
	 * */
	public bool canShoot(){
		bool tmp = canMegaShoot;
		canMegaShoot = false;
		return tmp;
	}

	/**
	 * Ajout du megashoot
	 * */
	public void ajoutShoot(){
		canMegaShoot = true;
	}
}
