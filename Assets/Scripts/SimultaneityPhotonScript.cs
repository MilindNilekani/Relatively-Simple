using UnityEngine;
using System.Collections;

public class SimultaneityPhotonScript : MonoBehaviour {

	public GameObject target;

	private float velocity;

	// Use this for initialization
	void Start () {
		
	}

	public void InitializeParams(float vel, Vector3 target)
	{
		velocity = vel;
		Vector3 dir = target - transform.position;
		float angle = Mathf.Atan2(dir.y,dir.x) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
	}

	// Update is called once per frame
	void Update () {
		transform.Translate (velocity/10 * transform.up);
	}
}
