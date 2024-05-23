using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleCredit:MonoBehaviour {

	[SerializeField] GameObject toToggleActive;

	public void Work() {
        toToggleActive.SetActive(!toToggleActive.activeSelf);
	}

}
