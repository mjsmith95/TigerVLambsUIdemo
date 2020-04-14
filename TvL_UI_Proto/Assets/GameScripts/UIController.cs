using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIController : MonoBehaviour
{
    public GameObject[,] board = new GameObject[4,4];
    public GameObject[] outOfPlay = new GameObject[20];

    public void BoardSetup()
    {
        GameObject tigerOne = (GameObject)Instantiate(Resources.Load("TigerPiece")); 
        tigerOne.

    }

    void Start()
    {

    }
}
