using Assets.Code;
using UnityEngine;

namespace Assets.ScriptableObjects
{
    [CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Print", order = 3)]
    public class Print : Item
    {
        public int Value = 5;
    }
}
