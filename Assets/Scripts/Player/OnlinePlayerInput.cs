using System;
using System.Collections;
using System.Collections.Generic;
using Mirror;
using Sirenix.Utilities;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;

namespace Player
{
    public class OnlinePlayerInput : NetworkBehaviour
    {
        [SerializeField] protected Vector2 maxInput;
        public PlayerMovement _playerMovement;

        private void Awake()
        {
            _playerMovement = GetComponent<PlayerMovement>();
        }

        public void OnMoveInput(InputAction.CallbackContext context)
        {
            Vector2 movementInput = context.ReadValue<Vector2>();
            Debug.Log("move input called : " + movementInput);

            CmdOnMove(movementInput);
        }

        public void OnBaseAttackInput()
        {
            
        }

        public void OnCounterAttackInput()
        {
            
        }
    
        [Command]
        public void CmdOnMove(Vector2 movement)
        {
            // Debug.Log("Network ask for movement : " + currentMovement);
            RPCMove(movement);
        }
    
        [ClientRpc]
        private void RPCMove(Vector2 movement)
        {
            // Debug.Log("Network response for movement : " + currentMovement);

            movement = movement.Clamp(-maxInput, maxInput);
            _playerMovement.UpdateMovement(movement);
        }
    }
}

