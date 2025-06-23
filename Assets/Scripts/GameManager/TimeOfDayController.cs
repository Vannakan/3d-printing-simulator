using System;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.GameManager
{

    public static class TimeHelper
    {
        public static int ConvertToTwelveHour(int time)
        {
            if (time > 12) return time - 12;

            return time;
        }
    }
    internal class TimeOfDayController : MonoBehaviour
    {
        public static TimeOfDayController Instance { get; private set; }

        public float TimeScale = 60f; // 1 real second = 1 in-game minute
        public int Day { get; private set; } = 1;

        public DayOfWeek DayOfWeek => (DayOfWeek)Day;
        public float TimeOfDay { get; private set; } = 0f; // 0 to 24

        public event Action<float> OnTimeChanged;
        public event Action<int> OnDayChanged;
        private int lastMinute = -1;

        // How long does an hour in game take in real seconds
        public float HourIntervalSeconds;


        private void Awake()
        {
            if (Instance != null) Destroy(gameObject);
            Instance = this;
        }

        private void Start()
        {
            StartCoroutine(TickTime());
        }

        private IEnumerator TickTime()
        {
            while (true)
            {
                yield return new WaitForSeconds(HourIntervalSeconds);
                TimeOfDay++;

                if (TimeOfDay >= 24f)
                {
                    TimeOfDay -= 24f;
                    Day++;
                    //temp
                    if (Day > 6)
                        Day = 1;
                    OnDayChanged?.Invoke(Day);
                }

                OnTimeChanged?.Invoke(TimeOfDay);
            }
        }

        private void Update()
        {
            //TimeOfDay += (Time.deltaTime / 60f) * TimeScale;

            //if (TimeOfDay >= 24f)
            //{
            //    TimeOfDay -= 24f;
            //    Day++;
            //    //temp
            //    if (Day > 6)
            //        Day = 1;
            //    OnDayChanged?.Invoke(Day);
            //}

            //int currentMinute = Mathf.FloorToInt(TimeOfDay * 60);
            //if (currentMinute != lastMinute)
            //{
            //    lastMinute = currentMinute;
            //    OnTimeChanged?.Invoke(TimeOfDay);
            //}
        }
    }
}
