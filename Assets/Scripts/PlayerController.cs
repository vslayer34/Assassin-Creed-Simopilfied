using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Camera followCamera;
    Rigidbody rb;


    float speed = 100.0f;
    float rotationSpeed = 5.0f;

    [SerializeField]
    InputSC inputValues;
    [SerializeField]
    PlayerStateSC playerState;
    [SerializeField]
    PlayerAnimations playerAnimations;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        followCamera = Camera.main;
    }


    private void Update()
    {
        AlignCameraWithPlayer();
        Debug.DrawLine(transform.position, transform.forward * 100.0f, Color.red);
        Debug.DrawLine(followCamera.transform.position, followCamera.transform.forward * 100.0f, Color.blue);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Walk();
    }


    /// <summary>
    /// Move the Rigid body of the player
    /// </summary>
    void Walk()
    {
        Vector3 movementDirection = new Vector3(inputValues.playerMovement.x, rb.velocity.y, inputValues.playerMovement.y);

        // apply the rigid body velocity to the local transform
        rb.velocity = transform.TransformDirection(movementDirection * speed * Time.deltaTime);

        // collect rigid body velocity variables
        playerState.velocityX = rb.velocity.x;
        playerState.velocityZ = rb.velocity.z;

        playerAnimations.PlayLowAnimation();
    }


    /// <summary>
    /// Align the camera with player while the player is moving
    /// </summary>
    void AlignCameraWithPlayer()
    {
        if (inputValues.playerMovement != Vector2.zero)
        {
            //float targetAngle = Mathf.Atan2(inputValues.mousePosition.x, inputValues.mousePosition.y) * Mathf.Rad2Deg * -followCamera.transform.eulerAngles.y;
            //Quaternion targetRotation = Quaternion.Euler(0.0f, targetAngle, 0.0f);
            //transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * rotationSpeed);

            // take the rotaion of the camera
            Quaternion cameraRotation = followCamera.transform.rotation;

            // adjust the rotation of the player transform
            // and set all other rotations exept the y to zero
            Quaternion targetRotaion = Quaternion.Slerp(transform.rotation, cameraRotation, Time.deltaTime * rotationSpeed);
            targetRotaion.Set(0.0f, targetRotaion.y, 0.0f, targetRotaion.w);

            // apply the rotation to the player game object
            transform.rotation = targetRotaion;
            
        }
    }
}
