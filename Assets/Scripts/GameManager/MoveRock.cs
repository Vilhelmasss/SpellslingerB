using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveRock : MonoBehaviour
{
    // Transforms to act as start and end markers for the journey.
    public Transform startMarker;
    public Transform endMarker;

    public GameObject rockToMove;

    public bool moveRock;

    public bool moveNow;
    // Movement speed in units per second.
    public float speed = 1.0F;

    // Time when the movement started.
    private float startTime;

    // Total distance between the markers.
    private float journeyLength;


    [SerializeField] private KeyCode moveRockKey;
    void Start()
    {
        moveRock = false;


    }

    void Update()
    {
        if (Input.GetKeyDown(moveRockKey))
        {
            moveRock = !moveRock;
//            Invoke("SwapMarkers", 4f);
        }
    }

    private void SwapMarkers()
    {
        Transform tempTrans;
//        tempTrans.position = startMarker.position;
        startMarker = endMarker;
        endMarker = startMarker;
    }

    void FixedUpdate()
    {
        if (moveRock)
        {

            startTime = Time.time;

            // Calculate the journey length.
            journeyLength = Vector3.Distance(startMarker.position, endMarker.position);
            moveNow = true;
            moveRock = false;
        }

        if (moveNow)
        {
            float distCovered = (Time.time - startTime) * speed;
            float fractionOfJourney = distCovered / journeyLength;
            rockToMove.transform.position = Vector3.Lerp(startMarker.position, endMarker.position, fractionOfJourney);
        }
    }
}
