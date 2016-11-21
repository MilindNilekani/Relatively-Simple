using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SplashScreenButtonManagerScript : MonoBehaviour {
   
    //Play button OnClick
    public void OnClick()
    {
        Application.LoadLevel(1);
    }

    //Intro Video OnClick
	public void OnClickVideo()
	{
		Handheld.PlayFullScreenMovie ("IntroVideo.mp4", Color.black, FullScreenMovieControlMode.CancelOnInput);
	}

}
