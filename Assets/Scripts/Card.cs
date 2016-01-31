using UnityEngine;
using System.Collections;

public class Card : MonoBehaviour
{
    public float moveSpeed = 10f;
    public float turnSpeed = 200f;
    bool rotationEnabled = false;
    Vector3 turnDirection;


    private Quaternion cardHiddenRotation;
    private Quaternion cardRevelaedRotation;
    private AudioSource audioSrc;
    // Use this for initialization
    void Start()
    {
        cardHiddenRotation = Quaternion.identity;
        cardRevelaedRotation = Quaternion.Euler(0, 180f, 0);
        turnDirection = Vector3.up;
        audioSrc = GetComponent<AudioSource>();
    }


    void OnMouseDown()
    {   
        if(!rotationEnabled)
        rotationEnabled = true;
        audioSrc.Play();

    }

    bool verifyStopRotation() {
        if (turnDirection == Vector3.up) {
            if (transform.rotation.y >= 0.98f)
            {
                transform.rotation = cardRevelaedRotation;
                return true;
                
            }
            else { return false; }
        }
        else
        {
            if (transform.rotation.y <= 0.0f)
            {
                transform.rotation = cardHiddenRotation;
                return true;
                
            }
            else { return false; }
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (rotationEnabled)
        {
            transform.Rotate(turnDirection, turnSpeed * Time.deltaTime);
            if (verifyStopRotation())
            {
                
                turnDirection = -turnDirection;
                rotationEnabled = false;

            }
        }
    }
}
