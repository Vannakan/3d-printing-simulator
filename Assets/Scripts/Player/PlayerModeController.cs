using Assets.ScriptableObjects;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Player
{
    public enum PlayerMode
    {
        Walk,
        Interact
    }
    public class PlayerModeController : MonoBehaviour
    {
        public PlayerState PlayerState;
        public PlayerMove PlayerMove;

        public Dictionary<PlayerMode, Action> BehaviourMap = new();

        void Start()
        {
            BehaviourMap.Add(PlayerMode.Walk, HandleWalk);
            BehaviourMap.Add(PlayerMode.Interact, HandleInteract);

            PlayerState.OnPlayerModeChanged += ChangeState;
            PlayerState.PlayerMode = PlayerMode.Walk;
        }

        public void ChangeState(object src, PlayerMode mode)
        {
            Debug.Log("Changing state to " + mode);
            var action = BehaviourMap[mode];
            action();
        }
        private void HandleInteract()
        {
            Cursor.lockState = CursorLockMode.None;
            PlayerMove.enabled = false;
        }

        private void HandleWalk()
        {
            Cursor.lockState = CursorLockMode.Locked;
            PlayerMove.enabled = true;
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Tab))
            {
                if (PlayerState.PlayerMode is PlayerMode.Interact)
                    PlayerState.PlayerMode = PlayerMode.Walk;
                else
                    PlayerState.PlayerMode = PlayerMode.Interact;
            }
        }
    }

}
