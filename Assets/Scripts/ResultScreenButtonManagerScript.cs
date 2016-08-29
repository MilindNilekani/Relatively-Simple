using UnityEngine;
using System.Collections;

public class ResultScreenButtonManagerScript : MonoBehaviour {

	private const int numGraphs = 4;

	public GameObject[] graph = new GameObject[numGraphs];
	public int currGraph;

	// Use this for initialization
	void Start () {
		currGraph = 0;
		foreach (GameObject g in graph) 
		{
			g.GetComponent<CanvasGroup> ().alpha = 0f;
		}
		graph [0].GetComponent<CanvasGroup> ().alpha = 1f;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnExitPressed()
	{
        Application.LoadLevel(1);
	}

	public void OnNextPressed()
	{
		graph[currGraph].GetComponent<CanvasGroup>().alpha = 0f;
		currGraph = ++currGraph % 4;
		graph[currGraph].GetComponent<CanvasGroup>().alpha = 1f;
	}
}
