using UnityEngine;
using System.Collections;
using UnityStandardAssets.Vehicles.Car;
using System;
using UnityStandardAssets.Utility;

public class ResetScript : MonoBehaviour {

    CarController controller;
    WaypointProgressTracker tracker;
    DateTime time;
    bool flag;
	// Use this for initialization

	void Start () {
        controller = (CarController)this.GetComponent(typeof(CarController));
        tracker = (WaypointProgressTracker)this.GetComponent(typeof(WaypointProgressTracker));
	}
	
	// Update is called once per frame
	void Update () {
      //  Debug.Log(controller.CurrentSpeed);
       
        if (controller.CurrentSpeed < 1)
        {
         //   Debug.Log(flag.ToString());
            if (!flag)
            {
                flag = true;
                time = DateTime.Now;
            }
            else
            {
               // Debug.Log(DateTime.Now.Subtract(time).TotalMilliseconds);
                if (DateTime.Now.Subtract(time).TotalMilliseconds > 1000)
                {
                    Debug.Log("Ok");
                    this.transform.position = new Vector3(tracker.WayPointPosition.x, tracker.WayPointPosition.y, tracker.WayPointPosition.z);
                    flag = false;
                }
                    
            }
        }
        else
        {
            flag = false;
        }
	}
}
