using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeetFactory : MonoBehaviour {
    public List<GameObject> used = new List<GameObject>();
    public List<GameObject> free = new List<GameObject>();

	void Start () { }

    public void GenSkeet()
    {
        GameObject skeet;
        if(free.Count == 0)
        {
            skeet = Instantiate<GameObject>(Resources.Load<GameObject>("Prefabs/Skeet"), Vector3.zero, Quaternion.identity);
        }
        else
        {
            skeet = free[0];
            free.RemoveAt(0);
        }
        float x = Random.Range(-10.0f, 10.0f);
        skeet.transform.position = new Vector3(x, 0, 0);
        skeet.transform.Rotate(new Vector3(x < 0? -x*9 : x*9, 0, 0));
        float r = Random.Range(0f, 1f);
        float g = Random.Range(0f, 1f);
        float b = Random.Range(0f, 1f);
        Color color = new Color(r, g, b);
        skeet.transform.GetComponent<Renderer>().material.color = color;
        used.Add(skeet);
    }
    public void RecycleSkeet(GameObject obj)
    {
        obj.transform.position = Vector3.zero;
        free.Add(obj);
    }
}