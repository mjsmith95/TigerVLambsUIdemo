using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public string[] players = new string[2]; //holds the players 
    public List<int[]> board = new List<int[]>();
    public  int[] boardSpace = new int[3];

    public int currentTurn; // tracks player order and number of turns 
    // Start is called before the first frame update
    void Start()
    {
        currentTurn = 0;
        for (int x = 0; x < 5; x++)
        {
            boardSpace[0] = x;
            for(int y = 0; y < 5; y++)
            {
                boardSpace[1] = y;
                Debug.Log("x = " + x + ", y = " +y);
                if ((x == 0 && y == 0) || (x == 4 && y == 0) || (x == 0 && y == 4) || (x == 4 && y == 4))
                {
                    boardSpace[2] = 1;
                }
                else
                {
                    boardSpace[2] = 0;
                }
                board.Add(boardSpace);
            }
        }
        foreach(int[] space in board)
        {
            Debug.Log("X = " + space[0]);
            Debug.Log("Y = " + space[1]);
            Debug.Log("******************");
        }
    }
 
}
