using UnityEngine;
using System.Collections;

public class CarLapsCounter : MonoBehaviour
{
    byte crossed = 0;

    void OnGUI()
    {
        if (crossed == 3)
        {
            GUI.Label(new Rect(10, 10, 100, 20), "Finished!");
        }
    }
    

    //bool raceIsFinished = false;
    //byte lapsCounter = 0;

    //void OnTriggerEnter()
    //{
    //    Debug.Log("Crossed");
    //    lapsCounter++;
    //    if (lapsCounter > 10)
    //    {
    //        raceIsFinished = true;
    //    }
    //}
    //void OnGUI()
    //{
    //    if (raceIsFinished)
    //    {
    //        GUI.Label(new Rect(10, 10, 100, 20), "Finished!");
    //    }
    //}
}
