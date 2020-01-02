using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterContronller
{
	readonly GameObject character;
	readonly Vector3 character_pos = new Vector3(0,1,-49);
	public CharacterContronller(){
		character = Object.Instantiate(Resources.Load("Prefabs/character",typeof(GameObject)),character_pos,Quaternion.identity,null) as GameObject;
		character.name = "character";
	}
	public void change_position(Vector3 new_pos){
		character.transform.position = new_pos;
	}
	public void change_size(Vector3 new_size){
		character.transform.localScale = new_size;
	}
	public void change_roate(Vector3 new_roate){
		character.transform.rotation = Quaternion.Euler(new_roate);
	}
}
