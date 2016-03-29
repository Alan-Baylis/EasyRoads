using UnityEngine;
using System.Linq;
using System.Collections;
using System;


public class MovingBehavior : MonoBehaviour
{


    public GameObject[] cars;
    // Use this for initialization
    Camera camera;
    public float k = 10;
    float fmin;
    void Start()
    {
        camera = (Camera)this.GetComponent("Camera");
        fmin = camera.fieldOfView;
    }

    // Update is called once per frame
    void Update()
    {
        float xmin = float.MaxValue, xmax = float.MinValue, zmin = float.MaxValue, zmax = float.MinValue;
        for (int i = 0; i < cars.Length; i++)
        {
            if (xmin > cars[i].transform.position.x) xmin = cars[i].transform.position.x;
            if (xmax < cars[i].transform.position.x) xmax = cars[i].transform.position.x;
            if (zmin > cars[i].transform.position.z) zmin = cars[i].transform.position.z;
            if (zmax < cars[i].transform.position.z) zmax = cars[i].transform.position.z;
        }
        float x = (xmin + xmax) / 2;
        float z = (zmin + zmax) / 2;
        float distance = (float)Math.Sqrt(Math.Pow(xmax - xmin, 2) + Math.Pow(zmax - zmin, 2));
        camera.fieldOfView = Math.Min(Math.Max(distance / k, fmin), 56);
        Debug.Log(string.Format("fieldOfView {0}", camera.fieldOfView));

        this.transform.position = new Vector3(x, this.transform.position.y, z);
      //  Debug.Log(string.Format("x = {0}, z = {2}, distance = {3}", this.transform.position.x, this.transform.position.y, this.transform.position.z, distance));
        //Debug.Log(string.Format("fieldOfView {0}", distance / k));
    }
}
