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

    public PlayerState PlayerCurrentState
    {
        get { return (PlayerState)player.CurrentState; }
    }

    public void OnMovement(InputAction.CallbackContext value)
    {
        MovementInput = value.ReadValue<Vector2>();
        if (value.performed || value.canceled) 
        {
            PlayerCurrentState.OnMove(value);
        }
    }

    public void OnJump(InputAction.CallbackContext value)
    {
        if (value.performed)
        {
            PlayerCurrentState.OnJump();
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
            PlayerCurrentState.OnLeftClick(LeftClickPos, RelativeLeftClickPos);
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
            PlayerCurrentState.OnRightClick(RightClickPos, RelativeRightClickPos);
        }
    }

    public void OnActive1(InputAction.CallbackContext value)
    {
        if (value.performed)
        {
            PlayerCurrentState.OnActive1();
        }
    }

    public void OnActive2(InputAction.CallbackContext value)
    {
        if (value.performed)
        {
            PlayerCurrentState.OnActive2();
        }
    }

    public void OnActive3(InputAction.CallbackContext value)
    {
        if (value.performed)
        {
            PlayerCurrentState.OnActive4();
        }
    }

    public void OnActive4(InputAction.CallbackContext value)
    {
        if (value.performed)
        {
            PlayerCurrentState.OnActive4();
        }
    }

    public void OnActive5(InputAction.CallbackContext value)
    {
        if (value.performed)
        {
            PlayerCurrentState.OnActive5();
        }
    }
}
