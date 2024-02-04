using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Xml.XPath;

public class PlayerStats : MonoBehaviour
{

    public double currentXp=0;
    public double currentLevel=0;
    public double requiredXp=100;
    public PlayerHud playerHud;
    public bool passed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(passed)
        {
            Debug.Log("passed");
        }
        

    }

    public void AddXp(double i)
    {
        currentXp+=i;
        AddLevel();
        Debug.Log($"xp added {currentXp}");
    }
    public void AddLevel()
    {
        if(currentXp>requiredXp)
        {
            currentLevel+=1;
            requiredXp = (requiredXp + 100)*1.1;
        }
        else
        {

        }

        playerHud.updateXpText(currentXp,currentLevel,requiredXp);
    }
}


