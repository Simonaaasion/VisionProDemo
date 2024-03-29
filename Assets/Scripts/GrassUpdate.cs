using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrassUpdate : MonoBehaviour
{
    public GameObject GrassBtn;
    public GameObject Soli;
    public GameObject Scoreboard;
    public void OpenGrassMode()
    {
        if(Soli.TryGetComponent(out GroundUpdate uiElement))
        {
            GrassBtn.SetActive(false);
            Scoreboard.SetActive(true);
            uiElement.isGrassMode = true;
        }
    }
}
