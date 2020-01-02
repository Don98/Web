using UnityEngine;
using System.Collections;

public class DestroyEffect : MonoBehaviour {

	public float t = 0f;

	void Update ()
	{
		t += Time.deltaTime;
		if (t > 1.5f) {
			Destroy(transform.gameObject);
		}
	
	}
}
