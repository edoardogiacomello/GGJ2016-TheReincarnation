using UnityEngine;
using System.Collections;

public class GuiStartButtonManager : MonoBehaviour {

    public SpriteRenderer spriteRenderer; 
    public Sprite startIcon;
    public Sprite hourglassIcon;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void changeIcon() {
        if (spriteRenderer.sprite.Equals(startIcon))
        {
            spriteRenderer.sprite = hourglassIcon;
        }
        else {
            spriteRenderer.sprite = startIcon;
        }
    }
}
