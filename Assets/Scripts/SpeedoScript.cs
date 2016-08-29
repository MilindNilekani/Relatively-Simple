using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;


public class SpeedoScript : MonoBehaviour {

	public const float MAX_SPEED = 6.0f;
	public const int velListSize = 20;

	Vector3 start;
	Vector3 end;
	float radius;
	GameObject pointer;
	GameObject speedText;
	float startAngle;
	float endAngle;
	float currAngle;
	public float t;
	float curr_t;

	List<float> velList;

	void Start () {
		pointer = GameObject.Find("SpeedoPointer");
		speedText = GameObject.Find ("SpeedText");
		start = pointer.GetComponent<RectTransform> ().anchoredPosition;
		radius = start.magnitude;
		startAngle = -Mathf.Atan (start.y/start.x);
		endAngle = startAngle + (3.0f/2.0f)*3.1415f;
		currAngle = 0;
		curr_t = 0;
		velList = new List <float>();
	}

	// Update is called once per frame
	void Update () {
		float sum = 0.0f;
		foreach (float vel in velList) {
			sum += vel;
		}
		if (velList.Count > 0) sum /= velList.Count;
		speedText.GetComponent<Text> ().text = ((sum * MAX_SPEED)).ToString("F1");
		currAngle = Mathf.Lerp(startAngle, endAngle, sum);
		pointer.GetComponent<RectTransform> ().anchoredPosition = new Vector2 (-Mathf.Cos (currAngle) * radius, Mathf.Sin (currAngle) * radius);
	}

	public void ChangeSpeed(float new_t)
	{
		velList.Add(new_t/MAX_SPEED);
		if (velList.Count > velListSize)
		{
			velList.RemoveAt(0);
		}

	}

}
