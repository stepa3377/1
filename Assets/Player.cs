using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private float _speed;

    [Header("Components")]
    [SerializeField] private CharacterController _characterController;


    private void Update()
    {
        var inputs = Vector3.zero;
    }
}
