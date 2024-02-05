using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public double CurrentXp = 0;
    public double CurrentLevel = 0;
    public double RequiredXp = 100;
    public PlayerHud PlayerHud;

    public void AddXp(double xpAmount)
    {
        CurrentXp += xpAmount;
        AddLevel();
    }

    public void AddLevel()
    {
        if (CurrentXp > RequiredXp)
        {
            CurrentLevel++;
            RequiredXp = (RequiredXp + 100) * 1.1;
        }

        PlayerHud.UpdateXpText(CurrentXp, CurrentLevel, RequiredXp);
    }
}
