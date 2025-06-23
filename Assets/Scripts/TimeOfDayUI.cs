using Assets.Scripts.GameManager;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimeOfDayUI : MonoBehaviour
{
    public TextMeshProUGUI Text;
    // Start is called before the first frame update
    void Start()
    {
        SetText(TimeOfDayController.Instance.TimeOfDay);
        TimeOfDayController.Instance.OnTimeChanged += SetText;
    }

    private void SetText(float e) 
    { 
        Text.text = $"{TimeOfDayController.Instance.DayOfWeek} {TimeHelper.ConvertToTwelveHour((int)e)}:00 {(e > 11 && e < 24 ? "(PM)" : "(AM)")}"; 
    }
// Update is called once per frame
void Update()
    {
        
    }
}
