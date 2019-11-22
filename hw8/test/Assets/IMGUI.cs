using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Health))]
public class IMGUI : MonoBehaviour
{
    private GameObject Character;
	private GameObject people;
    private float curHP;
    private float fullHP;
    private void Start() {
        Character = this.gameObject;
		Character.AddComponent<Health>();
    }

    private void OnGUI() {
        if(GUI.Button(new Rect(UnityEngine.Screen.width/2 - 50,UnityEngine.Screen.height/2 - 40,80,40),"Hurt"))
        {
            Character.GetComponent<Health>().Hurt();
        }
        if(GUI.Button(new Rect(UnityEngine.Screen.width/2 + 50,UnityEngine.Screen.height/2 - 40,80,40),"Recover"))
        {
            Character.GetComponent<Health>().Recover();
        }

        curHP = Character.GetComponent<Health>().curHP;
        fullHP = Character.GetComponent<Health>().fullHP;

        GUI.HorizontalScrollbar(new Rect(UnityEngine.Screen.width/2 - 42,UnityEngine.Screen.height/2 +20,170,20), 0.0f, curHP, 0.0f, fullHP);
    }
}

