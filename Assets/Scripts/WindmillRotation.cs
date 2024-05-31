using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindmillRotation:MonoBehaviour {
	[SerializeField] GameObject restartButton;
	[SerializeField] float rotation = 60;
	[SerializeField] float translation = 0;
	void Update() {
		if(!restartButton.activeInHierarchy) return;
		transform.Rotate(0,Time.deltaTime*rotation,0);
		transform.position+=Vector3.right*translation;
	}
}
