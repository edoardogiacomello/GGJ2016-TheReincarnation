using UnityEngine;
using System.Collections;

public class Item : MonoBehaviour, IItem {

	private Vector3 startingPosition;
    private Ray ray;
    private Vector3 rayPoint;

	public bool isItemOverCalduron = false;
	public bool isItemOverOtherItems = false;

    private IItem itemCollided;
     
	void Start(){
		startingPosition = transform.position;
	}

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

  
	void OnMouseDrag(){
		if(GameManager.instance.isDragEnabled){
			float distance = Vector3.Distance(Camera.main.transform.position, startingPosition);
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			Vector3 newPosition = new Vector3(ray.GetPoint(distance).x,ray.GetPoint(distance).y,0f);


			transform.position = newPosition;
		}
			
			
	}



    /// <summary>
    /// Action performed when the mouse/finger is removed from the object
    /// </summary>
    void OnMouseUp()
    {
        if (isItemOverCalduron)
        {
            gameObject.SetActive(false);
            GameManager.instance.stageManager.OnItemPlacement(this);
            // TODO move the object outside the scene
        }
        else if (isItemOverOtherItems)
        {
            IItem sumOfItem = GameManager.instance.combinationManager.Combine(this, itemCollided);
            if (sumOfItem != null)
            {
                // both items exists, disable them
                gameObject.SetActive(false);
                itemCollided.GameObject().SetActive(false);
            }
            else {
                GameManager.instance.WrongCombination();
                ResetPosition();
            }
            
            
            
            // TODO move both objects outside the scene (using itemCollided for the other one)

        }
        else {
            // return the object to the starting position
            ResetPosition();
        }

        // remove the object from the manager (set null)
        GameManager.instance.currentDraggedItem = null;
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
            itemCollided = other.gameObject.GetComponent<Item>();
        } else {
            isItemOverCalduron = false;
            isItemOverOtherItems = false;
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
		transform.position = startingPosition;
    }

    
}
