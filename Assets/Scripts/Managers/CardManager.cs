using UnityEngine;
using System.Collections;

public class CardManager : MonoBehaviour {
    public static CardManager instance;
    public float transitionDuration;
    public Transform[] setPositions ;
    private int actualSet;
    private float cameraZValue;
    private bool inSlide;

    //per lo sweep
    private Vector3 startPosition = Vector3.zero;
    private Vector3 endPosition = Vector3.zero;
    public float sweepMinDistance;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    void Start () {
        actualSet = 0;
        cameraZValue = Camera.main.transform.position.z;
        inSlide = false;
    }


    void Update()
    {
        if (Input.GetMouseButtonDown(0)) { 
        startPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Debug.Log("start" + startPosition);
        }
        if (Input.GetMouseButtonUp(0))
        {
            endPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Debug.Log("end" + endPosition);
            if (startPosition != endPosition && startPosition != Vector3.zero && endPosition != Vector3.zero)
            {
                float deltaX = endPosition.x - startPosition.x;
                float deltaY = endPosition.y - startPosition.y;
                if ((deltaX > sweepMinDistance || deltaX < -sweepMinDistance) && (deltaY >= -sweepMinDistance || deltaY <= sweepMinDistance))
                {
                    if (startPosition.x < endPosition.x) // swipe LTR
                    {
                        PreviousCardSet();
                    }
                    else // swipe RTL
                    {
                        NextCardSet();
                    }
                }
                startPosition = endPosition = Vector3.zero;
            }
        }
    }



 

    public void NextCardSet()
    {
        if (!inSlide) {
            inSlide = true;
            int newSetPos;
            if (actualSet == setPositions.Length - 1)
            {
                newSetPos = 0;
            }
            else {
                newSetPos = actualSet + 1;
            }
            Debug.Log(actualSet + " " + newSetPos);
            StartCoroutine(CardTransition(newSetPos));
        }
    }

    public void PreviousCardSet()
    {
    if (!inSlide) {
            inSlide = true;
        int newSetPos;
        if (actualSet == 0)
            {
                newSetPos = setPositions.Length - 1;
            }
            else {
                newSetPos = actualSet - 1;
            }
            StartCoroutine(CardTransition(newSetPos));
        }
    }


    IEnumerator CardTransition(int newSetPos)
    {
        float t = 0.0f;
        Vector3 learpedPos;
        Vector3 startingPos = setPositions[actualSet].position;
        while (t < 1.0f)
        {
            t += Time.deltaTime * (Time.timeScale / transitionDuration);
            learpedPos = Vector3.Lerp(startingPos, setPositions[newSetPos].position, t);
            Camera.main.transform.position = new Vector3(learpedPos.x, learpedPos.y, cameraZValue);
            yield return 0;

        }
        actualSet = newSetPos;
        inSlide = false;
    }

}