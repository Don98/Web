using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicAction : SSAction
{
    public Vector3 speed;

    public static PhysicAction GetSSAction()
    {
        PhysicAction action = CreateInstance<PhysicAction>();
        return action;
    }

    public override void Start(){
    }
    public override void Update(){
        if (transform.position.y < -10 || transform.position.x <= -20 || transform.position.x >= 20){
            gameObject.GetComponent<Rigidbody>().isKinematic = true;
            gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
            transform.position = Vector3.down;
            callback.SSActionEvent(this);
        }
    }
}