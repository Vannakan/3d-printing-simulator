using Assets.ScriptableObjects;
using System;
using UnityEngine;
using UnityEngine.Rendering;

namespace Assets.Code
{
    [Serializable]
    public class InventoryItem
    {
        public Item Item;
        public int Id;

        private static int _id;

        public InventoryItem(Item item)
        {
            Id = _id++;
            Item = item;
        }
    }
    public enum Material
    {
        PLA,
        ABS,
        PETG,
        Resin,
        Nylon,
        TPU,
        Woodfill,
        MetalFill,
        GlowInTheDark
    }

    public enum ApplicationType
    {
        Prototyping,
        Toy,
        FunctionalPart,
        MechanicalPart,
        PrecisionModel,
        FlexibleComponent,
        HighDetailMiniature,
        Decorative,
        Specialty
    }



    public enum Strength { Low, Medium, High };

    public enum Flexibility
    {
        Rigid,
        SemiFlexible,
        Flexible
    }


    public enum DetailQuality
    {
        Low,
        Medium,
        High
    }


    [Serializable]
    public class FilamentMaterial
    {
        public FilamentMaterialType Type;
        public string Name;
        public string Description;

        public int HeatResistance;
        public int PrintSpeed;
        public int Flexibility;
        public int Strength;
    }

    public class FilamentMaterialCondition
    {
        public int Humidity;
        public int Expiration;
    }

    public enum FilamentMaterialType
    {
        PLA,
        ABS,
        PETG,
        RESIN,
        NYLON,
        TPU,
        EXOTIC
    }

    public enum PrintType
    {
        TOYS,
        PROTOTYPES,
        FUNCTIONAL,
        MECHANICAL,
        MINIATURE,
        PRECISION,
        GEARS, 
        JOINTS,
        RUBBER,
        SPECIAL
    }

    public enum Application
    {
        Buy, Sell
    }

    public class PrintData
    {
        public string ModelName;
    }

 

    [Serializable]
    public record Order
    {
        public int OrderId;
        public int Amount;
        public int Value;
        public PrintModel PrintModel;
        public string Text; // Think about this a bit..maybe a manager handles order structure/resolution
        public Color Color;
    }

    [Serializable]
    public record Contract
    {
        public int Id { get; }
        private static int id;
        public Contract()
        {
            Id = id++;
        }
        public Order Order;
        public int Remaining;
        public string Recipient;
    }

    [Serializable]
    public enum ItemType
    {
        Printer,
        Filament,
        Print,
        Prop
    }

    public enum InteractMode
    {
        All,
        None,
        Carrying, //Interacting with an existing prop in the world
        Placement, //Introducing a new prop on the scene from toolbar
        Occupied,
        PC,
        PCNoLock
    }

    [Serializable]
    public class PrefabEntry
    {
        public string Key;
        public GameObject Value;
    }
    [Serializable]
    public class PrefabMap : SerializedDictionary<string, GameObject> { }






}
