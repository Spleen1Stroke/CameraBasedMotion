using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCameraScript : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody mainCameraRigidbody;
    void Start()
    {
        mainCameraRigidbody = GetComponent<Rigidbody>();
        transform.localPosition = new Vector3(0, 0, -CameraCenterScript.cameraDistanceFromCenter);

    }

    // Update is called once per frame
    void Update()
    {
        //transform.localPosition = new Vector3(0, 0, -CameraCenterScript.cameraDistanceFromCenter);
    }
    void FixedUpdate()
    {
        //transform.localPosition = new Vector3(0, 0, -CameraCenterScript.cameraDistanceFromCenter);
    }
}
