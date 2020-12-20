using System;
using System.Collections;
using System.Collections.Generic;
using Sirenix.Utilities;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;

namespace Player
{
    public class LocalPlayerInput : MonoBehaviour
    {
        [SerializeField] protected Vector2 maxInput;
        public PlayerInputAction test;

        private PlayerMovement _playerMovement;

        private bool _initialized = false;

        private void Start()
        {
            Initialize();
        }

        private void Initialize()
        {
            _playerMovement = GetComponent<PlayerMovement>();
            _initialized = true;
        }
        
        public void OnMove(InputAction.CallbackContext context)
        {
            if (_initialized == false)
                return;
            
            Vector2 movementInput = context.ReadValue<Vector2>();
            movementInput = movementInput.Clamp(-maxInput, maxInput);
            _playerMovement.UpdateMovement(movementInput);
        }

        public void OnCounterMove(InputAction.CallbackContext context)
        {
            if (_initialized == false)
                return;

            if(context.started)
            {
                _playerMovement.CheckCounterMove();
            }
        }
    }
}

