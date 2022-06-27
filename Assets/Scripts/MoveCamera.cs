using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            transform.Translate(Vector3.forward * 10f * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.LeftShift))
        {
            transform.Translate(Vector3.back* 10f * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.W))
        {
            Vector3 newEulerAngles = transform.eulerAngles;
            newEulerAngles += Vector3.left * Time.deltaTime * 50f;
            transform.eulerAngles = newEulerAngles;
        }

        if (Input.GetKey(KeyCode.S))
        {
            Vector3 newEulerAngles = transform.eulerAngles;
            newEulerAngles += Vector3.right * Time.deltaTime * 50f;
            transform.eulerAngles = newEulerAngles;
        }

        if (Input.GetKey(KeyCode.A))
        {
            Vector3 newEulerAngles = transform.eulerAngles;
            newEulerAngles += Vector3.down * Time.deltaTime * 100f;
            transform.eulerAngles = newEulerAngles;
        }

        if (Input.GetKey(KeyCode.D))
        {
            Vector3 newEulerAngles = transform.eulerAngles;
            newEulerAngles += Vector3.up * Time.deltaTime * 100f;
            transform.eulerAngles = newEulerAngles;
        }

        if (Input.GetKey(KeyCode.Q))
        {
            Vector3 newEulerAngles = transform.eulerAngles;
            newEulerAngles += Vector3.forward * Time.deltaTime * 100f;
            transform.eulerAngles = newEulerAngles;
        }

        if (Input.GetKey(KeyCode.E))
        {
            Vector3 newEulerAngles = transform.eulerAngles;
            newEulerAngles += Vector3.back * Time.deltaTime * 100f;
            transform.eulerAngles = newEulerAngles;
        }
    }
}
