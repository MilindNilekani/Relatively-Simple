using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SimultaneityToggleButtonScript : MonoBehaviour {

	public Sprite playImage;
	public Sprite stopImage;

	private bool photonsOn;

	// Use this for initialization
	void Start () {
		photonsOn = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OnClick()
	{
		if (photonsOn) {
			gameObject.GetComponent<Button> ().image.sprite = playImage;
		} 
		else {
			gameObject.GetComponent<Button> ().image.sprite = stopImage;
		}
		photonsOn = !photonsOn;
	}
}
