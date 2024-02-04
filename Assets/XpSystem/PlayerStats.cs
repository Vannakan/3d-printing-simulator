using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public double CurrentXp = 0;
    public double CurrentLevel = 0;
    public double RequiredXp = 100;
    public PlayerHud playerHud;

     public void AddXp(double xpAmount)
    {
        currentXp += xpAmount;
        AddLevel();
        Debug.Log($"XP added: {currentXp}");
    }

    public void AddLevel()
    {
        if (currentXp > requiredXp)
        {
            currentLevel++;
            requiredXp = (requiredXp + 100) * 1.1;
        }

        playerHud.updateXpText(currentXp, currentLevel, requiredXp);
    }
}
