using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
	public static GameManager instance;
	public StageManager stageManager;
    public CombinationManager combinationManager;

    //Game Variables
    public int maxHealth;
	public int currentHealth;
	public int healthLossOnStageFailure;


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
		currentHealth = maxHealth;
		if (stageManager == null) Debug.Log("Warning: please attach a StageManager component to the GameManager object");

	}

	public void OnGameStart(){
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
		if(!IsDead()) {
			stageManager.StartNextStage();
		} else {
			GameLost();
		}
	}

	/// <summary>
	/// Called when the current Stage is Passed
	/// </summary>
	public void StageSucceded(){
		EnableDrag(false);
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
	}

	public void GameLost(){
		EnableDrag(false);
		Debug.Log("You have lost the game");
	}

	void EnableDrag(bool isEnabled){
		GameManager.instance.isDragEnabled = isEnabled;
	}

    public void WrongCombination() {
        Debug.Log("Wrong Combination");
        // TODO wrong combination 
    }

}
