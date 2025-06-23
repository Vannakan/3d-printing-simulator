using Assets.Code;
using AutoFixture;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;


public class PrefabManager : MonoBehaviour
{
    public static PrefabManager Instance;
    public PrefabMap PrefabMap;
    public List<PrefabEntry> Entries;

    private void Awake()
    {
        Instance = this;
        foreach (var entry in Entries)
        {
            PrefabMap.Add(entry.Key, entry.Value);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
