using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestartGame:MonoBehaviour {

	[ContextMenuItem("÷ÿ∆Ù","restartGame")]
	[SerializeField] GameObject rootPrefab;
	public void restartGame() {
		GameObject root = null;
		for(Transform t = transform;t!=null;t=t.parent) {
			if(t.parent==null) root=t.gameObject;
		}
		RestartHelper.restartHelper.Restart(root);

	}
}
