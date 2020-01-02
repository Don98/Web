using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallController
{
	readonly GameObject wall;
	readonly Vector3 wall_pos = new Vector3(0,1,-49);
	public WallController(){
		wall = Object.Instantiate(Resources.Load("Prefabs/wall",typeof(GameObject)),wall_pos,Quaternion.identity,null) as GameObject;
		wall.name = "wall";
		// wall.AddComponent(typeof());
	}
	public void change_position(Vector3 new_pos){
		wall.transform.position = new_pos;
	}
	public void change_size(Vector3 new_size){
		wall.transform.localScale = new_size;
	}
	public void change_roate(Vector3 new_roate){
		wall.transform.rotation = Quaternion.Euler(new_roate);
	}
}
