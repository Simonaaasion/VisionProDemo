using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindmillRotation:MonoBehaviour {
	[SerializeField] GameObject restartButton;
	[SerializeField] float rotation = 60;
	[SerializeField] float rotationZ = 0;
	[SerializeField] float translation = 0;
	[SerializeField] bool startInvisible;
	[SerializeField] Vector3 scale;
	void Update() {
		if(startInvisible) transform.localScale=scale;
		if(!restartButton.activeInHierarchy) return;
		transform.Rotate(0,Time.deltaTime*rotation,Time.deltaTime*rotationZ);
		transform.position+=Vector3.right*translation;
	}
}
