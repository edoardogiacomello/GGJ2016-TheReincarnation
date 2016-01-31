using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour {
    public static MainMenuManager instance;
    public Button[] startButton;
    public Button[] gameButton;
  
    void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }
    void Start () {
	
	}
    public void seeGameButton() {
        foreach ( Button b in startButton)
        {
            b.gameObject.SetActive(false);
        }
        foreach (Button bb in gameButton)
        {
            bb.gameObject.SetActive(true);
        }
    }

    public void seeStartButton()
    {
        foreach (Button b in gameButton)
        {
            b.gameObject.SetActive(false);
        }
        foreach (Button bb in startButton)
        {
            bb.gameObject.SetActive(true);
        }
    }


    public void GoToLevel(string levelName)
    {
        if (levelName == "exitgame")
        {
            Application.Quit();
        }
        else {
            SceneManager.LoadScene(levelName);
        }

        
    }

}
