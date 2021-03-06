﻿using UnityEngine;
using System.Collections;
using UnityStandardAssets.Vehicles.Car;
using System;
using UnityStandardAssets.Utility;

public class ResetScript : MonoBehaviour {

    CarController controller;
    WaypointProgressTracker tracker;
    DateTime time;
    bool flag;

    public bool Stoped { get; private set; }
	// Use this for initialization


	void Start () {
        Stoped = false;
        controller = (CarController)this.GetComponent(typeof(CarController));
        tracker = (CriterianProgress)this.GetComponent(typeof(CriterianProgress));
	}
	
	// Update is called once per frame
	void Update () {
      //  Debug.Log(controller.CurrentSpeed);
     //   Debug.Log(string.Format("{0},{1},{2}", tracker.WayPointPosition.x, tracker.WayPointPosition.y, tracker.WayPointPosition.z));
        if (Stoped) return;
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
                if (DateTime.Now.Subtract(time).TotalMilliseconds > 2000)
                {
                    
                    this.transform.position = new Vector3(tracker.WayPointPosition.x, tracker.WayPointPosition.y, tracker.WayPointPosition.z);
                    this.transform.rotation = new Quaternion(tracker.WayPointDirection.x, tracker.WayPointDirection.y, tracker.WayPointDirection.z, tracker.WayPointDirection.w);
                    flag = false;
                }
                    
            }
        }
        else
        {
            flag = false;
        }
	}

    public void Stop()
    {
        this.Stoped = true;
        controller.Stop();
    }

}
