using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestartHelper:MonoBehaviour {

	public static RestartHelper restartHelper;
	[SerializeField] GameObject rootPrefab;

	void Start() {
		if(restartHelper) Destroy(gameObject);
		DontDestroyOnLoad(gameObject);
		restartHelper=this;
	}

	public void Restart(GameObject originalRoot){
		Destroy(originalRoot);
		Instantiate(rootPrefab,originalRoot.transform.position,originalRoot.transform.rotation);
	}
}
