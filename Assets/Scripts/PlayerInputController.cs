using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputController : MonoBehaviour
{
    public Vector3 MovementInput { get; private set; }

    private float jumpHoldStartTime;
    public bool IsJumping { get; set; }

    private Vector3 screenMousePos;
    public Vector2 LeftClickPos { get; private set; }
    public Vector2 RelativeLeftClickPos { get; private set; }
    public Vector2 RightClickPos { get; private set; }
    public Vector2 RelativeRightClickPos { get; private set; }

    public Player player;
    public Camera playerCamera;


    public void OnMovement(InputAction.CallbackContext value)
    {
        MovementInput = value.ReadValue<Vector2>();
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
                if (IsJumping)
                {
                    AdjustJumpGravity(2 - (Time.time - jumpHoldStartTime) / 0.25f);
                }
            }
            IsJumping = false;
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
            screenMousePos = Mouse.current.position.ReadValue();
            screenMousePos.z = -Camera.main.transform.position.z;
            LeftClickPos = Camera.main.ScreenToWorldPoint(screenMousePos);
            RelativeLeftClickPos = LeftClickPos - (Vector2)player.transform.position;
            ((PlayerState)player.CurrentState).OnLeftClick(LeftClickPos, RelativeLeftClickPos);
        }
    }

    public void OnRightClick(InputAction.CallbackContext value)
    {
        if (value.performed)
        {
            screenMousePos = Mouse.current.position.ReadValue();
            screenMousePos.z = -Camera.main.transform.position.z;
            RightClickPos = Camera.main.ScreenToWorldPoint(screenMousePos);
            RelativeRightClickPos = RightClickPos - (Vector2)player.transform.position;
            ((PlayerState)player.CurrentState).OnRightClick(RightClickPos, RelativeRightClickPos);
        }
    }
}
