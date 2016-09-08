using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class ClockScript : MonoBehaviour
{

    int seconds;
    int milliseconds;
	int lastTickTime;

	public bool tickAudio;
    public RectTransform hand;
    public Text text;
    public float totalTime;
    public float multiplier;
	public AudioSource audio;

	private bool running;

    void Start()
    {
        seconds = 0;
        milliseconds = 0;
		running = true;
        multiplier = 1;
		lastTickTime = 0;
        //hand = GameObject.Find("Hand").GetComponent<RectTransform>();
    }

	void Update()
	{
		if (running) 
		{
			totalTime += Time.deltaTime * multiplier;
			if (tickAudio && totalTime > lastTickTime + 1) {
				audio.Play ();
				lastTickTime = (int)totalTime;
			}
			milliseconds = (int)(totalTime * 10) % 10;
			seconds = (int)(totalTime);
			hand.localRotation = Quaternion.Euler(0, 0, -totalTime / 60.0f * 360.0f);
			text.text = seconds + ":" + milliseconds;
		}
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