using UnityEngine;
using System.Collections;

public class Spirit : MonoBehaviour {
	AudioSource audioSource;
	public float suggestionTime = 2f;
	public int hiTransformationHealthThreshold = 4;
	public int lowTransformationHealthThreshold = 2;

	void Awake(){
		audioSource = GetComponent<AudioSource>();
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void ShowSuggestion(Suggestion suggestion){
		//TODO: Insert a canvas and show the suggestion on the baloon
		Invoke("HideSuggestion", suggestionTime);
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
		int currentHealth = GameManager.instance.currentHealth;
		if(currentHealth <= lowTransformationHealthThreshold){
			//Low
			Debug.Log("The spirit is going away");
		} else if (currentHealth <= hiTransformationHealthThreshold){
			//Medium
			Debug.Log("The spirit is normal");
		} else {
			//High
			Debug.Log("The spirit is almost reincarnating");
		}
	}


	private void TransformHi(){
		//TODO: implement this
	}
	private void TransformMedium(){
		//TODO: implement this
	}

	private void TransformLow(){
		//TODO: implement this
	}



	public void Die(){
		Debug.Log("The spirit has left us");	
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
