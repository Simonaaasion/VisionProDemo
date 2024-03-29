using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseUpdate : MonoBehaviour
{
    public GameObject houseBtn;
    public GameObject house;
    public void OpenHouseMode()
    {
        houseBtn.SetActive(false);
        house.SetActive(true);
    }
}
