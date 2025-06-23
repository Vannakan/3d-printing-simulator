using Assets.ScriptableObjects;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Code
{
    [CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/ShopDatabase")]
    public class ShopDatabase : ScriptableObject
    {
        public List<Item> Items;
    }
}
