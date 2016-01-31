using UnityEngine;
using System.Collections;

public class Spirit : MonoBehaviour {
	AudioSource audioSource;
	public float suggestionTime = 2f;
	public int hiTransformationHealthThreshold = 4;
	public int lowTransformationHealthThreshold = 2;
	public GameObject lowForm;
	public GameObject mediumForm;
	public GameObject hiForm;
    public Transform oldPosition;
    private Suggestion currentSuggestion;

	void Awake(){
		audioSource = GetComponent<AudioSource>();
	}

	// Use this for initialization
	void Start () {
		Trasnformation();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void ShowSuggestion(Suggestion suggestion){
        //TODO: Insert a canvas and show the suggestion on the baloon
        currentSuggestion = suggestion;
        oldPosition = suggestion.transform;
        suggestion.transform.position = new Vector3(-3, -4, suggestion.transform.position.z);
        Debug.Log("Suggestion invoked in " + suggestion.transform.position.x);
		Invoke("HideSuggestion", suggestionTime);
	}

	public void HideSuggestion(){
        //TODO: Hide the suggestion baloon
        currentSuggestion.gameObject.SetActive(false);
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
			TransformLow();
		} else if (currentHealth <= hiTransformationHealthThreshold){
			//Medium
			Debug.Log("The spirit is normal");
			TransformMedium();
		} else {
			//High
			Debug.Log("The spirit is almost reincarnating");
			TransformHi();
		}
	}


	private void TransformHi(){
		lowForm.SetActive(false);
		mediumForm.SetActive(false);
		hiForm.SetActive(true);

	}
	private void TransformMedium(){
		lowForm.SetActive(false);
		mediumForm.SetActive(true);
		hiForm.SetActive(false);
	}

	private void TransformLow(){
		lowForm.SetActive(true);
		mediumForm.SetActive(false);
		hiForm.SetActive(false);
	}



	public void Die(){
		Debug.Log("The spirit has left us");
		lowForm.SetActive(false);
		mediumForm.SetActive(false);
		hiForm.SetActive(false);
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
