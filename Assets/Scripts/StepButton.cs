using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StepButton:MonoBehaviour {
	public GameObject pinch;
	public GameObject treeBtn;
	[SerializeField] GameObject popUpObject;
	public void UpdateStep() {
		popUpObject.transform.localScale=Vector3.one;
		pinch.SetActive(false);
		treeBtn.SetActive(true);
	}

}
