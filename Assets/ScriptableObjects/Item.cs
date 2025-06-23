using Assets.Code;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.ScriptableObjects
{
    [System.Serializable]
    public abstract class Item : ScriptableObject
    {
        public string Name;
        public ItemType ItemType;
        public GameObject Prefab;
        public Sprite Sprite;
        public GameObject WorldObject;
    }
}