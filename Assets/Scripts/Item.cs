using UnityEngine;
using System.Collections;

public class Item : MonoBehaviour, IItem {

    private float startingPosition;
    private Ray ray;
    private Vector3 rayPoint;

    private bool isItemOverCalduron = false;
    private bool isItemOverOtherItems = false;

    private GameObject itemCollided;
    private 

    /// <summary>
    /// Action performed when hovering the object
    /// </summary>
    void OnMouseEnter()
    {
        // TODO: put the hovering around
    }

    /// <summary>
    /// Action performed when removing the focus from the object
    /// </summary>
    void OnMouseExit()
    {
        // TODO : remove hovering 
    }

    /// <summary>
    /// Action performed when the object is clicked
    /// </summary>
    void OnMouseDown()
    {
        startingPosition = Vector3.Distance(transform.position, Camera.main.transform.position);
        GameManager.instance.isDragEnabled = true;
        // save the object in the manager
        GameManager.instance.currentDraggedItem = this;
    }

    /// <summary>
    /// Action performed when the mouse/finger is removed from the object
    /// </summary>
    void OnMouseUp()
    {
        GameManager.instance.isDragEnabled = false;
        if (isItemOverCalduron)
        {
            gameObject.SetActive(false);
            GameManager.instance.stageManager.OnItemPlacement(this);
            // TODO move the object outside the scene
        }
        else if (isItemOverOtherItems)
        {
            gameObject.SetActive(false);
            // TODO move both objects outside the scene (using itemCollided for the other one)

        }
        else {
            // return the object to the starting position
            ResetPosition();
        }

        // remove the object from the manager (set null)
        GameManager.instance.currentDraggedItem = null;
    }

    // Use this for initialization
    void Start () {
	
	}

    /// <summary>
    /// Checks if an item is colliding with the Calduron or other Items, setting the corresponding flag if true
    /// </summary>
    /// <param name="other"></param>

    void OnTriggerStay2D(Collider2D other) {

        if (other.gameObject.tag.Equals("Calduron")) {
            isItemOverCalduron = true;
        }
        else if (other.gameObject.tag.Equals("Item")){
            isItemOverOtherItems = true;
            // save the game object reference to remove the item from the scene
            itemCollided = other.gameObject;
        } else {
            isItemOverCalduron = false;
            isItemOverOtherItems = false;
        }
    }

	// Update is called once per frame
	void Update () {

        if (GameManager.instance.isDragEnabled)
        {
            // compute the ray with respect to the camera position
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            // get the vector of the distance
            rayPoint = ray.GetPoint(startingPosition);
            // set the new position of the object
            transform.position = rayPoint;
        }
    }


	public GameObject GameObject ()
	{
		return gameObject;
	}

    /// <summary>
    /// If not hovering over other objects when released, return the object to the position saved when clicked
    /// </summary>

    public void ResetPosition() {
        // TODO reset position
    }

    
}
