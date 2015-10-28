using UnityEngine;
using System.Collections;

public class InteractorTool : MonoBehaviour {
	//keep public
	public float interactionDistance = 0.5f;
	public float triggerTime = 3f;

	//set private
	public float triggerTimer = 0;
	public InteractionAgent currentAgent;
	public InteractionAgent lastSelected;
	public GameObject player;
	public Camera playerCamera;
	public WaypointManager waypointManager;

	//public WaypointBehaviour currentWaypoint;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("MainCamera").gameObject;
		playerCamera = player.GetComponent<Camera>();
		waypointManager = GameObject.FindGameObjectWithTag ("WaypointHelpers").GetComponent<WaypointManager>();
	}
	
	// Update is called once per frame
	void Update () {

		//CheckForActivation();




		RaycastHit hit;
		Debug.DrawRay (playerCamera.transform.position, playerCamera.transform.forward*interactionDistance, Color.cyan);

		Physics.Raycast (playerCamera.transform.position, playerCamera.transform.forward, out hit, interactionDistance);

		if (hit.transform != null && hit.transform.tag == "InteractiveByRay"){
			//Debug.Log (hit.transform.name);
			currentAgent = hit.transform.GetComponent<InteractionAgent>();
		} else{
			currentAgent = null;
		}


		//check if current agent is still selected and make changes if so.
		if (currentAgent != lastSelected){
			if (currentAgent == null){
				lastSelected.Unselect();
				lastSelected = null;

			} 
			else {
				if (lastSelected != null)
					lastSelected.Unselect();				

				lastSelected = currentAgent;
				lastSelected.Select();
			}

			triggerTimer = 0;
		}


		if (currentAgent == lastSelected && currentAgent != null){
			triggerTimer += Time.deltaTime;
			if (triggerTimer >= triggerTime){
				//triggerTime = 0;
				currentAgent.TriggerMainAction();
				waypointManager.currentWaypoint = currentAgent.gameObject.GetComponentInParent<WaypointBehaviour>();
				waypointManager.currentWaypoint.wpReactors.SetActive (false);
				currentAgent = null;
				lastSelected = null;
			}
			
		}

	}

	



	//to reset counters and selection marks
	void ResetControlVars (){
		//lastSelected.Unselect();
		triggerTimer =0;
	}



}
