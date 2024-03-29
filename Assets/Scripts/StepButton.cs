using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StepButton : MonoBehaviour
{
    public GameObject pinch;
    public GameObject treeBtn;
    public void UpdateStep()
    {
        pinch.SetActive(false);
        treeBtn.SetActive(true);
    }
}
