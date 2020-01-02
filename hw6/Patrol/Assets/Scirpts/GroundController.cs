using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundController
{
	readonly GameObject ground;
	readonly Vector3 ground_pos = new Vector3(0,0,0);
	public GroundController(){
        ground = Object.Instantiate(Resources.Load("Prefabs/ground", typeof(GameObject)), ground_pos, Quaternion.identity, null) as GameObject;
        ground.name = "ground";
	}
	public void change_position(Vector3 new_pos){
		ground.transform.position = new_pos;
	}
	public void change_size(Vector3 new_size){
		ground.transform.localScale = new_size;
	}
	public void change_roate(Vector3 new_roate){
		ground.transform.rotation = Quaternion.Euler(new_roate);
	}
}
