using UnityEngine;
using System.Collections;

public class InteractionAgent : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	public void Select (){

	}

	public void Unselect (){

	}

	virtual public void TriggerMainAction(){
		Debug.Log ("Trigger " + gameObject.name + " main action");
	}
}
