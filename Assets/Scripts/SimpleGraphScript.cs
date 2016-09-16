using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class SimpleGraphScript : MonoBehaviour {

	public RenderTexture renderTexture; // renderTextuer that you will be rendering stuff on
	public Renderer renderer; // renderer in which you will apply changed texture

	private Texture2D texture;
	private SimpleGraph simpleGraph;
	private List<Vector2> values;
	private int n = 0;
	int at=0;

	void Start () {
		//Watch out for the position of the anchor! It should be in the bottom-mid for this to work properly
		simpleGraph = new SimpleGraph();
		texture = new Texture2D (renderTexture.width, renderTexture.height);
		renderer.material.mainTexture =  texture;
//		Vector2 scaleFactor = new Vector2(Screen.width/GetComponentInParent<CanvasScaler> ().referenceResolution.x, Screen.height/GetComponentInParent<CanvasScaler> ().referenceResolution.y);
//		Vector2 rectDims = new Vector2 (GetComponent<RectTransform> ().rect.width*scaleFactor.x, GetComponent<RectTransform> ().rect.height*scaleFactor.y);
//		Vector2 rectPos = new Vector2 (Screen.width / 2 - GetComponent<RectTransform> ().anchoredPosition.x /* * scaleFactor.x*/, GetComponent<RectTransform> ().anchoredPosition.y*scaleFactor.y);
//		simpleGraph.SetParams (new Vector2( Screen.width/2,rectPos.y), rectDims);
}

	public void NewValues(List<Vector2> newValues)
	{
		values = newValues;
		n = values.Count;

		List<float> smoother = new List<float>(){0.0f, 0.0f, 0.0f, 0.0f, 0.0f};
		for (int i = 0; i < n; i++) {
			smoother.Add (values [i].y);
			smoother.RemoveAt (0);
			float sum = 0.0f;
			foreach (float value in smoother)
				sum += value;
			sum /= 4;
			values [i] = new Vector2 (values [i].x, sum);
		}
	}

	void Update()
	{
		DrawGraph ();
	}

	void DrawGraph()
	{
		for (int i=0; i<n-1; i++) {
			Vector2 pointA = values [i];
			Vector2 pointB = values[i+1];
			//Drawing.DrawLine(pointA, pointB, new Color(0.16f, 0.75f, 0.99f), 3.0f);
//			DrawLine(pointA, pointB, new Color(0.16f, 0.75f, 0.99f));
		}
		DrawLine(new Vector2(0, 0), new Vector2(200,200), new Color(0.16f, 0.75f, 0.99f));

	}

	public void DrawLine(Vector2 pointA, Vector2 pointB, Color color)
	{
		RenderTexture.active = renderTexture; 
		//don't forget that you need to specify rendertexture before you call readpixels
		//otherwise it will read screen pixels.
		texture.ReadPixels (new Rect (0, 0, renderTexture.width, renderTexture.height), 0, 0);
		for (int i = (int)pointA.x; i < (int)pointB.x; i++) {
			float slope = (pointB.y - pointA.y) / (pointB.x - pointA.x);
			texture.SetPixel (i, (int)pointA.y + ((i - (int)pointA.x) * (int)slope), color);
		}
		texture.Apply (); 
		RenderTexture.active = null; //don't forget to set it back to null once you finished playing with it. 

	}


	void OnGUI()
	{
		
	}
}
