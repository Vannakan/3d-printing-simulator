using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

namespace Assets.Code
{
    [CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/MaterialDatabase")]
    public class MaterialDatabase : ScriptableObject
    {
        public List<MaterialInfo> Info;

        public Dictionary<Material, MaterialInfo> Materials => Info.ToDictionary(e => e.Material, x => x);
    }
}

//{
//[Material.PLA] = new MaterialInfo
//{
//    Material = Material.PLA,
//    Strength = Strength.Medium,
//    Flexibility = Flexibility.Rigid,
//    DetailQuality = DetailQuality.Medium,
//    Applications = new List<ApplicationType>
//            {
//                ApplicationType.Prototyping,
//                ApplicationType.Toy
//            }
//},
//                [Material.ABS] = new MaterialInfo
//                {
//                    Material = Material.ABS,
//                    Strength = Strength.High,
//                    Flexibility = Flexibility.SemiFlexible,
//                    DetailQuality = DetailQuality.Medium,
//                    Applications = new List<ApplicationType>
//            {
//                ApplicationType.FunctionalPart
//            }
//                },
//                [Material.PETG] = new MaterialInfo
//                {
//                    Material = Material.PETG,
//                    Strength = Strength.High,
//                    Flexibility = Flexibility.SemiFlexible,
//                    DetailQuality = DetailQuality.Medium,
//                    Applications = new List<ApplicationType>
//            {
//                ApplicationType.FunctionalPart,
//                ApplicationType.MechanicalPart
//            }
//                },
//                [Material.Resin] = new MaterialInfo
//                {
//                    Material = Material.Resin,
//                    Strength = Strength.Low,
//                    Flexibility = Flexibility.Rigid,
//                    DetailQuality = DetailQuality.High,
//                    Applications = new List<ApplicationType>
//            {
//                ApplicationType.HighDetailMiniature,
//                ApplicationType.PrecisionModel
//            }
//                },
//                [Material.Nylon] = new MaterialInfo
//                {
//                    Material = Material.Nylon,
//                    Strength = Strength.High,
//                    Flexibility = Flexibility.Flexible,
//                    DetailQuality = DetailQuality.Medium,
//                    Applications = new List<ApplicationType>
//            {
//                ApplicationType.MechanicalPart,
//                ApplicationType.FlexibleComponent
//            }
//                },
//                [Material.TPU] = new MaterialInfo
//                {
//                    Material = Material.TPU,
//                    Strength = Strength.Medium,
//                    Flexibility = Flexibility.Flexible,
//                    DetailQuality = DetailQuality.Medium,
//                    Applications = new List<ApplicationType>
//            {
//                ApplicationType.FlexibleComponent
//            }
//                },
//                [Material.Woodfill] = new MaterialInfo
//                {
//                    Material = Material.Woodfill,
//                    Strength = Strength.Medium,
//                    Flexibility = Flexibility.Rigid,
//                    DetailQuality = DetailQuality.Medium,
//                    Applications = new List<ApplicationType>
//            {
//                ApplicationType.Decorative,
//                ApplicationType.Specialty
//            }
//                },
//                [Material.MetalFill] = new MaterialInfo
//                {
//                    Material = Material.MetalFill,
//                    Strength = Strength.High,
//                    Flexibility = Flexibility.Rigid,
//                    DetailQuality = DetailQuality.Medium,
//                    Applications = new List<ApplicationType>
//            {
//                ApplicationType.Decorative,
//                ApplicationType.Specialty
//            }
//                },
//                [Material.GlowInTheDark] = new MaterialInfo
//                {
//                    Material = Material.GlowInTheDark,
//                    Strength = Strength.Medium,
//                    Flexibility = Flexibility.Rigid,
//                    DetailQuality = DetailQuality.High,
//                    Applications = new List<ApplicationType>
//            {
//                ApplicationType.Toy,
//                ApplicationType.Specialty
//            }
//                }
//            };