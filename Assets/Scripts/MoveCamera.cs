using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    public GameObject lookAtObject;

    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.LookAt(lookAtObject.transform);
        if (Input.GetKey(KeyCode.Mouse0))
        {
            transform.Translate(Vector3.forward * 10f * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.Mouse1))
        {
            transform.Translate(Vector3.back* 10f * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * 10f * Time.deltaTime);

        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * 10f * Time.deltaTime);

        }

        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.up * 10f * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.down * 10f * Time.deltaTime);
        }

//        if (Input.GetKey(KeyCode.W))
//        {
//            Vector3 newEulerAngles = transform.eulerAngles;
//            newEulerAngles += Vector3.left * Time.deltaTime * 50f;
//            transform.eulerAngles = newEulerAngles;
//        }
//
//        if (Input.GetKey(KeyCode.S))
//        {
//            Vector3 newEulerAngles = transform.eulerAngles;
//            newEulerAngles += Vector3.right * Time.deltaTime * 50f;
//            transform.eulerAngles = newEulerAngles;
//        }
//
//        if (Input.GetKey(KeyCode.A))
//        {
//            Vector3 newEulerAngles = transform.eulerAngles;
//            newEulerAngles += Vector3.down * Time.deltaTime * 100f;
//            transform.eulerAngles = newEulerAngles;
//        }
//
//        if (Input.GetKey(KeyCode.D))
//        {
//            Vector3 newEulerAngles = transform.eulerAngles;
//            newEulerAngles += Vector3.up * Time.deltaTime * 100f;
//            transform.eulerAngles = newEulerAngles;
//        }

//        if (Input.GetKey(KeyCode.Mouse0))
//        {
//            Vector3 newEulerAngles = transform.eulerAngles;
//            newEulerAngles += Vector3.forward * Time.deltaTime * 100f;
//            transform.eulerAngles = newEulerAngles;
//        }

//        if (Input.GetKey(KeyCode.Mouse1))
//        {
//            Vector3 newEulerAngles = transform.eulerAngles;
//            newEulerAngles += Vector3.back * Time.deltaTime * 100f;
//            transform.eulerAngles = newEulerAngles;
//        }

    }
}
