using UnityEngine;

public class GetInputs : MonoBehaviour
{
    PlayerInput playerInput;

    [SerializeField]
    InputSC playerValues;
    
    void Start()
    {
        playerInput = new PlayerInput();
        playerInput.Player.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        playerValues.playerMovement = playerInput.Player.Movement.ReadValue<Vector2>();
    }
}
