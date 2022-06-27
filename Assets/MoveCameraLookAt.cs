using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCameraLookAt : MonoBehaviour
{

    public float movementSpeed = 3f;

    // Update is called once per frame
    void Update()
    {
        HandleMovementInput();
    }

    void HandleMovementInput()
    {
        float _horizontal = 0f;
        float _vertical = 0f;

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            _horizontal = -1;
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            _horizontal = 1;
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            _vertical = 1;
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            _vertical = -1;
        }



        Vector3 _movement = new Vector3(_horizontal, 0, _vertical);
        transform.Translate(_movement * movementSpeed * Time.deltaTime, Space.World);

    }
}
