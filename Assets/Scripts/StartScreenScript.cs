using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartScreenScript : MonoBehaviour {

	public Image timeDilationSubMenu;
	public Image spaceContractionSubMenu;
	public Image simultaneitySubMenu;

	enum direction {IN, OUT};

	Vector3 subMenuPos;

	// Use this for initialization
	void Start () {
		subMenuPos = timeDilationSubMenu.GetComponent<RectTransform> ().anchoredPosition;

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OnClickPlayVideo()
	{
		Debug.Log ("Playing new video");
		Handheld.PlayFullScreenMovie ("intro 2.mp4", Color.black, FullScreenMovieControlMode.CancelOnInput);
	}

	public void OnTimeDilationButtonClick()
	{
		StartCoroutine (ToggleSubMenu(timeDilationSubMenu, direction.IN));
	}

	public void OnSpaceContractionClick()
	{
		StartCoroutine (ToggleSubMenu(spaceContractionSubMenu, direction.IN));
	}

	public void OnSimultaneityClick()
	{
		StartCoroutine (ToggleSubMenu(simultaneitySubMenu, direction.IN));
	}

	public void OnTimeDilationExitClick()
	{
		StartCoroutine (ToggleSubMenu(timeDilationSubMenu, direction.OUT));
	}

	public void OnSpaceContractionExitClick()
	{
		StartCoroutine (ToggleSubMenu(spaceContractionSubMenu, direction.OUT));
	}

	public void OnSimultaneityExitClick()
	{
		StartCoroutine(ToggleSubMenu(simultaneitySubMenu, direction.OUT));
	}

    //Choose which submenu to open
	IEnumerator ToggleSubMenu (Image a, direction dir)
	{
		a.GetComponent<RectTransform> ().anchoredPosition = (dir == direction.IN)? Vector3.zero:subMenuPos;
		yield return true;
	}

	public void StartSimulationTimeDilation()
	{
		SceneManager.LoadScene ("TimeDilationScene");
	}

	public void StartSimulationLengthContraction()
	{
		SceneManager.LoadScene ("SpaceContractionScene");
	}

	public void StartExperimentBarnAndLadder()
	{
		SceneManager.LoadScene ("BarnAndLadderScene");
	}

	public void HelpScreen()
	{
		SceneManager.LoadScene ("HelpScene");
	}

    public void StartFeynmansExperiment()
    {
		SceneManager.LoadScene ("FeynmansExperiment");
    }

    public void StartSimulationSimultaneity()
    {
		SceneManager.LoadScene ("SimultaneityExperimentScene");
    }

    public void Exit()
    {
		SceneManager.LoadScene ("StartScene");
    }
}
