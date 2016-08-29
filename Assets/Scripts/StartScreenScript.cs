using UnityEngine;
using System.Collections;

public class StartScreenScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void StartGame()
	{
		Application.LoadLevel (2);
	}

	public void StartGameLengthcontraction()
	{
		Application.LoadLevel (7);
	}

	public void HelpScreen()
	{
		Application.LoadLevel (3);
	}

    public void FeynmansExperimentScreen()
    {
        Application.LoadLevel(5);
    }

    public void SimultaneityExperimentScreen()
    {
        Application.LoadLevel(6);
    }

    public void Exit()
    {
        Application.LoadLevel(0);
    }
}
