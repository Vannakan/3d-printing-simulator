using TMPro;
using UnityEngine;

public class PlayerHud : MonoBehaviour
{
    public TextMeshProUGUI XP;
    public PlayerController PlayerController;
    private PlayerStats _playerStats;

    void Start()
    {
        _playerStats = PlayerController.GetComponent<PlayerStats>();
        UpdateXpText(_playerStats.CurrentXp, _playerStats.CurrentLevel, _playerStats.RequiredXp);
    }

    public void UpdateXpText(double currentXp, double currentLevel, double requiredXp)
    {
        XP.text = $"Current XP: {currentXp} Current Level: {currentLevel} Required Xp to next level: {requiredXp}";
    }
}
