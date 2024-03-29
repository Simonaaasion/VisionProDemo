using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudUpdate : MonoBehaviour
{
    public GameObject CloudBtn;
    public GameObject PinkCloud;
    public void OpenCloudMode()
    {
        CloudBtn.SetActive(false);
        PinkCloud.SetActive(true);
    }
}
