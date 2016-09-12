using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class SimpleGraphScript : MonoBehaviour {

	private SimpleGraph simpleGraph;

	void Start () {
		//Watch out for the position of the anchor! It should be in the bottom-mid for this to work properly
		simpleGraph = new SimpleGraph();
		Vector2 scaleFactor = new Vector2(Screen.width/GetComponentInParent<CanvasScaler> ().referenceResolution.x, Screen.height/GetComponentInParent<CanvasScaler> ().referenceResolution.y);
		Vector2 rectDims = new Vector2 (GetComponent<RectTransform> ().rect.width*scaleFactor.x, GetComponent<RectTransform> ().rect.height*scaleFactor.y);
		Vector2 rectPos = new Vector2 (Screen.width/2-GetComponent<RectTransform> ().anchoredPosition.x * scaleFactor.x, GetComponent<RectTransform> ().anchoredPosition.y * scaleFactor.y);
		simpleGraph.SetParams (new Vector2(Screen.width/2,rectPos.y), rectDims);
}

	public void NewValues(List<Vector2> list)
	{
		simpleGraph.NewValues (list);
	}

	void OnGUI()
	{
		simpleGraph.Draw ();
	}
}
