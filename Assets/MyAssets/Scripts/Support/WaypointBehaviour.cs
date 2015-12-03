using UnityEngine;
using System.Collections;

public class WaypointBehaviour : MonoBehaviour {


	//SET PRIVATE
	GameObject targetCameraGO;
	public GameObject wpReactors;


	void Start (){
		targetCameraGO = GameObject.FindGameObjectWithTag ("MainCamera");
		//wpReactors.SetActive(false);  //uncomment for start app with all waypoints disabled
	}
	
	// Update is called once per frame
	void Update () {


		Vector3 targetPosition = targetCameraGO.transform.position;
		targetPosition.y = transform.position.y;
		transform.LookAt(targetPosition);
	}
}
