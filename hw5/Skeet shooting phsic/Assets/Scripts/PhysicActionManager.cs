using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsActionManager : SSActionManager, ISSActionCallback,IActionManager {
    public FirstSceneController sceneController;
    public List<PhysicAction> seq = new List<PhysicAction>();
    public UserClickAction userClickAction;
    public SkeetFactory skeets;
    
    public void Start()
    {
        sceneController = (FirstSceneController)SSDirector.getInstance().currentSceneController;
        sceneController.actionManager = this;
        skeets = Singleton<SkeetFactory>.Instance;
    }
    public void PlaySkeet()
    {
        if(skeets.used.Count > 0)
        {
            GameObject skeet = skeets.used[0];
            float x = Random.Range(-5, 5);
			skeet.transform.GetComponent<Rigidbody>().isKinematic = false;
			skeet.GetComponent<Rigidbody>().velocity = new Vector3(x, 8 * (Mathf.CeilToInt(FirstSceneController.times / 10) + 1) + 2, 6);
            skeet.GetComponent<Rigidbody>().AddForce(new Vector3(0,8.8f, 0),ForceMode.Force);
            PhysicAction physicAction = PhysicAction.GetSSAction();
            seq.Add(physicAction);
            this.RunAction(skeet, physicAction, this);
            skeets.used.RemoveAt(0);
        }
        if (Input.GetMouseButtonDown(0) && sceneController.flag == 0)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitGameObject;
            if (Physics.Raycast(ray, out hitGameObject))
            {
                GameObject gameObject = hitGameObject.collider.gameObject;
                if (gameObject.tag == "skeet")
                {
					gameObject.transform.position = new Vector3(100,100,100);
					userClickAction = UserClickAction.GetSSAction();
                    this.RunAction(gameObject, userClickAction, this);
                }
            }
        }
        base.Update();
    }
    public void SSActionEvent(SSAction source, SSActionEventType events = SSActionEventType.Completed, int intParam = 0, string strParam = null, Object objParam = null)
    {
        skeets.RecycleSkeet(source.gameObject);
        seq.Remove(source as PhysicAction);
        source.destory = true;
        if (FirstSceneController.times >= 30)
            sceneController.flag = 1;
    }
    public void CheckEvent(SSAction source, SSActionEventType events = SSActionEventType.Completed, int intParam = 0, string strParam = null, Object objParam = null)
    {
    }    
	public void Pause(){
        if (sceneController.flag == 0){
            foreach (var k in seq)
            {
                k.speed = k.transform.GetComponent<Rigidbody>().velocity;
                k.transform.GetComponent<Rigidbody>().isKinematic = true;
            }
            sceneController.flag = 2;
        }
        else if (sceneController.flag == 2){
            foreach (var k in seq)
            {
                k.transform.GetComponent<Rigidbody>().isKinematic = false;
                k.transform.GetComponent<Rigidbody>().velocity = k.speed;
            }
            sceneController.flag = 0;
        }
    }
}
