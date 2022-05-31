using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Daylight : MonoBehaviour
{
    public float LightAngle = 130f;
    private Quaternion rot;
    public GameObject directionalLight;
    void Start()
    {
        Invoke("CheckAngle", 2f);
    }

    // Update is called once per frame
    void Update()
    {
        LightAngle -= Time.deltaTime;
        rot = Quaternion.Euler(LightAngle, LightAngle/5f, 0f    );
        directionalLight.transform.rotation = rot;
    }

    private void CheckAngle()
    {
        if (directionalLight.transform.rotation.x < 0)
        {
            Quaternion rotationStart = Quaternion.Euler(130f, 30f, 0f);
            directionalLight.transform.rotation = rotationStart;
            LightAngle = 130f;
        }
        Invoke("CheckAngle", 2f);
    }   
}
