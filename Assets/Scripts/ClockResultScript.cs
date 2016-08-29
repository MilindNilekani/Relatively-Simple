using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ClockResultScript : MonoBehaviour {

	public GameObject textBoxObj;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {

	}

	void ChangeTime(float time)
	{
		textBoxObj.GetComponent<Text>().text = (int)(time * 10) % 10 + ":" + (int)(time);
	}
}
