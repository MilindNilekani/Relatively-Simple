using UnityEngine;
using System.Collections;

public class ConsoleDebug : MonoBehaviour {

	private static ConsoleDebug _instance;

	private string msg = "";

	public static ConsoleDebug Instance {
		get { 
			if (_instance == null) {
				_instance = GameObject.FindObjectOfType<ConsoleDebug> ();
			}
			return _instance; 
		}
	}

	void Awake()
	{
		_instance = this;
	}

	void OnGUI()
	{
		GUI.skin.label.fontSize = 40;
		GUI.Label(new Rect(10, 300, 1000, 100), msg);
	}

	public void Print(string inputMsg)
	{
		msg = inputMsg;

	}
}
