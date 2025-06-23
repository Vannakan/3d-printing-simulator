using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Code
{
    public static class WellKnownColours
    {
        public static Dictionary<string, Color> Map = new();
        public static string GetColourName(Color color) => Map.OrderBy(kvp => Vector3.Distance(new Vector3(kvp.Value.r, kvp.Value.b, kvp.Value.g), new Vector3(color.r, color.b, color.g))).First().Key;
        static WellKnownColours()
        {
            Map = new Dictionary<string, Color>()
            {
                { "Aqua", new Color(0.0f, 1.0f, 1.0f) },
                { "Azure", new Color(0.941f, 1.0f, 1.0f) },
                { "Beige", new Color(0.961f, 0.961f, 0.863f) },
                { "Bisque", new Color(1.0f, 0.894f, 0.769f) },
                { "Black", Color.black },
                { "Blue", Color.blue },
                { "Brown", new Color(0.647f, 0.165f, 0.165f) },
                { "Coral", new Color(1.0f, 0.498f, 0.314f) },
                { "Crimson", new Color(0.863f, 0.078f, 0.235f) },
                { "Cyan", Color.cyan },
                { "Fuchsia", new Color(1.0f, 0.0f, 1.0f) },
                { "Gold", new Color(1.0f, 0.843f, 0.0f) },
                { "Gray", Color.gray },
                { "Green", Color.green },
                { "Indigo", new Color(0.294f, 0.0f, 0.51f) },
                { "Ivory", new Color(1.0f, 1.0f, 0.941f) },
                { "Khaki", new Color(0.941f, 0.902f, 0.549f) },
                { "Lavender", new Color(0.902f, 0.902f, 0.98f) },
                { "Lime", new Color(0.0f, 1.0f, 0.0f) },
                { "Linen", new Color(0.98f, 0.941f, 0.902f) },
                { "Magenta", Color.magenta },
                { "Maroon", new Color(0.502f, 0.0f, 0.0f) },
                { "Moccasin", new Color(1.0f, 0.894f, 0.71f) },
                { "Navy", new Color(0.0f, 0.0f, 0.502f) },
                { "Olive", new Color(0.502f, 0.502f, 0.0f) },
                { "Orange", new Color(1.0f, 0.647f, 0.0f) },
                { "Orchid", new Color(0.855f, 0.439f, 0.839f) },
                { "Peru", new Color(0.804f, 0.522f, 0.247f) },
                { "Pink", new Color(1.0f, 0.753f, 0.796f) },
                { "Plum", new Color(0.867f, 0.627f, 0.867f) },
                { "Purple", new Color(0.502f, 0.0f, 0.502f) },
                { "Red", Color.red },
                { "Salmon", new Color(0.98f, 0.502f, 0.447f) },
                { "Seashell", new Color(1.0f, 0.961f, 0.933f) },
                { "Sienna", new Color(0.627f, 0.322f, 0.176f) },
                { "Silver", new Color(0.753f, 0.753f, 0.753f) },
                { "Snow", new Color(1.0f, 0.98f, 0.98f) },
                { "Tan", new Color(0.824f, 0.706f, 0.549f) },
                { "Teal", new Color(0.0f, 0.502f, 0.502f) },
                { "Thistle", new Color(0.847f, 0.749f, 0.847f) },
                { "Tomato", new Color(1.0f, 0.388f, 0.278f) },
                { "Turquoise", new Color(0.251f, 0.878f, 0.816f) },
                { "Violet", new Color(0.933f, 0.51f, 0.933f) },
                { "Wheat", new Color(0.961f, 0.871f, 0.702f) },
                { "White", Color.white },
                { "Yellow", Color.yellow },

                // "Dark"/"Light" variants with space added
                { "Dark Red", new Color(0.545f, 0.0f, 0.0f) },
                { "Dark Green", new Color(0.0f, 0.392f, 0.0f) },
                { "Dark Blue", new Color(0.0f, 0.0f, 0.545f) },
                { "Dark Cyan", new Color(0.0f, 0.545f, 0.545f) },
                { "Dark Magenta", new Color(0.545f, 0.0f, 0.545f) },
                { "Dark Orange", new Color(1.0f, 0.549f, 0.0f) },
                { "Dark Violet", new Color(0.58f, 0.0f, 0.827f) },
                { "Dark Gray", new Color(0.663f, 0.663f, 0.663f) },
                { "Dark Olive", new Color(0.333f, 0.42f, 0.184f) },
                { "Dark Slate", new Color(0.184f, 0.31f, 0.31f) },

                { "Light Red", new Color(1.0f, 0.5f, 0.5f) },
                { "Light Green", new Color(0.565f, 0.933f, 0.565f) },
                { "Light Blue", new Color(0.678f, 0.847f, 0.902f) },
                { "Light Cyan", new Color(0.878f, 1.0f, 1.0f) },
                { "Light Magenta", new Color(1.0f, 0.75f, 1.0f) },
                { "Light Yellow", new Color(1.0f, 1.0f, 0.878f) },
                { "Light Gray", new Color(0.827f, 0.827f, 0.827f) }
            };
        }
    }
}
