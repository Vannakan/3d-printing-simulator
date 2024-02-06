using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [Header("Player GameObjects")]
    public PlayerHud PlayerHud;
    public GameObject PlayerCamera;

    [HideInInspector] public PlayerStats PlayerStats;
    [HideInInspector] public PlayerInventory PlayerInventory;
    [HideInInspector] public PlayerInteract PlayerInteract;

    [Header("Player Variables")]
    public float MouseSensitivity;
    public float MoveSpeed;
    public int InteractDistance;


    private PlayerMove _playerMove;


    void Start()
    {
        _playerMove = this.AddComponent<PlayerMove>();
        _playerMove.MouseSensitivity = MouseSensitivity;
        _playerMove.MoveSpeed = MoveSpeed;

        PlayerStats = this.AddComponent<PlayerStats>();
        PlayerStats.PlayerHud = PlayerHud;

        PlayerInventory = this.AddComponent<PlayerInventory>();

        PlayerInteract = this.AddComponent<PlayerInteract>();
        PlayerInteract.Inventory = PlayerInventory;
        PlayerInteract.Cam = PlayerCamera;
        PlayerInteract.InteractDistance = InteractDistance;





    }

    // Update is called once per frame
    void Update()
    {

    }

}
