using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class GameController : MonoBehaviour
{
    public int turnCount = 0;
    public int selectorVal = 0;
    public bool isSheepTurn = false;
    public List<Button> buttons;
    public Dictionary<Button, int[]> grid = new Dictionary<Button, int[]>();
    public void BoardSetup(List<Button> buttonElments)
    {
        int count = 0;
        for (int y = 0; y < 5; y++)
        {
            for (int x = 0; x < 5; x++)
            {
                Debug.Log("Button name is " + buttonElments[count].name);
                // check if the button is a corner space 
                if (buttonElments[count].name == "GridSpace" || buttonElments[count].name == "GridSpace4" || buttonElments[count].name == "GridSpace20" || buttonElments[count].name == "GridSpace24")
                {
                    //update the value in the dict 
                    buttonElments[count].GetComponentInChildren<Text>().text = "T";
                }
                int[] cord = { x, y };
                grid.Add(buttonElments[count], cord);
                count += 1;
                Debug.Log("x: " + x + " y: " + y);
            }
        }
    }

    public void GetLastPressedButton()
    {
        
        Debug.Log(EventSystem.current.currentSelectedGameObject.name);
        Debug.Log(grid[]);
    }

    public void UpdateGame()
    {
        if (isSheepTurn)
        {
            if (turnCount <= 20)
            {
                //place a sheep onto the board
            }
            else
            {
                //move an exsiting sheep on the baord 
            }
        }
        //otherwsie a tiger is in play and should be moved
        else
        {

        }

    }
    //checks the current to determine which piece is in play 
    public void playerTurn(int currentTurn)
    {
        //if the turn is even then it's a tiger turn
        if(currentTurn % 2 == 0 || currentTurn == 0)
        {
            isSheepTurn =false;
        }
        // otherwise its the sheep's turn 
        else
        {
            isSheepTurn = true;
        }
    }

    public List<int[]> getValidMoves()
    {
        List<int[]> validMoves = new List<int[]>();
        return validMoves; 
    }

    void Awake()
    {
        Debug.Log("list is size is " + buttons.Count);
        BoardSetup(buttons);
        Debug.Log("dict test " + grid.Count);
    }
}
