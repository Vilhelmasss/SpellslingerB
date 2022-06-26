using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float movementSpeed;
    [SerializeField] private bool canMove = true;
    private IEnumerable coroutineDash;

    void Update()
    {
        HandleMovementInput();
        HandleRotationInput();
    }

    public bool CanItMove()
    {
        return canMove;
    }

    void CanMove()
    {
        canMove = true; 
    }


    void HandleMovementInput()
    {
        if (canMove)
        {
            float _horizontal = Input.GetAxis("Horizontal");
            float _vertical = Input.GetAxis("Vertical");

            Vector3 _movement = new Vector3(_horizontal, 0, _vertical);
            transform.Translate(_movement * movementSpeed * Time.deltaTime, Space.World);
        }
    }

    void HandleRotationInput()
    {
        RaycastHit _hit;
        Ray _ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(_ray, out _hit))
        {
            transform.LookAt(new Vector3(_hit.point.x, transform.position.y, _hit.point.z));
        }
    }
}