using UnityEngine;
using System.Collections;

public class sound : MonoBehaviour {
	public static sound Instance;
	public AudioClip playerShotSound;
	public AudioClip fondMusical;
	public AudioClip badUnicorn;
	public AudioClip horse;

	/**
	 * Initialisation de la musique de Fond
	 * */
	void Start () {
		if (Instance == null) {
			Instance = this;
			MakeSound(fondMusical);
		}
		else if (this != Instance) {
			Destroy (this.gameObject);
		}
		DontDestroyOnLoad (Instance.gameObject);
	}

	/**
	 * Mise a jour: relance la musique si changement de scene
	 * */
	void Update () {
		if (!GetComponent<AudioSource> ().isPlaying) {
			GetComponent<AudioSource> ().Play();
		}
	}
	/**
	 * Pour l'arrivée du boss
	 * */
	public void goBadUnicorn(){
		MakeSound (badUnicorn);
	}
	/**
	 * Pour le shoot
	 * */
	public void touchButtonSound() {
		MakeSound(playerShotSound);
	}

	/**
	 * Pour le bouton de menu
	 * */
	public void touchButtonMenuSound() {
		MakeSound(horse);
	}

	/**
	 * Joue le son demandé
	 * */
	private void MakeSound(AudioClip originalClip) {
		GetComponent<AudioSource> ().PlayOneShot (originalClip);
	}
}
