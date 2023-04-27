using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody rb;

    float speed = 100.0f;

    [SerializeField]
    InputSC inputValues;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Walk();
    }


    void Walk()
    {
        Vector3 movementDirection = new Vector3(inputValues.playerMovement.x, 0.0f, inputValues.playerMovement.y);
        rb.velocity = movementDirection * speed * Time.deltaTime;

        Debug.Log(rb.velocity.z);
    }
}
