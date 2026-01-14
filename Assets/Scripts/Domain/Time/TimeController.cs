// using System;
// using UnityEngine;
//
// public class TimeController : IUpdatable
// {
//     public event Action OnDayTimeEnded;
//     public event Action OnNightTimeEnded;
//
//     public float dayDuration { get; private set; } = 15f;
//     public float nightDuration{ get; private set; } = 15f;
//
//     private float currentTime;
//     private bool isRunning;
//     private TimePhase currentPhase;
//
//     private enum TimePhase
//     {
//         Day,
//         Night
//     }
//
//     public TimeController()
//     {
//         StartDay();
//     }
//
//     public void Pause() => isRunning = false;
//     public void Resume() => isRunning = true;
//
//     public void StartDay()
//     {
//         currentPhase = TimePhase.Day;
//         currentTime = 0f;
//         isRunning = true;
//     }
//
//     public void StartNight()
//     {
//         currentPhase = TimePhase.Night;
//         currentTime = 0f;
//         isRunning = true;
//     }
//
//     public void Update(float deltaTime)
//     {
//         
//         if (!isRunning) return;
//
//         currentTime += deltaTime;
//
//         switch (currentPhase)
//         {
//             case TimePhase.Day:
//                 if (currentTime >= dayDuration)
//                 {
//                     OnDayTimeEnded?.Invoke();
//                     Pause();
//                 }
//                 break;
//
//             case TimePhase.Night:
//                 if (currentTime >= nightDuration)
//                 {
//                     OnNightTimeEnded?.Invoke();
//                     Pause();
//                 }
//                 break;
//         }
//     }
//
//     public float GetCurrentTime() => currentTime;
//     public bool IsDay() => currentPhase == TimePhase.Day;
//
//     public bool isPause()
//     {
//         if(isRunning) return false;
//         return true;
//     }
// }