using UnityEngine;
using System.Collections;

public class DestroyObject : MonoBehaviour {

	// Update is called once per frame
	void Update () {
		if(this.transform.position.y > 50 || this.transform.position.y < -20){
			Destroy(gameObject);
		}
	}
}
