using UnityEngine;
using System.Collections;

public class BaseScript : MonoBehaviour {
	public GameObject regularClock;
    public GameObject warpedClock;
	public GameObject ruler;
	public GameObject speedometer;
	public GameObject loadingScreen;

    void Start()
    {
		loadingScreen = GameObject.Find ("Loading Screen");
    }

    void Update()
    {

		if (Input.GetKeyDown(KeyCode.Escape))
		{
			Application.LoadLevel(1);
		}
    }

	public void OnButtonPress()
	{
		loadingScreen.transform.localPosition = new Vector3 (0, 0, -120);
		StartCoroutine ("DisplayProcessingScreen");
	}

	IEnumerator DisplayProcessingScreen()
	{
		yield return new WaitForSeconds(0.5f);
		Summarize();
		yield return null;
	}

	void Summarize()
	{		
		PlayerManager.Instance.Summarize (regularClock.GetComponent<ClockScript>().totalTime, warpedClock.GetComponent<ClockScript>().totalTime);
		Application.LoadLevel(4);
	}

	public void ChangeSpeed(float[] velArr)
	{
		float calcVel = velArr [0];
		speedometer.SendMessage ("ChangeSpeed", calcVel);
	}

	public void ChangeRulerScale(Vector3 scale)
	{
		ruler.SendMessage("ChangeRulerScale", scale);
	}

	public void ChangeRotation(float angle)
	{
		
	}
}
