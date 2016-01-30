using UnityEngine;
using System.Collections;

public class Spirit : MonoBehaviour {
	AudioSource audioSource;

	void Awake(){
		audioSource = GetComponent<AudioSource>();
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void ShowSuggestion(Suggestion suggestion, float time){
		//TODO: Insert a canvas and show the suggestion on the baloon
		Invoke("HideSuggestion", time);
	}

	public void HideSuggestion(){
		//TODO: Hide the suggestion baloon
	}

	public void RegainHealth(){
		PlayRegainHealthSound();
	}

	public void LoseHealth(){
		PlayLoseHealthSound();
	}
	public void Idle(){
		PlayIdleSound();
	}

	public void Trasnformation(){
		PlayTransformationSound();
	}

	public void PlayRegainHealthSound(){
		audioSource.PlayOneShot(GameManager.instance.globalSoundManager.spiritSoundManager.spiritRegain);
	}

	public void PlayLoseHealthSound(){
		audioSource.PlayOneShot(GameManager.instance.globalSoundManager.spiritSoundManager.spiritVanishing);
	}

	public void PlayIdleSound(){
		audioSource.loop = true;
		audioSource.clip = GameManager.instance.globalSoundManager.spiritSoundManager.spiritIdle;
		audioSource.Play();

	}

	public void PlayTransformationSound(){
		audioSource.PlayOneShot(GameManager.instance.globalSoundManager.spiritSoundManager.spiritTransformation);
	}


}
