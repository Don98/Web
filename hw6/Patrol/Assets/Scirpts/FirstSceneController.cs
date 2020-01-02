using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstSceneController : MonoBehaviour,ISceneController
{
	public WallController wall;
	public GroundController ground;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	void Awake(){
		LoadResources();
	}
	
    public void LoadResources(){
		load_wall_ground();
    }
	public void load_wall_ground(){
		wall = new WallController();
		wall.change_position(new Vector3(0,1,50));
		wall.change_size(new Vector3(100,1,1));
		wall = new WallController();
		wall.change_position(new Vector3(0,1,-50));
		wall.change_size(new Vector3(100,1,1));
		wall = new WallController();
		wall.change_position(new Vector3(-50,1,0));
		wall.change_roate(new Vector3(90,90,0));
		wall.change_size(new Vector3(100,1,1));
		wall = new WallController();
		wall.change_position(new Vector3(50,1,0));
		wall.change_roate(new Vector3(90,90,0));
		wall.change_size(new Vector3(100,1,1));
		ground = new GroundController();
	}
}
