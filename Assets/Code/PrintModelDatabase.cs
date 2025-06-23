using System.Collections.Generic;
using UnityEngine;

namespace Assets.Code
{
   
    [CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/PrintModelDatabase")]
    public class PrintModelDatabase : ScriptableObject
    {
        public List<PrintModel> PrintModels;
    }
}
