using UnityEngine;
using System.Collections;

public class Card : MonoBehaviour
{
    public float moveSpeed = 10f;
    public float turnSpeed = 200f;
    bool rotationEnabled = false;
    bool cardRevelead = false;
    Vector3 turnDirection;


    private Quaternion cardHiddenRotation;
    private Quaternion cardRevelaedRotation;
    // Use this for initialization
    void Start()
    {
        cardHiddenRotation = Quaternion.identity;
        cardRevelaedRotation = Quaternion.Euler(0, 180f, 0);
        turnDirection = Vector3.up;
    }


    void OnMouseDown()
    {   
        if(!rotationEnabled)
        rotationEnabled = true;

    }

    bool verifyStopRotation() {
        if (turnDirection == Vector3.up) {
            if (transform.rotation.y >= 0.98f)
            {
                return true;
                transform.rotation = cardRevelaedRotation;
            }
            else { return false; }
        }
        else
        {
            if (transform.rotation.y <= 0.0f)
            {
                return true;
                transform.rotation = cardHiddenRotation;
            }
            else { return false; }
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (rotationEnabled)
        {
             Debug.Log(transform.rotation.y);
            transform.Rotate(turnDirection, turnSpeed * Time.deltaTime);
            if (verifyStopRotation())
            {
                
                turnDirection = -turnDirection;
                rotationEnabled = false;

            }
        }
    }
}
