using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piece:MonoBehaviour 
{
    public string pieceID;
    public string pieceType; 
    public bool inPlay;
    public int[] currnetPos;

    void SetBoardPos(int[] newCord)
    {
        currnetPos = newCord; 
    }
    void ChangeStatus()
    {
        inPlay = !inPlay; 
    } 
}
