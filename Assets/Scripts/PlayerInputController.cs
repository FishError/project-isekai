using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputController : MonoBehaviour
{
    public Vector3 movementInput;

    public bool jumpInput;
    public bool isJumping;
    public float jumpHoldStartTime;
    
    public bool leftClickInput;
    public bool rightClickInput;

    public Player player;
    public Camera playerCamera;


    public void OnMovement(InputAction.CallbackContext value)
    {
        movementInput = value.ReadValue<Vector2>();
        if (value.performed || value.canceled) 
        {
            ((PlayerState)player.CurrentState).OnMove(value);
        }
    }

    public void OnJump(InputAction.CallbackContext value)
    {
        if (value.performed)
        {
            ((PlayerState)player.CurrentState).OnJump();
            jumpHoldStartTime = Time.time;
        }
        else if (value.canceled)
        {
            if (Time.time - jumpHoldStartTime < 0.25f) 
            {
                if (isJumping)
                {
                    AdjustJumpGravity(2 - (Time.time - jumpHoldStartTime) / 0.25f);
                }
            }
            isJumping = false;
        }
    }

    private void AdjustJumpGravity(float multiplier)
    {
        player.AdjustGravity(player.gravity * multiplier);
        StartCoroutine(ResetFallingGravity());
    }

    private IEnumerator ResetFallingGravity()
    {
        yield return new WaitUntil(() => player.rb.velocity.y <= 0);
        player.ResetGravity();
    }

    public void OnLeftClick(InputAction.CallbackContext value)
    {
        if (value.performed)
        {
            ((PlayerState)player.CurrentState).OnLeftClick();
        }
    }

    public void OnRightClick(InputAction.CallbackContext value)
    {

    }
}
