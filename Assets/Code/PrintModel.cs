using UnityEngine;

namespace Assets.Code
{
    [CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/PrintModel")]
    public class PrintModel : ScriptableObject
    {
        public string Name;
        public ApplicationType Application;
        public Flexibility RequiredFlexibility;
        public DetailQuality RequiredDetail;
        public Strength RequiredStrength;
        public Mesh Mesh;
    }
}
