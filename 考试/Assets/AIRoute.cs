using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine;
using System.Collections;

public class AIRoute : MonoBehaviour {
	private UnityEngine.AI.NavMeshAgent agent;
	// Use this for initialization
	void Start () {
		agent = GetComponent<UnityEngine.AI.NavMeshAgent> ();
	}
	
	// Update is called once per frame
	void Update () {
		RaycastHit hit;
		if (Input.GetMouseButtonDown (0)) {
            Debug.Log("here");
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			if(Physics.Raycast(ray,out hit))
				agent.SetDestination(hit.point);
		}
	}
}