using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class RulerScript : MonoBehaviour {

	public const int scaleListSize = 20;

	List<Vector3> scaleList;
	Vector3 rulerDefaultScale;

	GameObject rulerText;


	// Use this for initialization
	void Start () {
		rulerDefaultScale = transform.localScale;
		scaleList = new List<Vector3> ();
		rulerText = GameObject.Find ("RulerText");
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 sum = new Vector3 (0, 0, 0);
		foreach (Vector3 scale in scaleList) {
			sum += scale;
		}
		if (scaleList.Count > 0) sum /= scaleList.Count;
		transform.localScale = sum;
	}

	public void ChangeRulerScaleSingle(float newScale)
	{
		scaleList.Add(new Vector3(rulerDefaultScale.x,newScale,rulerDefaultScale.z));
		if (scaleList.Count > scaleListSize)
		{
			scaleList.RemoveAt(0);
		}
	}

	public void ChangeRulerScale(Vector3 newScale)
	{
		scaleList.Add(Vector3.Scale(newScale,rulerDefaultScale));
		if (scaleList.Count > scaleListSize)
		{
			scaleList.RemoveAt(0);
		}
		rulerText.GetComponent<Text> ().text = (newScale.x).ToString("F2") + " m";
	}

	private IEnumerator ChangeRulerScaleCoroutine(Vector3 newScale)
	{
		float t = 0.0f;

		Vector3 start = transform.localScale;
		Vector3 end = newScale;

		while (t < 1.0f)
		{
			//Scale over .2 seconds
			t += (Time.deltaTime / 0.2f);
			transform.localScale = Vector3.Lerp(start, end, t);
			yield return null;
		}
	}
}
