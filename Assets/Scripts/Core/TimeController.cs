using System;
using UnityEngine;

public class TimeController : IUpdatable
{
    public event Action OnDayTimeEnded;
    public event Action OnNightTimeEnded;
    
    private float dayDuration = 60f;
    private float nightDuration = 60f;

    private float currentTime;
    private bool isRunning;
    private TimePhase currentPhase;

    private enum TimePhase
    {
        Day,
        Night
    }

    public TimeController()
    {
        StartDay();
    }

    public void Pause() => isRunning = false;
    public void Resume() => isRunning = true;

    public void StartDay()
    {
        currentPhase = TimePhase.Day;
        currentTime = 0f;
        isRunning = true;
    }

    public void StartNight()
    {
        currentPhase = TimePhase.Night;
        currentTime = 0f;
        isRunning = true;
    }

    public void Update(float deltaTime)
    {
        if (!isRunning) return;

        currentTime += deltaTime;

        switch (currentPhase)
        {
            case TimePhase.Day:
                if (currentTime >= dayDuration)
                {
                    currentTime = 0f;
                    OnDayTimeEnded?.Invoke();
                    StartNight();
                }
                break;

            case TimePhase.Night:
                if (currentTime >= nightDuration)
                {
                    currentTime = 0f;
                    OnNightTimeEnded?.Invoke();
                    StartDay();
                }
                break;
        }
    }

    public float GetCurrentTime() => currentTime;
    public bool IsDay() => currentPhase == TimePhase.Day;
}