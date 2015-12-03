using UnityEngine;
using System.Collections;

public class WaypointManager : MonoBehaviour {
	public WaypointBehaviour currentWaypoint;

	void Update (){
		if (Input.GetKeyDown (KeyCode.X)){
			ActivateAllButCurrent ();
		}
	}

	public void ActivateAllButCurrent(){
		GameObject[] gos;
		gos = GameObject.FindGameObjectsWithTag("Waypoint");
		foreach (GameObject go in gos) {
			if (go.GetComponent<WaypointBehaviour>()!= currentWaypoint)
				go.GetComponent<WaypointBehaviour>().wpReactors.SetActive(!go.GetComponent<WaypointBehaviour>().wpReactors.activeSelf);
			//	wpReactors.SetActive (!wpReactors.activeSelf);
		}
	}
}
