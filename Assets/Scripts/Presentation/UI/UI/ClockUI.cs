// using UnityEngine;
//
// public class ClockUI : MonoBehaviour
// {
//     [SerializeField] private GameObject ClockHead;
//     private float followSpeed = 5f;
//     
//     private TimeController timeController;
//     private float time;
//     private bool phase;
//
//     public void Bind(TimeController timeController)
//     {
//         this.timeController = timeController;
//         time = timeController.GetCurrentTime();
//         phase=timeController.IsDay();
//     }
//
//     private void Update()
//     {
//         if (timeController == null)
//             return;
//
//         time = timeController.GetCurrentTime();
//         phase = timeController.IsDay();
//         
//         float t;
//         if (phase) t = (time / timeController.dayDuration);
//         else t = (time / timeController.nightDuration);
//         
//         float targetAngle;
//
//         if (phase)
//         {
//             targetAngle = Mathf.Lerp(180f, 0f, t);
//         }
//         else
//         {
//             targetAngle = Mathf.Lerp(0f, -180f, t);
//         }
//
//         ClockHead.transform.localRotation =
//             Quaternion.Lerp(
//                 ClockHead.transform.localRotation,
//                 Quaternion.Euler(0f, 0f, targetAngle),
//                 followSpeed * Time.deltaTime
//             );
//     }
// }