using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public double currentXp = 0;
    public double currentLevel = 0;
    public double requiredXp = 100;
    public PlayerHud playerHud;
    public bool passed;

    // Start is called before the first frame update
    void Start()
    {
        // Initialization code (if needed)
    }

    // Update is called once per frame
    void Update()
    {
        if (passed)
        {
            Debug.Log("Passed");
        }
    }

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
