using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ChartManagerScript : MonoBehaviour {
    public int accLogMemory;
    public int numberOfPoints;
	public SimpleGraph lineGraph3;

    private List<Vector2> accLog;
    private List<Vector2> compactAccLog;

    private float accumulator;
    private int valuesPerPoint;

	// Use this for initialization
	void Awake () {

        accLog = new List <Vector2>();
        compactAccLog = new List<Vector2>();

		lineGraph3 = new SimpleGraph(); 

        valuesPerPoint = accLogMemory / numberOfPoints;
	}
	
	// Update is called once per frame
	void Update () {
        compactAccLog.Clear();

        if (accLog.Count < accLogMemory)            //Ignore the graph calculations if we don't have enough calculated values yet
            return;

//		for (int i = 0; i < numberOfPoints; i++) {
//			compactAccLog.Add (new Vector2(i, Random.Range(0,20)));
//		}

        for (int i = 0; i < numberOfPoints; i++ )
        {
            accumulator = 0;
            for (int j = 0; j < valuesPerPoint; j++)
            {
                accumulator += accLog[i * valuesPerPoint + j].y;
            }
            compactAccLog.Add(new Vector2(i, accumulator / valuesPerPoint));

			//compactAccLog.Add (new Vector2 (i, Random.Range(0,10)));
        }
		lineGraph3.NewValues(compactAccLog);
	}

	void OnGUI()
	{
		lineGraph3.Draw ();
	}

    void UpdateAccLog(Vector2 acc)
    {
        accLog.Add(acc);
        if (accLog.Count > accLogMemory)
        {
            accLog.RemoveAt(0);
        }
    }
}
