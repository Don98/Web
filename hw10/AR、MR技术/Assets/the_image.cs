using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

[System.Obsolete]
public class VirtualButtonEventHandler : MonoBehaviour, IVirtualButtonEventHandler
{
    public GameObject vb;
    public Animator ani;
    void IVirtualButtonEventHandler.OnButtonPressed(VirtualButtonBehaviour vb)
    {
        ani.SetBool("IsRun", true);
        Debug.Log("run");
    }

    void IVirtualButtonEventHandler.OnButtonReleased(VirtualButtonBehaviour vb)
    {
        ani.SetBool("IsRun", false);
        Debug.Log("stop");
    }

    // Start is called before the first frame update
    void Start()
    {
        VirtualButtonBehaviour vbb = vb.GetComponent<VirtualButtonBehaviour>();
        if(vbb)
        {
            vbb.RegisterEventHandler(this);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
