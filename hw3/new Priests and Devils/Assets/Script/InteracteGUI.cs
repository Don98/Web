using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Interfaces;

public class InteracteGUI : MonoBehaviour {
    UserAction UserAcotionController;
    public int SetState { get { return GameState; } set { GameState = value; } }
    static int GameState = 0;

	// Use this for initialization
	void Start () {
        UserAcotionController = SSDirector.getInstance().currentScenceController as UserAction;
    }

    private void OnGUI()
    {    
		GUIStyle style = new GUIStyle ();
        style.fontSize = 28;
        if (GameState == 1)
        {
            GUI.Label(new Rect(Screen.width / 2 - 25, Screen.height / 2 - 50, 100, 50), "Gameover!",style);
            if (GUI.Button(new Rect(Screen.width / 2 - 50, Screen.height / 2 - 20, 180, 70), "Restart"))
            {
                GameState = 0;
                UserAcotionController.Restart();
            }
        }
        else if (GameState == 2)
        {
            GUI.Label(new Rect(Screen.width / 2 - 30, Screen.height / 2 - 30 , 100, 50), "Win!",style);
            if (GUI.Button(new Rect(Screen.width / 2 - 70, Screen.height / 2, 140, 70), "Restart"))
            {
                GameState = 0;
                UserAcotionController.Restart();
            }
        }
    }
}

public class ClickGUI : MonoBehaviour{
    UserAction UserAcotionController;
    GameObjects GameObjectsInScene;

    public void setController(GameObjects characterCtrl)
    {
        GameObjectsInScene = characterCtrl;
    }

    void Start()
    {
        UserAcotionController = SSDirector.getInstance().currentScenceController as UserAction;
    }

    void OnMouseDown()
    {
        if (gameObject.name == "boat")
        {
            Debug.Log("Click_boat!");
            UserAcotionController.MoveBoat();
        }
        else
        {
            Debug.Log("Click_item!");
            UserAcotionController.ObjectIsClicked(GameObjectsInScene);
        }
    }
}