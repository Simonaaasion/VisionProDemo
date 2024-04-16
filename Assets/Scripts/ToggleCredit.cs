using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleCredit:MonoBehaviour {

	[SerializeField] GameObject toToggle;

	public void Work() {
		toToggle.SetActive(!toToggle.activeSelf);
	}

}
