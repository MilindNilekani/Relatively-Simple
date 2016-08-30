using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SimultaneitySetupScript : MonoBehaviour {

    public GameObject leftPhotonPrefab;
    public GameObject rightPhotonPrefab;
    public GameObject leftWall;
    public GameObject rightWall;
    public GameObject emitter;

    private List<GameObject> leftPhotons;
	private List<GameObject> rightPhotons;

    private float speedOfLight = 15;
    private float playerSpeed = 0;
    private float leftPhotonVelocity = -0.05f;
    private float rightPhotonVelocity = 0.05f;
	private bool photonsEmitting;


    // Use this for initialization
    void Start()
    {
		leftPhotons = new List<GameObject> ();
		rightPhotons = new List<GameObject> ();
		photonsEmitting = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnGUI()
    {
        //GUI.TextArea(new Rect(10, 10, 100, 100), playerSpeed.ToString());
    }

    public void StartPhotonsClick()
    {
		if (photonsEmitting) {
			photonsEmitting = false;
			StopCoroutine ("EmitPhotons");
		}
		else {
			//calcPhotonSpeeds ();
			photonsEmitting = true;
			StartCoroutine ("EmitPhotons");
		}
    }

    public void ChangePhotonVelocity(float newSpeed)
    {
        speedOfLight = newSpeed;
    }

    void calcPhotonSpeeds()
    {
        leftPhotonVelocity = -playerSpeed/100 + -0.01f * speedOfLight;
        
        rightPhotonVelocity = -playerSpeed/100 + 0.01f * speedOfLight;
        if (rightPhotonVelocity < 0) rightPhotonVelocity = 0;
    }

    public void ChangeVel(float newVel)
    {
        //Debug.Log(newVel);
        playerSpeed = newVel;
		calcPhotonSpeeds ();
    }

	IEnumerator EmitPhotons()
	{
		leftPhotons.Add (GameObject.Instantiate (leftPhotonPrefab, emitter.transform.position, Quaternion.identity) as GameObject);
		rightPhotons.Add (GameObject.Instantiate (rightPhotonPrefab, emitter.transform.position, Quaternion.identity) as GameObject);
		StartCoroutine ("StartPhotons");
		while (true) {
			yield return new WaitForSeconds (0.25f);
			leftPhotons.Add (GameObject.Instantiate (leftPhotonPrefab, emitter.transform.position, Quaternion.identity) as GameObject);
			rightPhotons.Add (GameObject.Instantiate (rightPhotonPrefab, emitter.transform.position, Quaternion.identity) as GameObject);
		}
	}

    IEnumerator StartPhotons()
    {
		while (leftPhotons.Count > 0 || rightPhotons.Count > 0)
        { 
			if (leftPhotons.Count > 0)
            {
				leftPhotons.ForEach(leftPhoton => leftPhoton.transform.Translate(leftPhotonVelocity, 0, 0));
				for (int i = leftPhotons.Count - 1; i >= 0; i--) {
					if (leftPhotons [i].transform.position.x < leftWall.transform.position.x) {
						GameObject photon = leftPhotons [i];
						leftPhotons.RemoveAt (i);
						Destroy (photon);
					}
				}
            }
			if (rightPhotons.Count > 0)
			{
				rightPhotons.ForEach(rightPhoton => rightPhoton.transform.Translate (rightPhotonVelocity, 0, 0));
				for (int i = rightPhotons.Count-1; i>= 0; i--){
					if (rightPhotons[i].transform.position.x > rightWall.transform.position.x) {
						GameObject photon = rightPhotons [i];
						rightPhotons.RemoveAt (i);
						Destroy (photon);
					}
				}
				//rightPhotons.RemoveAll (rightPhoton => rightPhoton.transform.position.x > rightWall.transform.position.x);
            }
            yield return new WaitForSeconds(0.01f);
        }
    }
}
