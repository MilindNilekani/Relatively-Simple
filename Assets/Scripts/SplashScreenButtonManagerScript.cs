using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SplashScreenButtonManagerScript : MonoBehaviour {

	// Use this for initialization
	void Start () {}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void OnClick()
    {
        Application.LoadLevel(1);
    }

	public void OnClickVideo()
	{
		Handheld.PlayFullScreenMovie ("IntroVideo.mp4", Color.black, FullScreenMovieControlMode.CancelOnInput);
	}

	public void EndOfMovie()
	{
	}

}
