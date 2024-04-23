using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrassUpdate:MonoBehaviour {
	public GameObject GrassBtn;
	public GameObject Soli;
	public GameObject Hotbar;
	public GameObject nextBtn;
	public void OpenGrassMode() {
		if(Soli.TryGetComponent(out GroundUpdate uiElement)) {
			GrassBtn.SetActive(false);
			uiElement.Enter(20,Hotbar,nextBtn);
		}
	}
}
