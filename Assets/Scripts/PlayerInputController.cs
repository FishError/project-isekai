using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputController : MonoBehaviour
{
    public Vector3 movementInput;
    public bool jumpInput;
    public bool leftClickInput;
    public bool rightClickInput;

    public Player player;
    public Camera playerCamera;


    public void OnMovement(InputAction.CallbackContext value)
    {
        movementInput = value.ReadValue<Vector2>();
    }

    public void OnJump(InputAction.CallbackContext value)
    {
        if (value.performed)
        {
            ((PlayerState)player.CurrentState).OnJump();
        }
    }

    public void OnLeftClick(InputAction.CallbackContext value)
    {
        
    }

    public void OnRightClick(InputAction.CallbackContext value)
    {

    }
}
