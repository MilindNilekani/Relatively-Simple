using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ChartManagerScript : MonoBehaviour {
    //ATTACH CHARTINGSCRIPT TO SAME GAMEOBJECT AND KEEP GAMEOBJECT SIMPLE GRAPH ALSO AS THIS FOR DRAWING LINE GRAPH

    public int accLogMemory;
    public int numberOfPoints;
	//public SimpleGraph lineGraph3;
	public GameObject simpleGraph;

    private List<Vector2> accLog;
    private List<Vector2> compactAccLog;
	private SimpleGraphScript simpleGraphScript;

    private float accumulator;
    private int valuesPerPoint;

	// Use this for initialization
	void Awake () {

        accLog = new List <Vector2>();
        compactAccLog = new List<Vector2>();

        valuesPerPoint = accLogMemory / numberOfPoints; //4

		simpleGraphScript = simpleGraph.GetComponent<SimpleGraphScript> ();
	}
	
	// Update is called once per frame
	void Update () {
        compactAccLog.Clear(); //Clear previous list

        if (accLog.Count < accLogMemory)            //Ignore the graph calculations if we don't have enough calculated values yet
            return;

        //Assign line graph values
        for (int i = 0; i < numberOfPoints; i++ )
        {
            accumulator = 0;
            for (int j = 0; j < valuesPerPoint; j++)
            {
                accumulator += accLog[i * valuesPerPoint + j].y;
            }
            compactAccLog.Add(new Vector2(i, accumulator / valuesPerPoint));
        }

        //Draw line graph
		simpleGraphScript.NewValues (compactAccLog);
	}

	void OnGUI()
	{
		//lineGraph3.Draw ();
	}

    //Called from Player Manager in fixed udpate based on accelaration values
    void UpdateAccLog(Vector2 acc)
    {
        accLog.Add(acc);
        if (accLog.Count > accLogMemory)
        {
            accLog.RemoveAt(0);
        }
    }
}
