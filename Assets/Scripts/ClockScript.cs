using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class ClockScript : MonoBehaviour
{

    private int seconds;
    private int milliseconds;

    public RectTransform hand;
    public Text text;

    public float totalTime;
    public float multiplier;

	private bool running;

    void Update()
    {
		if (running) 
		{
			totalTime += Time.deltaTime * multiplier;
			milliseconds = (int)(totalTime * 10) % 10;
			seconds = (int)(totalTime);
            hand.localRotation = Quaternion.Euler(0, 0, -totalTime / 60.0f * 360.0f);
            text.text = seconds + ":" + milliseconds;
		}
    }

    void Start()
    {
        seconds = 0;
        milliseconds = 0;
		running = true;
        multiplier = 1;
        //hand = GameObject.Find("Hand").GetComponent<RectTransform>();
    }

    void ChangeSpeed(float mul)
    {
        multiplier = mul;
    }

	void ChangeTime(float time)
	{
		totalTime = time;
		milliseconds = (int)(totalTime * 10) % 10;
		seconds = (int)(totalTime);
        hand.localRotation = Quaternion.Euler(0, 0, -totalTime / 60.0f * 360.0f);
	}

	void Pause()
	{
		running = false;
	}

	void UnPause()
	{
		running = true;
	}

}