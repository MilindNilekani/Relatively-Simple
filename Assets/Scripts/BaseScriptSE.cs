using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;


public class BaseScriptSE : MonoBehaviour {

	public GameObject speedometer;
    public GameObject simultaneitySetup;
    public GameObject regularClock;
    public GameObject warpedClock;
	public GameObject loadingScreen;

    private float speedOfLight;


	public void SliderChanged(float newVal)
	{
        simultaneitySetup.SendMessage("ChangePhotonVelocity", speedOfLight);
	}

    public void OnBack()
    {
        Application.LoadLevel(1);
    }

    void Update()
    {
        //Flashes screen and calls the OnTouch function when a double finger tap is detected
        if (Input.touchCount == 2 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            StartCoroutine("FlashScreen");
        }

		if (Input.GetKeyDown(KeyCode.Escape))
		{
			Application.LoadLevel(0);
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

	public void ChangeSpeed(float calcVel)
	{
		speedometer.SendMessage ("ChangeSpeed", calcVel);
		simultaneitySetup.SendMessage ("ChangeVel", calcVel);
	}

	public void ChangeRulerScale(Vector3 scale)
	{
		//ruler.SendMessage("ChangeRulerScale", scale);
	}

	public void ChangeRotation(float angle)
	{
		simultaneitySetup.transform.rotation = Quaternion.Euler (0, 0, 90-angle);
	}
}
