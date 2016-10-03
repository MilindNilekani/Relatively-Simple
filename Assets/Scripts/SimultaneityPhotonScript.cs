using UnityEngine;
using System.Collections;

public class SimultaneityPhotonScript : MonoBehaviour {

	public Transform target;
	public GameObject setup;

	private Vector3 direction;
	private float velocity;
	private Transform img;
	private float startTime;
	private bool facingForward; 

	// Use this for initialization
	void Start () {
		setup = GameObject.Find ("SimultaneitySetup");
	}

	public void InitializeParams(float vel, Transform t, bool heading)
	{
		velocity = vel;
		target = t;
		direction = (target.position-transform.position).normalized;
		img = transform.FindChild ("PhotonImage");
		Vector3 dir = -direction; //-Mathf.Sign(vel)*(target.localPosition - img.transform.parent.localPosition);
		float angle = Mathf.Atan2(dir.y,dir.x) * Mathf.Rad2Deg;
		img.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
		startTime = Time.time;
		facingForward = heading;
	}

	public void ChangeVel (float frontVel, float backVel)
	{
		if (facingForward)
			velocity = frontVel;
		else
			velocity = backVel;
	}

	// Update is called once per frame
	void Update () {
		transform.Translate (velocity * direction);
		//Debug.Log(Mathf.Sign(target-img.transform.position));
		Debug.Log(Vector3.Dot((target.position - transform.position), direction));
		if (Vector3.Dot((target.position - transform.position), direction) <= 0) {
			setup.SendMessage ("PlayHit");
			Destroy (gameObject);
		}
	}
}
