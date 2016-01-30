using UnityEngine;
using System.Collections;

public class MusicSoundManager : MonoBehaviour {
	public AudioSource musicSource;
	public AudioClip gameMusic;

	public void StartMusic(){
		musicSource.clip = gameMusic;
		musicSource.Play();
	}
	public void StopMusic(){
		musicSource.clip = gameMusic;
		musicSource.Stop();
	}
}
