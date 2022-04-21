using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 playerVelocity;
    private bool groundedPlayer;
    private float playerSpeed = 10.0f;


    private void Start()
    {
        controller = gameObject.AddComponent<CharacterController>();
    }

    void Update()
    {
        if (Input.GetKeyDown("A"))
        {
            Vector3 mov = new Vector3(playerSpeed * Time.deltaTime, 0f, 0f);
            gameObject.transform.forward += mov;
        }
        
    }
}