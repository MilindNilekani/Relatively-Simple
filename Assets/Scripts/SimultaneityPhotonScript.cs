using UnityEngine;
using System.Collections;

public class SimultaneityPhotonScript : MonoBehaviour {

	public Vector3 target;

	private Vector3 direction;
	private float velocity;
	private Transform img;
	private float startTime;

	// Use this for initialization
	void Start () {
		
	}

	public void InitializeParams(float vel, Vector3 t)
	{
		velocity = vel;
		target = t;
		direction = (target - transform.position).normalized;
		img = transform.FindChild ("PhotonImage");
		Vector3 dir = -Mathf.Sign(vel)*(target - img.transform.position);
		float angle = Mathf.Atan2(dir.y,dir.x) * Mathf.Rad2Deg;
		img.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
		startTime = Time.time;
	}

	// Update is called once per frame
	void Update () {
		transform.Translate (velocity * direction);
		//Debug.Log(Mathf.Sign(target-img.transform.position));
		if (Vector3.Dot((target - transform.position), direction) < 0) {
			Destroy (gameObject);
		}
	}
}
