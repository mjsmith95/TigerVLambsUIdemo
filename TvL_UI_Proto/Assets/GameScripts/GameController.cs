using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class GameController : MonoBehaviour
{
    public int currentTurn = 0;
    public int actionCount = 0;
    public bool isSheepTurn = false;
    public Button firstPressed;
    public List<Button> buttons;
    public Dictionary<string, int[]> grid = new Dictionary<string, int[]>();
    public void BoardSetup(List<Button> buttonElments)
    {
        int count = 0;
        for (int y = 0; y < 5; y++)
        {
            for (int x = 0; x < 5; x++)
            {
                //Debug.Log("Button name is " + buttonElments[count].name);
                // check if the button is a corner space 
                if (buttonElments[count].name == "GridSpace" || buttonElments[count].name == "GridSpace4" || buttonElments[count].name == "GridSpace20" || buttonElments[count].name == "GridSpace24")
                {
                    //update the value in the dict 
                    buttonElments[count].GetComponentInChildren<Text>().text = "T";
                }
                int[] cord = { x, y };
                grid.Add(buttonElments[count].name, cord);
                count += 1;
                //Debug.Log("x: " + x + " y: " + y);
            }
        }
    }

    public void GetLastPressedButton()
    {
        Button currentPressed = EventSystem.current.currentSelectedGameObject.GetComponent<Button>();
        //int[] cord = grid[EventSystem.current.currentSelectedGameObject.name];
        //Debug.Log("the current cord is " + cord); 
        Debug.Log("The current turn is " + currentTurn);
        //order of operations 
        /*
         * all of this is wrapped in a turn check and sheep check 
         check actionCount (number of allowed actions per turn) 
         if ac == 0 first button press 
         -if button pressed containts text val 
         --update pieceToBeMoved with text val 
         --update actionCount 
         -- call available moves 
         -- highlight availbe moves 
         if ac == 1 
         --set the text componet of lastPressedbutton to peice to be removed 
         --set the set componet of the of the first pressed button to empty 
         */
        // if turn count is less than and a sheeps turn, just update the last pressed buttons text component to sheep
        if (currentTurn < 39 && isSheepTurn)
        {
            Debug.Log("Placement for Lamb");
            if (CheckIfEmpty(currentPressed))
            {
                currentPressed.GetComponentInChildren<Text>().text = "L";
                currentTurn += 1;
                UpdatePlayerTurn();
            }
        }
        // if the turn count is greater than 20*2, then sheeps just move 
        else if (isSheepTurn)
        {
            MovePiece(currentPressed);

        }
        //otherwise its a tiger turn
        else
        {
            MovePiece(currentPressed);
        }
        //currentTurn += 1; 
    }


    public void MovePiece(Button currentPressed)
    {
        if (actionCount == 0)
        {
            if (!CheckIfEmpty(currentPressed))
            {
                firstPressed = currentPressed;
                Debug.Log(firstPressed.name);
                actionCount += 1;
                //TODO: call and use valid moves function/ actually create it.... 
            }
        }
        else if (actionCount == 1)
        {
            if (CheckIfEmpty(currentPressed)) // and is valid move ... still need to write that YIKES
            {
                // move the piece to the current selection
                currentPressed.GetComponentInChildren<Text>().text = firstPressed.GetComponentInChildren<Text>().text;
                // remove that same piece from the previous seelction
                firstPressed.GetComponentInChildren<Text>().text = "";
                actionCount = 0;
                currentTurn += 1;
                UpdatePlayerTurn();
            }

        }
    }

    //checks if the last pressed button has a text compnent aka is there a piece in the space
    public bool CheckIfEmpty(Button buttonToCheck)
    {
        bool isEmpty = true;
        if (buttonToCheck.GetComponentInChildren<Text>().text != "")
        {
            isEmpty = false;
        }
        return isEmpty;
    }

    //checks the current to determine which piece is in play 
    public void UpdatePlayerTurn()
    {
        //if the turn is even then it's a tiger turn
        if(currentTurn % 2 == 0)
        {
            isSheepTurn = false;
            Debug.Log("Tiger Turn");
        }
        // otherwise its the sheep's turn 
        else
        {
            isSheepTurn = true;
            Debug.Log("Lamb Turn");
        }
    }

    public List<int[]> GetValidMoves()
    {
        List<int[]> validMoves = new List<int[]>();
        return validMoves; 
    }
    // set up a new board to play, may need to shift this to Start() once menu UI is put is in place 
    void Awake()
    {
        Debug.Log("list is size is " + buttons.Count);
        BoardSetup(buttons);
        Debug.Log("dict test " + grid.Count);
    }
}
