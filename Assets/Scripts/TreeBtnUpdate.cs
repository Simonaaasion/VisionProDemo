using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeBtnUpdate : MonoBehaviour
{
    public GameObject Tree1;
    public GameObject Tree2;
    public GameObject Tree3;
    public GameObject TreeBtn;
    public GameObject GrassBtn;
    private bool tree1IsMax = false;
    private bool tree2IsMax = false;
    private bool tree3IsMax = false;
    public void CreatTrees()
    {
        Tree1.SetActive(true);
        Tree2.SetActive(true);
        Tree3.SetActive(true);
        TreeBtn.SetActive(false);
    }
    public float step = 0.001f; 
    public float GrowUpMaxValue = 0.01f;
    public void TreesGrowUp(string type)
    {
        Vector3 GrowUpValue = new(step, step, 0);
        switch (type)
        {
            case "1":
                if (tree1IsMax) return;
                Tree1.transform.localScale += GrowUpValue;
                if (Tree1.transform.localScale.x >= GrowUpMaxValue)
                {
                 if(Tree1.TryGetComponent(out SphereCollider meshCollider))
                    {
                        meshCollider.enabled = false;
                    }
                    tree1IsMax = true;
                }
                break;
            case "2":
                if (tree2IsMax) return;
                Tree2.transform.localScale += GrowUpValue;
                if (Tree2.transform.localScale.x >= GrowUpMaxValue)
                {
                    if (Tree2.TryGetComponent(out SphereCollider meshCollider))
                    {
                        meshCollider.enabled = false;
                    }
                    tree2IsMax = true;
                }
                break;
            case "3":
                if (tree3IsMax) return;
                Tree3.transform.localScale += GrowUpValue;
                if (Tree3.transform.localScale.x >= GrowUpMaxValue)
                {
                    if (Tree3.TryGetComponent(out SphereCollider meshCollider))
                    {
                        meshCollider.enabled = false;
                    }
                    tree3IsMax = true;
                }
                break;
            default:
                break;
        }
        ToGrassStep();
    }
    void ToGrassStep()
    {
        if(tree1IsMax&& tree2IsMax&& tree3IsMax)
        {
            GrassBtn.SetActive(true);
        }
    }
}
