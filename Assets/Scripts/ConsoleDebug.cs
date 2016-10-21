using UnityEngine;
using System.Collections;

public class ConsoleDebug : MonoBehaviour {

	private static ConsoleDebug _instance;

	private string msg = "";
	private string msg2 = "";

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
//		GUI.skin.label.fontSize = 40;
//		GUI.Label(new Rect(10, 300, 1000, 100), msg);
//		GUI.Label(new Rect(10, 400, 1000, 100), msg2);
	}

	public void Print(string inputMsg)
	{
		msg = inputMsg;
	}

	public void Print(string inputMsg, int line)
	{
		if (line == 2)
			msg2 = inputMsg;
	}
}
