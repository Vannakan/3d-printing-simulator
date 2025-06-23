using Assets.Code;
using UnityEngine;

namespace Assets.ScriptableObjects
{
    [CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Filament", order = 2)]
    public class Filament : Item
    {
        public Color Color;
        public int Amount = 350;
        public FilamentMaterial Material;
    }
}
