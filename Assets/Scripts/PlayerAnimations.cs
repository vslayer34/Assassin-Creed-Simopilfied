using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    Animator animator;

    [SerializeField]
    PlayerController controllerScript;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {

    }
}
