using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    [SerializeField] private float characterSpeed;

    private Rigidbody2D characterRB;
    [SerializeField] private Transform joystickHandle;

    void Start()
    {
        characterRB = gameObject.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Vector2 joystickPosition = new Vector2(joystickHandle.localPosition.x, joystickHandle.localPosition.y);
        Vector2 normalizedPosition = joystickPosition.normalized;
        characterRB.velocity = normalizedPosition * characterSpeed;
    }
}
