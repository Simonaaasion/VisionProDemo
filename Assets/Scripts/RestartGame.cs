using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestartGame:MonoBehaviour {

	public static GameObject instance;

	private void Start() {
		instance=gameObject;
	}

	[ContextMenuItem("����","restartGame")]
	[SerializeField] GameObject rootPrefab;
	public void restartGame() {
		GameObject root = null;
		for(Transform t = transform;t!=null;t=t.parent) {
			if(t.parent==null) root=t.gameObject;
		}
		RestartHelper.restartHelper.Restart(root);

	}
}
