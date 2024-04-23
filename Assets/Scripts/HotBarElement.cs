using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HotBarElement:MonoBehaviour {

	[SerializeField] GameObject targetPrefab;
	Vector3 initScale;
	public void OnClick() {
		GroundUpdate.instance.prefab=targetPrefab;
	}
	private void Start() {
		initScale=transform.localScale;
	}
	private void Update() {
		transform.localScale=GroundUpdate.instance.prefab==targetPrefab ? initScale*1.4f : initScale;
	}

}
