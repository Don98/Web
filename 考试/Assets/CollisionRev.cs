using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionRev : MonoBehaviour
{
    private bool ifMove;
    void OnCollisionEnter(Collision collision){
        ifMove = true;
    }
    
    // Start is called before the first frame update
    void Start()
    {
        ifMove = false;
    }

    // Update is called once per frame
    void Update()
    {   Debug.Log("coll");
        if(ifMove){
            transform.position = transform.position + new Vector3(-2.0f * Time.deltaTime, 0, 0);
        }
    }
}