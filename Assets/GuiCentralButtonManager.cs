using UnityEngine;
using System.Collections;

public class GuiCentralButtonManager : MonoBehaviour {
	public SpriteRenderer chestIcon;
	public bool enabled = true;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void setItem(IItem item){
		if (item == null){
			chestIcon.enabled = true;
		} else {
			chestIcon.enabled = false;
			item.GameObject().transform.position = this.transform.position;
		}
	}
}
