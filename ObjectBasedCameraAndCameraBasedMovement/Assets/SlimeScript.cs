using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeScript : MonoBehaviour
{
    float playerForwardSpeed = 0;
    float playerSideSpeed = 0;
    float maxForwardSpeed = 30;
    float playerForwardAccelleration = 30f; //per second
    float playerSideAccelleration = 30f; //how easily the slime can turn
    float maxSideSpeed = 30;
    float deltaTime;

    float sideDirection = 0;
    float forwardDirection = 0;
    Vector3 directionVectors = new Vector3(0, 0, 0);
    Rigidbody slimeRigidbody;
    // Start is called before the first frame update
    bool up = false;
    bool down = false;
    bool left = false;
    bool right = false;
    void Start()
    {
        slimeRigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        GetInputs();
        FindMovementAndDirection();
        //CameraCenterScript.cameraCenterPosition = transform.position;
    }
    
    void FixedUpdate()
    {
        deltaTime = Time.fixedDeltaTime;
        LimitSpeeds();
        
        RotateSlime();
        DoMovement();
        CameraCenterScript.cameraCenterPosition = transform.position;
        //print("fixed updatte");
    }
    void LateUpdate()
    {
        
    }

    void GetInputs()
    {
        if (Input.GetAxisRaw("Vertical") > 0)
        {
            playerForwardSpeed += playerForwardAccelleration * Time.deltaTime;
        }
        if (Input.GetAxisRaw("Vertical") < 0)
        {
            playerForwardSpeed -= playerForwardAccelleration * Time.deltaTime;
        }
        if (Input.GetAxisRaw("Horizontal") > 0)
        {
            playerSideSpeed += playerSideAccelleration * Time.deltaTime;
        }
        if (Input.GetAxisRaw("Horizontal") < 0)
        {
            playerSideSpeed -= playerSideAccelleration * Time.deltaTime;
        }
        if (Input.GetAxisRaw("Horizontal") == 0)
        {
           if ((playerSideSpeed > 0) && (playerSideSpeed > playerSideAccelleration*2)) { playerSideSpeed -= (2* playerSideAccelleration); }
           else if ((playerSideSpeed < 0) && (playerSideSpeed < -playerSideAccelleration*2)) { playerSideSpeed += (playerSideAccelleration * 2); }
           else if (Mathf.Abs(playerSideSpeed) < playerSideAccelleration*2) { playerSideSpeed = 0; }
        }
       if (Input.GetAxisRaw("Vertical") == 0)
        {
           if ((playerForwardSpeed > 0) && (playerForwardSpeed > playerSideAccelleration*2)) { playerForwardSpeed -= (playerSideAccelleration * 2); }
           else if ((playerForwardSpeed < 0) && (playerForwardSpeed < -playerSideAccelleration*2)) { playerForwardSpeed += (playerSideAccelleration * 2); }
          else if (Mathf.Abs(playerForwardSpeed) < playerForwardAccelleration*2) { playerForwardSpeed = 0; }
        }
        //print("InputsGot");
    }

    void LimitSpeeds()
    {
        if (Mathf.Abs(playerForwardSpeed) > maxForwardSpeed)
        {
            if (playerForwardSpeed<0) { playerForwardSpeed = -maxForwardSpeed; }
            else if (playerForwardSpeed>0) { playerForwardSpeed = maxForwardSpeed; }
        }
        if (Mathf.Abs(playerSideSpeed) > maxSideSpeed)
        {
            if (playerSideSpeed < 0) { playerSideSpeed = -maxSideSpeed; }
            else if (playerSideSpeed > 0) { playerSideSpeed = maxSideSpeed; }
        }
    }

    void FindMovementAndDirection()
    {

        forwardDirection = CameraCenterScript.cameraCenterRotation.y;
        sideDirection = forwardDirection + 90;
        if(sideDirection > 360) { sideDirection -= 360; }

        directionVectors.x = Mathf.Sin(forwardDirection*Mathf.PI/180);
        directionVectors.z = Mathf.Cos(forwardDirection * Mathf.PI / 180);
        directionVectors = directionVectors.normalized;
        print(forwardDirection);
    }

    void DoMovement()
    {
        Vector3 vf;
        Vector3 vs;
        
        vf = directionVectors * Time.fixedDeltaTime * playerForwardSpeed;
        vs = new Vector3(Mathf.Sin((forwardDirection+90) * Mathf.PI / 180), 0 , Mathf.Cos((forwardDirection + 90)*Mathf.PI/180)).normalized;
        vs = vs * Time.fixedDeltaTime * playerSideSpeed;
       // print(playerSideSpeed);
        slimeRigidbody.position += (vs + vf);
       
    }

    void RotateSlime()
    {
        transform.rotation = Quaternion.Euler(0,forwardDirection,0);
    }
}
