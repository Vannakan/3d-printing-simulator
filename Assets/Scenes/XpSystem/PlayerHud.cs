using TMPro;
using UnityEngine;

public class PlayerHud : MonoBehaviour
{
    public TextMeshProUGUI XP;
    public TextMeshProUGUI Money;
    public PlayerController PlayerController;
    private PlayerStats _playerStats;

    void Start()
    {
        _playerStats = PlayerController.GetComponent<PlayerStats>();
        UpdateXpText(_playerStats.CurrentXp, _playerStats.CurrentLevel, _playerStats.RequiredXp);
        UpdateMoneyText(_playerStats.Money);

    }

    public void UpdateXpText(double currentXp, double currentLevel, double requiredXp)
    {
        XP.text = $"Current XP: {currentXp} Current Level: {currentLevel} Required Xp to next level: {requiredXp}";
    }

    public void UpdateMoneyText(int money)
    {
        Money.text = $"Money: {money}";
    }


}
