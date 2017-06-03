using UnityEngine;
using System.Collections;

public class INA_Waypoint : InteractionAgent {
		//keep public
		public GameObject particlesAnchor;
		

		//set private
		ParticleSystem particles;
		public GameObject particlesHolder;
		public bool isCurrent = false;
		public GameObject redMarker;	 	
		public GameObject redAnchor; 
	void Start (){
		particles = GameObject.FindGameObjectWithTag("WaypointHelpers").transform.FindChild("ParticleMarker01").GetComponent<ParticleSystem>();
		particlesHolder = GameObject.FindGameObjectWithTag("WaypointHelpers").transform.FindChild("ParticleMarker01").gameObject;

		redMarker = GameObject.FindGameObjectWithTag("SphereMarker");
		Debug.Log (particlesAnchor);


	}


	override public void TriggerMainAction(){
		//Debug.Log ("Trigger " + gameObject.name + " WAYPOINT ACTION");

		RaycastHit hit;
		//Debug.DrawRay (playerCamera.transform.position, playerCamera.transform.forward*interactionDistance, Color.cyan);
		
		Physics.Raycast (transform.position, -transform.up, out hit, 500);
		
		if (hit.transform != null && hit.transform.tag == "GroundSurface"){
			//Debug.Log (hit.transform.name);

			Vector3 newPosition  = new Vector3 (hit.point.x, hit.point.y + 1.5f, hit.point.z);
			//GameObject player = GameObject.FindGameObjectWithTag ("MainCamera");
			GameObject player = GameObject.FindGameObjectWithTag ("MainCamera").transform.root.gameObject; //modified for G-Cardboard
			player.transform.position = newPosition;  //esto debe sustituirse por un player.WaypointManager.CambiarPosicion que incluya los fades

		} 

		Unselect();


	}


	override public void Select (){
		redMarker.transform.position = redAnchor.transform.position;
		redMarker.SetActive (true);
		particlesHolder.transform.position = particlesAnchor.transform.position;
		particles.Play ();
	}
	
	override public void Unselect (){
		redMarker.SetActive (false);
		//Debug.Log ("UNSELECTE");
		particles.Stop();
	}
}
