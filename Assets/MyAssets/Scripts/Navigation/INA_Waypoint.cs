using UnityEngine;
using System.Collections;

public class INA_Waypoint : InteractionAgent {

	override public void TriggerMainAction(){
		Debug.Log ("Trigger " + gameObject.name + " WAYPOINT ACTION");

		RaycastHit hit;
		//Debug.DrawRay (playerCamera.transform.position, playerCamera.transform.forward*interactionDistance, Color.cyan);
		
		Physics.Raycast (transform.position, -transform.up, out hit, 500);
		
		if (hit.transform != null && hit.transform.tag == "GroundSurface"){
			//Debug.Log (hit.transform.name);

			Vector3 newPosition  = new Vector3 (hit.point.x, hit.point.y + 1.5f, hit.point.z);
			GameObject player = GameObject.FindGameObjectWithTag ("MainCamera");
			player.transform.position = newPosition;

		} 


	}
}
