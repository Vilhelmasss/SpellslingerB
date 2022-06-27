using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    [Header("Horizontal Speed")]
    public GameObject lookAtObject;
    public float minSpeedHorizontal = 0f;
    public float maxSpeedHorizontal = 30f;
    public float incrementSpeedHorizontal = 2f;
    public float movSpeedHorizontal = 10f;
    public KeyCode horizontalIncrease;
    public KeyCode horizontalDecrease;

    [Header("Vertical Speed")]
    public float minSpeedVertical = 0f;
    public float maxSpeedVertical = 30f;
    public float incrementSpeedVertical = 2f;
    public float movSpeedVertical = 10f;
    public KeyCode verticalIncrease;
    public KeyCode verticalDecrease;

    [Header("Distance To LookAt Speed")]
    public float minSpeedDistance = 0f;
    public float maxSpeedDistance = 30f;
    public float incrementSpeedDistance = 2f;
    public float movSpeedDistance = 10f;
    public KeyCode distanceIncrease;
    public KeyCode distanceDecrease;

    void Update()
    {
        if (Input.GetKeyDown(horizontalIncrease))
        {
            movSpeedHorizontal += incrementSpeedHorizontal;
            if (movSpeedHorizontal > maxSpeedHorizontal)
            {
                movSpeedHorizontal = maxSpeedHorizontal;
            }
        }
        if (Input.GetKeyDown(horizontalDecrease))
        {
            movSpeedHorizontal -= incrementSpeedHorizontal;
            if (movSpeedHorizontal < minSpeedHorizontal)
            {
                movSpeedHorizontal = minSpeedHorizontal;
            }
        }

        if (Input.GetKeyDown(verticalIncrease))
        {
            movSpeedVertical += incrementSpeedVertical;
            if (movSpeedVertical > maxSpeedVertical)
            {
                movSpeedVertical = maxSpeedVertical;
            }
        }
        if (Input.GetKeyDown(verticalDecrease))
        {
            movSpeedVertical -= incrementSpeedVertical;
            if (movSpeedVertical < minSpeedVertical)
            {
                movSpeedVertical = minSpeedVertical;
            }
        }

        if (Input.GetKeyDown(distanceIncrease))
        {
            movSpeedDistance += incrementSpeedDistance;
            if (movSpeedDistance > maxSpeedDistance)
            {
                movSpeedDistance = maxSpeedDistance;
            }
        }
        if (Input.GetKeyDown(distanceDecrease))
        {
            movSpeedDistance -= incrementSpeedDistance;
            if (movSpeedDistance < minSpeedDistance)
            {
                movSpeedDistance = minSpeedDistance;
            }
        }
    }

    void FixedUpdate()
    {
        transform.LookAt(lookAtObject.transform);

        if (Input.GetKey(KeyCode.Mouse0))
        {
            transform.Translate(Vector3.forward * movSpeedDistance * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.Mouse1))
        {
            transform.Translate(Vector3.back* movSpeedDistance * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * movSpeedHorizontal * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * movSpeedHorizontal * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.up * movSpeedVertical * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.down * movSpeedVertical * Time.deltaTime);
        }
    }
}
