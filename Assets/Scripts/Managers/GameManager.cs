using UnityEngine;
using System.Collections;
using ProgressBar;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
	public static GameManager instance;
	public StageManager stageManager;
    public CombinationManager combinationManager;
	public GlobalSoundManager globalSoundManager;
	public Spirit spirit;


	//GUI reference
	public GuiCentralButtonManager buttonManager;
    public GuiStartButtonManager startButtonManager;
	public Transform suggestionButton;
    public GameObject youWinLabel;
    public GameObject youLoseLabel;

 	//Progress Bar
    public ProgressRadialBehaviour progressBar;	

    //Game Variables
	public int maxHealth = 6;
	public int startingHealth = 3;
	public int currentHealth;
	public int healthLossOnStageFailure = 1;


	//Item Drag Variables
	public bool isDragEnabled;
	public IItem currentDraggedItem;

	void Awake() {
        
		if (instance == null)
			instance = this;
		else
			Destroy(gameObject);
	}

	void Start(){
		currentHealth = startingHealth;
		if (stageManager == null) Debug.Log("Warning: please attach a StageManager component to the GameManager object");

		//Starting the background music
		globalSoundManager.musicSoundManager.StartMusic();
	}

	public void OnGameStart(){
		spirit.Idle();
        startButtonManager.changeIcon();
		stageManager.StartNextStage();
	}

	/// <summary>
	/// Called when the Current Stage Time is Over.
	/// </summary>
	/// <param name="stage">Stage.</param>
	public void OnStageTimeOut(Stage stage){
		Debug.Log("The stage is over!");
		StageFailed();
	}

	/// <summary>
	/// Called when the current stage is failed
	/// </summary>
	public void StageFailed(){
		EnableDrag(false);
		currentHealth -= healthLossOnStageFailure;
		spirit.LoseHealth();
		spirit.Trasnformation();
		if(!IsDead()) {
			stageManager.StartNextStage();
		} else {
			GameLost();
		}
	}

	/// <summary>
	/// It's like StageFailed but does not skip to the next stage
	/// </summary>
	public void DropHealth(){
		EnableDrag(false);
		currentHealth -= healthLossOnStageFailure;
		spirit.LoseHealth();
		spirit.Trasnformation();
		if(IsDead()) {
			GameLost();
		}
	}
	

	/// <summary>
	/// Called when the current Stage is Passed
	/// </summary>
	public void StageSucceded(){
		EnableDrag(false);
		currentHealth += healthLossOnStageFailure;
		if (currentHealth > maxHealth) currentHealth = maxHealth;
		spirit.RegainHealth();
		spirit.Trasnformation();
		stageManager.StartNextStage();
	}

	public bool IsDead(){
		return (currentHealth<=0);
	}

	/// <summary>
	///Called when there are no more stages to accomplish.
	/// </summary>
	public void GameFinished(){
		//Note that if the game finishes, then there are no more stage to accompish, so the game is won.
		EnableDrag(false);
		Debug.Log("You have won the game");
        youWinLabel.SetActive(true);
        Invoke("MetodoNormale", 3);
        
    }

    public void MetodoNormale() {
        SceneManager.LoadScene("MainMenu");
    }

	public void GameLost(){
		EnableDrag(false);
		spirit.Die();
		Debug.Log("You have lost the game");
        youLoseLabel.SetActive(true);
        Invoke("MetodoNormale", 3);
    }

	void EnableDrag(bool isEnabled){
		GameManager.instance.isDragEnabled = isEnabled;
	}

    public void WrongCombination() {
        Debug.Log("Wrong Combination");
        // TODO wrong combination 
    }

}
