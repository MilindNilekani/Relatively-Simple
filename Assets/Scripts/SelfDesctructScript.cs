using UnityEngine;
using System.Collections;

public class SelfDesctructScript : MonoBehaviour {

	public float lifetime;
	private float startTime;

	// Use this for initialization
	void Start () {
		startTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.time > startTime + lifetime) {
			Destroy (gameObject);
		}
	}
}
