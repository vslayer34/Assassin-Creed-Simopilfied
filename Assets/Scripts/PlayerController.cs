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

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        followCamera = Camera.main;
    }


    private void Update()
    {
        //if (inputValues.playerMovement != Vector2.zero)
        //{
        //    float targetAngle = Mathf.Atan2(inputValues.mousePosition.x, inputValues.mousePosition.y) * Mathf.Rad2Deg * followCamera.transform.eulerAngles.y;
        //    Quaternion targetRotation = Quaternion.Euler(0.0f, targetAngle, 0.0f);
        //    transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * rotationSpeed);
        //}
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Walk();
    }


    void Walk()
    {
        Debug.Log(inputValues.playerMovement);
        Vector3 movementDirection = new Vector3(inputValues.playerMovement.x, rb.velocity.y, inputValues.playerMovement.y);
        //movementDirection = transform.InverseTransformDirection(movementDirection);
        rb.velocity = transform.TransformDirection(movementDirection * speed * Time.deltaTime);
    }
}
