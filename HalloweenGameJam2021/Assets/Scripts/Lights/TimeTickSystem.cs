using System;
using UnityEngine;

public static class TimeTickSystem
{
    public class OnTimeEventArgs : EventArgs
    {
        public float timeOfDay;
    }

    public static event EventHandler<OnTimeEventArgs> OnLightFires;
    public static event EventHandler<OnTimeEventArgs> OnExtinguishFires;

    private static GameObject timeTickSystemObject;
    private static TimeTickSystemObject timeTickSystemComponent;
    private static float timeOfDay, timeOfDayPrevious, secondsPerSecond = 180f;
    private static bool areFiresLit;
    private static Vector3 hmsOfDay;

    public static void Create()
    {
        if (timeTickSystemObject == null)
        {
            timeTickSystemObject = new GameObject("TimeTickSystem");
            timeTickSystemComponent = timeTickSystemObject.AddComponent<TimeTickSystemObject>();
        }
    }

    public static bool AreFiresLit
    {
        get { return areFiresLit; }
    }

    public static float SecondsPerSecond
    {
        get { return secondsPerSecond; }
        set { secondsPerSecond = value; }
    }

    public static float TimeOfDay
    {
        get { return timeOfDay; }
        set
        {
            timeOfDay = value;
            timeOfDayPrevious = timeOfDay; // Could subtract a very small number;
            hmsOfDay = FloatToHMS(timeOfDay);
            timeTickSystemComponent.TestTimeEventsOnSetTime();
        }
    }

    public static Vector3 HMSOfDay
    {
        get { return hmsOfDay; }
        set
        {
            TimeOfDay = HMSToFloat(hmsOfDay.x, hmsOfDay.y, hmsOfDay.z);
        }
    }

    public static float HMSToFloat(float hour, float minute, float second)
    {
        return 3600f * hour + 60f * minute + second;
    }

    public static Vector3 FloatToHMS(float time)
    {
        Vector3 temp = Vector3.zero;
        temp.x = Mathf.Floor(time / 3600);
        time -= temp.x * 3600f;
        temp.y = Mathf.Floor(time / 60);
        temp.z = time - temp.y * 60f;
        return temp;
    }

    public static bool TimeFallsBetween(float currentTime, float startTime, float endTime)
    {
        if (startTime < endTime)
        {
            if (currentTime >= startTime && currentTime <= endTime) return true;
            else return false;
        }
        else
        {
            if (currentTime < startTime && currentTime > endTime) return false;
            else return true;
        }
    }

    private class TimeTickSystemObject : MonoBehaviour
    {
        private void Update()
        {
            timeOfDay += Time.deltaTime * secondsPerSecond;
            if (timeOfDay > 86400) // 24 hours * 60 minutes * 60 seconds = 86400 = Midnight
            {
                //days += 1;
                timeOfDay -= 86400;
            }
            TestTimeEvents();
            timeOfDayPrevious = timeOfDay;
        }

        public void TestTimeEvents()
        {
            // You should parameterize these times, or set them from another script
            if (timeOfDayPrevious < HMSToFloat(18f, 0f, 0f) && timeOfDay >= HMSToFloat(18f, 0f, 0f))
            {
                //if (OnLightFires != null) OnLightFires(this, new OnTimeEventArgs { timeOfDay = timeOfDay });
                OnLightFires?.Invoke(this, new OnTimeEventArgs { timeOfDay = timeOfDay });
                areFiresLit = true;
            }
            if (timeOfDayPrevious < HMSToFloat(1f, 0f, 0f) && timeOfDay >= HMSToFloat(1f, 0f, 0f))
            {
                OnExtinguishFires?.Invoke(this, new OnTimeEventArgs { timeOfDay = timeOfDay });
                areFiresLit = false;
            }
        }

        public void TestTimeEventsOnSetTime()
        {
            // You should parameterize these times, or set them from another script
            if (TimeFallsBetween(timeOfDay, HMSToFloat(18f, 0f, 0f), HMSToFloat(1f, 0f, 0f)))
            {
                OnLightFires?.Invoke(this, new OnTimeEventArgs { timeOfDay = timeOfDay });
                areFiresLit = true;
            } else 
            {
                OnExtinguishFires?.Invoke(this, new OnTimeEventArgs { timeOfDay = timeOfDay });
                areFiresLit = false;
            }
        }
    }
}