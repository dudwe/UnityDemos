using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Clock : MonoBehaviour
{
    [SerializeField]
    Transform hoursPivot, minutesPivot, secondPivot,miliSecondsPivot;
    const float hoursToDegrees = -30f,minutesToDegrees=-6f,secondsToDegrees=-6f,miliSecondsToDegrees=-0.36f;
    
    void Update(){
        Debug.Log(DateTime.Now);
        TimeSpan time = DateTime.Now.TimeOfDay;
        hoursPivot.localRotation = Quaternion.Euler(0,0,hoursToDegrees * (float) time.TotalHours);
        minutesPivot.localRotation = Quaternion.Euler(0,0,minutesToDegrees * (float) time.TotalMinutes);
        secondPivot.localRotation = Quaternion.Euler(0,0,secondsToDegrees * (float) time.TotalSeconds);
        miliSecondsPivot.localRotation = Quaternion.Euler(0,0,miliSecondsToDegrees * (float)time.TotalMilliseconds);
    }
}
