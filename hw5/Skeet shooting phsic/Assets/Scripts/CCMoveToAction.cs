﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CCMoveToAction : SSAction
{
    public Vector3 target;
    public float speed;

    public static CCMoveToAction GetSSAction(Vector3 target, float speed)
    {
        CCMoveToAction action = CreateInstance<CCMoveToAction>();
        action.target = target;
        action.speed = speed;
        return action;
    }

    public override void Start()
    {
        
    }
    public override void Update()
    {
        if(enable)
        {
            this.transform.position = Vector3.MoveTowards(this.transform.position, target, Time.deltaTime * speed);
            if (this.transform.position == target)
            {
                this.enable = false;
                this.callback.SSActionEvent(this);
            }
        }
    }
}