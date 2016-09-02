using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SimultaneitySetupScript : MonoBehaviour {

    public GameObject frontPhotonPrefab;
    public GameObject backPhotonPrefab;
    public GameObject frontWall;
    public GameObject backWall;
    public GameObject emitter;

    private List<GameObject> frontPhotons;
	private List<GameObject> backPhotons;

    private float speedOfLight = 15;
    private float playerSpeed = 0;
    private float frontPhotonVelocity = -0.05f;
    private float backPhotonVelocity = 0.05f;
	private Vector2 frontPhotonDirection;
	private Vector2 backPhotonDirection;
	private bool photonsEmitting;


    // Use this for initialization
    void Start()
    {
		frontPhotons = new List<GameObject> ();
		backPhotons = new List<GameObject> ();
		photonsEmitting = false;

		frontPhotonDirection = (frontWall.transform.position - transform.position).normalized;
		backPhotonDirection = (backWall.transform.position - transform.position).normalized;

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
		frontPhotonVelocity = 0.005f*(-playerSpeed+ speedOfLight);
        
		backPhotonVelocity = 0.005f*(playerSpeed + speedOfLight);
        if (frontPhotonVelocity < 0) frontPhotonVelocity = 0;
    }

    public void ChangeVel(float newVel)
    {
        //Debug.Log(newVel);
        playerSpeed = newVel;
		calcPhotonSpeeds ();
    }

	IEnumerator EmitPhotons()
	{
		while (true) {
			GameObject newPhoton = GameObject.Instantiate (frontPhotonPrefab, emitter.transform.position, Quaternion.identity) as GameObject;
			newPhoton.GetComponent<SimultaneityPhotonScript> ().InitializeParams (frontPhotonVelocity, frontWall.transform.position);
			newPhoton.transform.parent = transform;

			GameObject newPhoton2 = GameObject.Instantiate (backPhotonPrefab, emitter.transform.position, Quaternion.identity) as GameObject;
			newPhoton2.GetComponent<SimultaneityPhotonScript> ().InitializeParams (backPhotonVelocity, backWall.transform.position);
			newPhoton2.transform.parent = transform;

			yield return new WaitForSeconds (0.25f);
		}
	}

//    IEnumerator StartPhotons()
//    {
//		while (frontPhotons.Count > 0 || backPhotons.Count > 0)
//        { 
//			if (frontPhotons.Count > 0)
//            {
//				frontPhotons.ForEach(frontPhoton => frontPhoton.transform.Translate(frontPhotonVelocity*frontPhotonDirection));
//				for (int i = frontPhotons.Count - 1; i >= 0; i--) {
//					if (frontPhotons [i].transform.position < frontWall.transform.position.x) {
//						GameObject photon = frontPhotons [i];
//						frontPhotons.RemoveAt (i);
//						Destroy (photon);
//					}
//				}
//            }
//			if (backPhotons.Count > 0)
//			{
//				backPhotons.ForEach(backPhoton => backPhoton.transform.Translate (backPhotonVelocity*backPhotonDirection));
//				for (int i = backPhotons.Count-1; i>= 0; i--){
//					if (backPhotons[i].transform.position.x > backWall.transform.position.x) {
//						GameObject photon = backPhotons [i];
//						backPhotons.RemoveAt (i);
//						Destroy (photon);
//					}
//				}
//				//backPhotons.RemoveAll (backPhoton => backPhoton.transform.position.x > backWall.transform.position.x);
//            }
//            yield return new WaitForSeconds(0.01f);
//        }
//    }
}
