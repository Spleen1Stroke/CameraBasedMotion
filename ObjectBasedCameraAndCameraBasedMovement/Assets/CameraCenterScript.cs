using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCenterScript : MonoBehaviour
{
    // Start is called before the first frame update
    public static Vector3 cameraCenterRotation = new Vector3(40, 0, 0);
    Vector3 cameraSpeed = new Vector3(60, 60, 60);
    public static float cameraDistanceFromCenter = 20;
    public static Vector3 cameraCenterPosition = new Vector3(0, 0, 0);
    float xRotationMin = 2;
    float xRotationMax = 80;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CameraCenterControls();
        LimitRotation();
        transform.rotation = Quaternion.Euler(cameraCenterRotation);
        transform.position = cameraCenterPosition;
    }

    void FixedUpdate()
    {
        
    }
    void LateUpdate()
    {
        transform.rotation = Quaternion.Euler(cameraCenterRotation);
        transform.position = cameraCenterPosition;
    }
    void CameraCenterControls()
    {
        if (Input.GetKey(KeyCode.LeftArrow) == true)
        {
            cameraCenterRotation.y += cameraSpeed.y * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.RightArrow) == true)
        {
            cameraCenterRotation.y -= cameraSpeed.y * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.UpArrow) == true)
        {
            cameraCenterRotation.x += cameraSpeed.x * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.DownArrow) == true)
        {
            cameraCenterRotation.x -= cameraSpeed.x * Time.deltaTime;
        }
    }
    
    void LimitRotation()
    {
        if (cameraCenterRotation.x < xRotationMin)
        {
            cameraCenterRotation.x = xRotationMin;
        }
        if (cameraCenterRotation.x > xRotationMax)
        {
            cameraCenterRotation.x = xRotationMax;
        }
    }
}
