using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerHud : MonoBehaviour
{
    public TextMeshProUGUI Xp;
    public PlayerController playerController;
    public PlayerStats playerStats;
    // Start is called before the first frame update
    void Start()
    {
        //playerController = GetComponentInParent<PlayerController>();
        playerStats = playerController.GetComponent<PlayerStats>();
        updateXpText(playerStats.currentXp,playerStats.currentLevel,playerStats.requiredXp);        
    }

    // Update is called once per frame
    void Update()
    {
        
        
        
    }

    public void updateXpText(double currentXp, double currentLevel, double requiredXp)
    {
        Xp.text = $"Current XP: {currentXp} Current Level: {currentLevel} Required Xp to next level: {requiredXp}";
    }
}
