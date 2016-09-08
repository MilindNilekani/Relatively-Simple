using UnityEngine;
using System.Collections;

public class MainMenuButtonScript : MonoBehaviour {

	public GameObject subMenuPrefab;

	private GameObject subMenu;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OnClick(){
		subMenu = Instantiate(subMenuPrefab);
		subMenu.transform.parent = transform.parent;
		StartCoroutine ("OpenSubMenu");
	}

	IEnumerator OpenSubMenu()
	{
		for (float t = 0; t <= 1; t += 0.1f) {
			subMenu.transform.localPosition = Vector3.Lerp (transform.localPosition, Vector3.zero, t);
			subMenu.transform.localScale = Vector3.Lerp (Vector3.zero, Vector3.one, t);
			yield return new WaitForSeconds (0.05f);
		}
	}
}
