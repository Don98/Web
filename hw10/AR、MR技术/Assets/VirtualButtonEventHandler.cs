using UnityEngine;
using Vuforia;
[System.Obsolete]
public class VirtualButtonEventHandler : MonoBehaviour, IVirtualButtonEventHandler
{


    public VirtualButtonBehaviour vb;
    public Animator animator;
    void IVirtualButtonEventHandler.OnButtonPressed(VirtualButtonBehaviour vb)
    {
        animator.SetBool("start", false);
        animator.SetBool("jump", true);
        Debug.Log("jump");
    }

    void IVirtualButtonEventHandler.OnButtonReleased(VirtualButtonBehaviour vb)
    {

        animator.SetBool("jump", false);
        animator.SetBool("start", true);
        Debug.Log("stop");
    }

  
    void Start()
    {
        VirtualButtonBehaviour vbb = vb.GetComponent<VirtualButtonBehaviour>();
        if (vbb)
        {
            vbb.RegisterEventHandler(this);
        }
    }


    void Update()
    {

    }

}
