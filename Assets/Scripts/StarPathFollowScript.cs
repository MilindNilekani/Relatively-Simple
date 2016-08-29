using UnityEngine;
using System.Collections;

public class StarPathFollowScript : MonoBehaviour {

    public int star;

	// Use this for initialization
	void Start () {
	    switch(star)
        {
            case 1:
                //transform.FollowPath("Star3Path", 80f, Mr1.FollowType.Loop);
                break;
            case 2:
                //transform.FollowPath("Star4Path", 150f, Mr1.FollowType.Loop);
                break;
            case 3:
                //transform.FollowPath("Star2Path 1", 80f, Mr1.FollowType.Loop);
                break;
            case 4:
                //transform.FollowPath("Star1Path", 150f, Mr1.FollowType.Loop);
                break;
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
