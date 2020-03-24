using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    protected string[] players = new string[2]; //holds the players 
    public int currentTurn; // tracks player order and number of turns 
                            // Start is called before the first frame update



}
/*  
 for (int x = 0; x < 5; x++)
 {
     boardSpace[0] = x;
     for(int y = 0; y < 5; y++)
     {
         boardSpace[1] = y;
         //Debug.Log("x = " + x + ", y = "+y);
         if ((x == 0 && y == 0) || (x == 4 && y == 0) || (x == 0 && y == 4) || (x == 4 && y == 4))
         {
             boardSpace[2] = 1;
         }
         else
         {
             boardSpace[2] = 0;
         }
         //  Debug.Log("current val x " + boardSpace[0]);
         //  Debug.Log("current val y " + boardSpace[1]);
         board.Add(boardSpace);
         int size = board.Count;
         Debug.Log("board size  " + size);
         int xVal = board[x][0];
         int yVal = board[x][1];
         int p = board[x][2];
         Debug.Log("X = " + xVal + " Y = " + yVal + " has piece " + p);
         Debug.Log("************************"); 
    }
  } */




