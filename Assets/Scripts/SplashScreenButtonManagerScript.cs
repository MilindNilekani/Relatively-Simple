using UnityEngine;
using System.Collections;

public class SplashScreenButtonManagerScript : MonoBehaviour {

    

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void OnClick()
    {
        Application.LoadLevel(1);
    }

	public void OnClickVideo()
	{
		Application.LoadLevel (1);
	}
}
