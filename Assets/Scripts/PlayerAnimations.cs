using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    Animator animator;

    [SerializeField]
    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (rb.velocity.z > 0)
        {
            animator.SetBool("isWalking", true);
            animator.speed = rb.velocity.z;
        }
        else
        {
            animator.SetBool("isWalking", false);
        }
    }
}
