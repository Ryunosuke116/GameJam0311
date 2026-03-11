using UnityEngine;
using System.Collections;

public class RandamRotation : MonoBehaviour
{

  
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        const float rotationMax = 360.0f;
        const float rotationMin = 0.0f;
        Vector3 rotation;
        rotation.z = Random.Range(rotationMin, rotationMax);
       transform.localEulerAngles = new Vector3(0, 0, rotation.z);
        
    }

    // Update is called once per frame
    void Update()
    {
    }
}
