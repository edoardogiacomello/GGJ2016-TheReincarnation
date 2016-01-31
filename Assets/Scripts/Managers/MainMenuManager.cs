using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour {
    public static MainMenuManager instance;
  
    void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }
    void Start () {
	
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
