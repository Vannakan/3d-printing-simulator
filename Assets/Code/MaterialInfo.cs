using System.Collections.Generic;
using UnityEngine;

namespace Assets.Code
{
    [CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/MaterialInfo", order = 5)]
    public class MaterialInfo : ScriptableObject
    {
        public Material Material;
        public Strength Strength;
        public Flexibility Flexibility;
        public DetailQuality DetailQuality;
        public List<ApplicationType> Applications;
    }
}
