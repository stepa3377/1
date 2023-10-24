using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private float _speed;
    [SerializeField] private float _gravity=9f;
    [SerializeField] private float _jumpForce = 1f;

    [Header("Components")]
    [SerializeField] private CharacterController _characterController;
    [SerializeField] private Animator _animator;
    private static readonly int IsRunning = Animator.StringToHash("IsRunning");

    void Update()
    {
        MovementUpdate();
        UpdateJump();
    }


    private void UpdateJump()
    {
        if (Input.GetButtonDown("Jump"))
        {
            Jump();
        }
    }
    private void MovementUpdate()
    {
        var inputs = Vector3.zero;
        inputs.x = Input.GetAxis("Horizontal");
        inputs.z = Input.GetAxis("Vertical");

        SetRunAnimationActive(inputs != Vector3.zero);
        _characterController.Move(inputs * (_speed * Time.deltaTime));
        _characterController.Move(Vector3.down * (_gravity * Time.deltaTime));
    }

    private void SetRunAnimationActive(bool isActive)
    {
        _animator.SetBool(IsRunning, isActive);
    }

    private void Jump()
    {
        if (!_characterController.isGrounded )
        {
            return;
        }
        _characterController.Move(Vector3.up * _jumpForce); 
    }

}
