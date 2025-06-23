using Assets.Code;
using Assets.ScriptableObjects;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum NewInteractMode
{
    None, // Mouse off, camera movement, player movement
    Interacting, //
    Carrying//
}

//public class PlayerController : MonoBehaviour
//{
//    public PlayerState State;
//}
public class PlayerCore : MonoBehaviour
{
    public InteractMode InteractMode;
    public NewInteractMode NewInteractMode;
    //  PlayerCarry PlayerCarry;
    PlayerInteract PlayerInteract;
    PlayerCarry PlayerCarry1;
    //   PlayerPlacement PlayerPlacement;
    PlayerEquip PlayerEquip;
    PlayerMove PlayerMove;

    public Dictionary<NewInteractMode, Action> ModeBehaviourMap = new();

    public void ChangeMode(NewInteractMode mode)
    {
        var action = ModeBehaviourMap[mode];
        action();
    }

    public void Initialize()
    {
        ModeBehaviourMap.Add(NewInteractMode.Carrying, HandleCarrying);
        ModeBehaviourMap.Add(NewInteractMode.None, HandleNone);
        ModeBehaviourMap.Add(NewInteractMode.Interacting, HandleInteracting);
    }

    private void HandleNone()
    {
        PlayerMove.gameObject.SetActive(true);
        PlayerInteract.gameObject.SetActive(true);
        PlayerCarry1.gameObject.SetActive(true);
    }

    private void HandleInteracting()
    {
        PlayerMove.gameObject.SetActive(false);
        PlayerInteract.gameObject.SetActive(true);
        PlayerCarry1.gameObject.SetActive(false);
    }

    private void HandleCarrying()
    {
        PlayerMove.gameObject.SetActive(true);
        PlayerInteract.gameObject.SetActive(false);
        PlayerCarry1.gameObject.SetActive(true);
    }

}
