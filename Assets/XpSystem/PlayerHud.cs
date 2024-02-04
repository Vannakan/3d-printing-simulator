using TMPro;
using UnityEngine;

public class PlayerHud : MonoBehaviour
{
    public TextMeshProUGUI XP;
    public PlayerController PlayerController;
    public PlayerStats PlayerStats;
    
    void Start()
    {
        PlayerStats = PlayerController.GetComponent<PlayerStats>();
        UpdateXpText(PlayerStats.CurrentXp, PlayerStats.CurrentLevel, PlayerStats.CurrentXp);        
    }

    public void UpdateXpText(double currentXp, double currentLevel, double requiredXp)
    {
        XP.text = $"Current XP: {currentXp} Current Level: {currentLevel} Required Xp to next level: {requiredXp}";
    }
}
