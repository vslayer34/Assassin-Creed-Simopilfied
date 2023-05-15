using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    Animator animator;

    [SerializeField]
    InputSC inputValues;
    [SerializeField]
    PlayerStateSC state;

    int speedX, speedZ;
    float valueX, valueZ;

    float acceralation = 0.5f;

    void Start()
    {
        animator = GetComponent<Animator>();
        speedX = Animator.StringToHash("SpeedX");
        speedZ = Animator.StringToHash("SpeedZ");
    }

    public void PlayLowAnimation()
    {
        if (inputValues.playerMovement.y > 0.01f)
        {
            //animator.SetFloat(speedZ, 5.0f);
            IncreaseParameter(speedZ, ref valueZ);
        }
        else
        {
            //animator.SetFloat(speedZ, 0.0f);
            //DecreaseParameter(speedZ, ref valueZ);
        }
    }


    public void IncreaseParameter(int parameter, ref float value)
    {
        value += Time.deltaTime * acceralation;
        Debug.Log(value);
        animator.SetFloat(parameter, value);
    }

    public void DecreaseParameter(int parameter, ref float value)
    {
        value -= Time.deltaTime * acceralation;
        animator.SetFloat(parameter, value);
    }
}
