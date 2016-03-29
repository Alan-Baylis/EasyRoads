using UnityEngine;
using System.Collections;
using System.Linq;
using UnityStandardAssets.Utility;
public class GuiInfo : MonoBehaviour {

    public GameObject[] Cars;

	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
        //Debug.Log(1);
	
        //var ordered = Cars.Where(c => c != null).OrderBy(c => ((CriterianProgress)c.GetComponent("CriterianProgress")).progressDistance);

        //string str = string.Join("\n", ordered.Select(c => ((WaypointProgressTracker)c.GetComponent("WaypointProgressTracker")).Circuit.gameObject.name).ToArray());
        //Debug.Log(str);
	}
    class or
    {
        public string name;
        public float progress;
        public Color color;
    }

    static string colorToHex(Color32 color)
    {
        string hex = color.r.ToString("X2") + color.g.ToString("X2") + color.b.ToString("X2");
        return hex;
    }

    void OnGUI()
    {

        var ordered = Cars.Where(c => c != null).Select(c=>new or()
        {
            name =  ((WaypointProgressTracker)c.GetComponent("WaypointProgressTracker")).Circuit.gameObject.name,
            color = ((ColorSelect)c.GetComponent("ColorSelect")).color,
            progress =((CriterianProgress)c.GetComponent("CriterianProgress")).progressDistance 
        })
        .OrderByDescending(c => c.progress);
        
        string str = string.Join("\n",ordered.Select((c,index) =>string.Format("<color='#{3}'>{0}. \t {1} - прогресс {2,5:N1}</color>", index.ToString(), c.name, c.progress, colorToHex(c.color))).ToArray());
        var currentStyle = new GUIStyle(GUI.skin.box);
        currentStyle.alignment = TextAnchor.UpperLeft;
        currentStyle.richText = true;
        GUI.Box(
            new Rect(0, 0, 300, 100), string.Format("Позиция: \n {0}", str)
            ,currentStyle
            //   ,new GUIStyle() { alignment = TextAnchor.UpperLeft, border = new RectOffset(1, 1, 1, 1)}
            );

        
        //Debug.Log(str);


    }
}
