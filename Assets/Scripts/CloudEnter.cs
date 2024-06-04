using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudEnter:MonoBehaviour {

	[SerializeField] GameObject targetObject;
	Vector3 originalScale;
	private void Start() {
		originalScale=transform.localScale;
		transform.localScale=Vector3.zero;
	}
	float timeMoved;
	bool inited;

	private void Update() {

		if(!inited&&transform.parent.lossyScale!=Vector3.zero) {
			transform.position-=Vector3.right*20;
			transform.localScale=originalScale;
			inited=true;
		}

		if(!targetObject.activeInHierarchy) return;
		if(timeMoved>=1f) return;
		transform.position+=Vector3.right*20*Time.deltaTime;
		timeMoved+=Time.deltaTime;
		if(timeMoved>1){
			float overMoved = timeMoved-1;
			transform.position-=Vector3.right*overMoved;
		}
	}

}
