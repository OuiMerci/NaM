using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;

    private Vector2 _currentMovement;
    private Vector3 _forwardVector, _rightVector;
    private PlayerAnimation _playerAnimation;

    private void Start()
    {
        Initialize();
    }

    private void FixedUpdate()
    {
        UpdateAnimation();
        if (_currentMovement != Vector2.zero)
        {
            ApplyMovement();
        }
    }

    private void Initialize()
    {
        AlignWithCamera();
        _playerAnimation = GetComponent<PlayerAnimation>();
    }

    public void UpdateMovement(Vector2 input)
    {
        //Debug.Log("update move called : " + input);
        _currentMovement = input;
    }

    public void CheckCounterMove()
    {
        Debug.Log("Counter Move Done : ");
        //_currentMovement = input;
    }

    private void ApplyMovement()
    {
        Vector3 rightMovement = _currentMovement.x * Time.deltaTime * speed * _rightVector;
        Vector3 upMovement = _currentMovement.y * Time.deltaTime * speed * _forwardVector;
        Vector3 heading = Vector3.Normalize(rightMovement + upMovement);
        
        transform.forward = heading;
        transform.position += rightMovement;
        transform.position += upMovement;
    }

    private void AlignWithCamera()
    {
        _forwardVector = Camera.main.transform.forward;
        _forwardVector.y = 0;
        _forwardVector = Vector3.Normalize(_forwardVector);
        _rightVector = Quaternion.Euler(new Vector3(0, 90, 0)) * _forwardVector;
    }

    private void UpdateAnimation()
    {
        _playerAnimation.SetSpeed(_currentMovement.magnitude);
    }
}
