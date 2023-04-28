using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "InputValues", menuName = "Managers/Input Manager")]
public class InputSC : ScriptableObject
{
    public bool isWalking;
    public Vector2 playerMovement;
    public Vector2 mousePosition;
}
