using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    [SerializeField] private Transform joystickHandle;

    private Animator animator;
    private State currentState;

    public enum State
    {
        Up,
        Down,
        Left,
        Right,
        Idle
    }

    public void Start()
    {
        animator = gameObject.GetComponent<Animator>();
        currentState = State.Idle;
    }

    public void Update()
    {
        Vector2 joystickPosition = new Vector2(joystickHandle.localPosition.x, joystickHandle.localPosition.y);
        Vector2 normalizedPosition = joystickPosition.normalized;

        State newState = GetJoystickDirection(normalizedPosition);

        if (newState != currentState)
        {
            SetCharacterState(newState);
            currentState = newState;
        }
    }

    private void SetCharacterState(State state)
    {
        animator.SetBool("Up", false);
        animator.SetBool("Down", false);
        animator.SetBool("Left", false);
        animator.SetBool("Right", false);
        animator.SetBool("Idle", false);

        switch (state)
        {
            case State.Up:
                animator.SetBool("Up", true);
                break;
            case State.Down:
                animator.SetBool("Down", true);
                break;
            case State.Left:
                animator.SetBool("Left", true);
                break;
            case State.Right:
                animator.SetBool("Right", true);
                break;
            case State.Idle:
                animator.SetBool("Idle", true);
                break;
        }
    }

    private State GetJoystickDirection(Vector2 normalizedPosition)
    {
        float x = normalizedPosition.x;
        float y = normalizedPosition.y;

        if (x == 0 && y == 0)
        {
            return State.Idle;
        }

        float angle = Mathf.Atan2(y, x) * Mathf.Rad2Deg;

        if (angle < 0)
        {
            angle += 360;
        }

        if (angle >= 45 && angle < 135)
        {
            return State.Up;
        }
        else if (angle >= 135 && angle < 225)
        {
            return State.Left;
        }
        else if (angle >= 225 && angle < 315)
        {
            return State.Down;
        }
        else
        {
            return State.Right;
        }
    }
}
