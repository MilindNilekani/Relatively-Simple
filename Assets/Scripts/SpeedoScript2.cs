using UnityEngine;
using System.Collections;

public class SpeedoScript2 : MonoBehaviour {

    Vector3 start;
    Vector3 end;
    GameObject pointer;
    float startTime;

	// Use this for initialization
	void Start () {
        pointer = GameObject.Find("SpeedoPointer");
		start = pointer.transform.localPosition;
		end =  pointer.transform.localPosition + new Vector3 (30, 0, 0);
	}
	
	// Update is called once per frame
	void Update () {
        pointer.transform.position = Slerp(start, end, Time.time-startTime);
		pointer.transform.position += transform.position;
		//Debug.Log (pointer.transform.position);
	}

	Vector3 Slerp(Vector3 start, Vector3 end, float frac)
	{
		if (frac > 1)
			return end;
		float radius = Vector3.Magnitude(start);
		float startAngle = Vector3.Angle (start, new Vector3(1,0,0));//Mathf.Atan(start.y / start.x);
		startAngle += 3.1415f;
		float endAngle = 3.1415f*2.0f - Vector3.Angle (end, new Vector3(1,0,0));//Mathf.Atan(end.y / end.x);
		float angle = startAngle + (endAngle-startAngle)*frac;
		Vector3 result = new Vector3(Mathf.Cos (angle), Mathf.Sin(angle), start.z)*radius;
		Debug.Log(result);

		return result;
			
	}
}
