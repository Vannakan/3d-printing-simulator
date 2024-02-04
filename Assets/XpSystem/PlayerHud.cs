using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerHud : MonoBehaviour
{
    public TextMeshProUGUI XP;
    public PlayerController PlayerController;
    public PlayerStats PlayerStats;
    // Start is called before the first frame update
    void Start()
    {
        playerStats = playerController.GetComponent<PlayerStats>();
        updateXpText(playerStats.currentXp,playerStats.currentLevel,playerStats.requiredXp);        
    }

    public void UpdateXpText(double currentXp, double currentLevel, double requiredXp)
    {
        Xp.text = $"Current XP: {currentXp} Current Level: {currentLevel} Required Xp to next level: {requiredXp}";
    }
}
