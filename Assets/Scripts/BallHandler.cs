using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class BallHandler : MonoBehaviour
{
    [SerializeField] GameObject ball;
    [SerializeField] Rigidbody2D pivot;

    Rigidbody2D ballRigidBody;
    SpringJoint2D ballSpringJoint;
    Camera mainCamera;

    bool isBallBeingMoved;
    float delayBeforeClearRef = 0.1f;
    float delayBeforeRespawn = 2f;
    float delayBeforeDeletingBall = 4f;

    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;
        CreateNewBall();
       
    }

    // Update is called once per frame
    void Update()
    {
        TouchPosHandler();
    }

    void TouchPosHandler()
    {
        if(ballRigidBody == null)
        {
            return;
        }
           if (!Touchscreen.current.primaryTouch.press.isPressed)
            {
                if(isBallBeingMoved)
                {
                    LaunchBall();
                }
                isBallBeingMoved = false;
                return;
            }
            else
            {
                isBallBeingMoved = true;
                ballRigidBody.isKinematic = true;
                Vector2 touchPos = Touchscreen.current.primaryTouch.position.ReadValue();
                Vector3 touchPosInUnits = mainCamera.ScreenToWorldPoint(touchPos);
                ballRigidBody.position = touchPosInUnits;

            }
    }

    void CreateNewBall()
    {
        if(!isBallBeingMoved)
        {
            GameObject newBall = Instantiate(ball, pivot.position, Quaternion.identity);

            ballRigidBody = newBall.GetComponent<Rigidbody2D>();
            ballSpringJoint = newBall.GetComponent<SpringJoint2D>();

            ballSpringJoint.connectedBody = pivot;
        }

        else
        {
            return;
        }
    }
    void LaunchBall()
    {  
        ballRigidBody.isKinematic = false;
        ballRigidBody = null;
        Invoke("ClearBallRef", delayBeforeClearRef);
        Invoke("CreateNewBall", delayBeforeRespawn);  
    }
    void ClearBallRef()
    {
        ballSpringJoint.enabled = false;
        ballSpringJoint = null;
    }
}
