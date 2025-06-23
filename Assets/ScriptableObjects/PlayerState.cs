using Assets.Code;
using Assets.Scripts.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.ScriptableObjects
{
    [CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/PlayerState", order = 4)]
    public class PlayerState : ScriptableObject
    {
        private InteractMode _interactMode;
        private PlayerMode _playerMode;
        public PlayerMode PlayerMode { get => _playerMode; set { _playerMode = value; OnPlayerModeChanged?.Invoke(this, _playerMode); } }
        public InteractMode InteractMode { get => _interactMode; set { _interactMode = value; OnInteractModeChanged?.Invoke(this, _interactMode); } }
        public GameObject GameObject;

        public event EventHandler<PlayerMode> OnPlayerModeChanged;
        public event EventHandler<InteractMode> OnInteractModeChanged;
    }

}
