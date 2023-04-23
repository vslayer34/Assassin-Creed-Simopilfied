using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody rb;

    float speed = 5.0f;

    [SerializeField]
    InputSC inputValues;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Move();
    }


    void Move()
    {
        Vector3 movementDirection = new Vector3(inputValues.playerMovement.x, 0.0f, inputValues.playerMovement.y);
        rb.MovePosition(transform.position + movementDirection * speed * Time.deltaTime);
    }
}
