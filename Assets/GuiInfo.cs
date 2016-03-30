using UnityEngine;
using System.Collections;
using System.Linq;
using UnityStandardAssets.Utility;
using System.Collections.Generic;
using UnityStandardAssets.Vehicles.Car;
public class GuiInfo : MonoBehaviour {
    public GUIText timer;
    public GameObject[] Cars;
    public int Laps = 1;
    float raceTime = 0;
    List<CarWrapper> carWrappers;
    class CarWrapper
    {
        public GameObject Car;
        public string name;
        public Color color;
        public Time BestLap;
        public float Time = float.MaxValue;
        public int LapNumber = 1;
        public CriterianProgress progressComponent;
        public float progress { get { return progressComponent.progressDistance; } }

        public bool Finish { get; set; }
    }

	// Use this for initialization
	void Start () {
        this.carWrappers = Cars
            .Where(c => c != null)
            .Select(c => new CarWrapper() { 
                Car = c,
                name = ((WaypointProgressTracker)c.GetComponent("WaypointProgressTracker")).Circuit.gameObject.name,
                progressComponent = ((CriterianProgress)c.GetComponent("CriterianProgress")),
                color = ((ColorSelect)c.GetComponent("ColorSelect")).color
            }).ToList();
	}


    void Update()
    {
        raceTime = raceTime + 1 * Time.deltaTime;
        timer.text = raceTime.ToString("F4");
    }


   

    static string colorToHex(Color32 color)
    {
        string hex = color.r.ToString("X2") + color.g.ToString("X2") + color.b.ToString("X2");
        return hex;
    }



    int x = 0, y = 0;
    void OnGUI()
    {
        //var ordered = carWrappers.OrderByDescending(c=>c.Finish).OrderBy(c=>c.Time).OrderByDescending(c => c.progress);
        var ordered = carWrappers.OrderByDescending(c => c.progress).OrderBy(c => c.Time);

        string str = string.Join("\n", 
            ordered.Select((c, index) => string.Format("{0}. \t<color='#{3}'> ▀▄▀▄▀ </color>{1} \t {4} круг {5} ", index+1, c.name, c.progress, colorToHex(c.color), c.LapNumber, (c.Finish)?c.Time.ToString():"" )).ToArray());
        var currentStyle = new GUIStyle(GUI.skin.box);
        currentStyle.alignment = TextAnchor.UpperLeft;
        currentStyle.richText = true;
        GUI.Box(
            new Rect(x, y, 270, 100), string.Format("Позиция: \n {0}", str)
            ,currentStyle
            //   ,new GUIStyle() { alignment = TextAnchor.UpperLeft, border = new RectOffset(1, 1, 1, 1)}
            );

        
        //Debug.Log(str);
    }

    void OnTriggerEnter(Collider crossCollider)
    {
        var carWr = this.carWrappers.First(cw => cw.Car.GetComponentInChildren(typeof(BoxCollider)) == crossCollider);
       
        carWr.LapNumber++;
   
        if (carWr.LapNumber > this.Laps)
        {
            carWr.Finish = true;
            carWr.Time = raceTime;
            carWr.Car.GetComponent<ResetScript>().Stop();
        }
        if (this.carWrappers.All(c => c.Finish))
        {
           
        }
    }
}
