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
    public List<int[]> cordKeys = new List<int[]>();
    public Dictionary<int[], Button> grid = new Dictionary<int[],Button>();
    public Dictionary<Button, int[]> buttonMapping = new Dictionary<Button, int[]>();

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
                cordKeys.Add(cord);
                grid.Add(cord, buttonElments[count]);
                buttonMapping.Add(buttonElments[count],cord);
                count += 1;
                //Debug.Log("x: " + x + " y: " + y);
            }
        }
    }

    public void GetLastPressedButton()
    {
        Button currentPressed = EventSystem.current.currentSelectedGameObject.GetComponent<Button>();
        //int[] cord = grid[EventSystem.current.currentSelectedGameObject.name];
        Debug.Log("The current turn is " + currentTurn);
        if (currentTurn < 40 && isSheepTurn)
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
    }

    public void MovePiece(Button currentPressed)
    {
        /* new move alg 
         * first pressed 
         * -check piece type 
         * -generate valid move list for correct piece type 
         * -hilight valid moves 
         * on ac count 2 
         * check if current is valid move, if yes then move 
         * if distance between current and valid is > 1 then capture 
         */
        List<Button> potentialMoves = new List<Button>();
        if (actionCount == 0)
        {
            if (!CheckIfEmpty(currentPressed)) 
            {
                firstPressed = currentPressed;
                potentialMoves = GetValidMoves(firstPressed);
                for (int i = 0; i < potentialMoves.Count; i++)
                {
                    //redo color code 
                    ColorBlock cb = potentialMoves[i].colors;
                    cb.normalColor = potentialMoves[i].colors.highlightedColor;
                    potentialMoves[i].colors = cb;
                }
                actionCount += 1; 
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
                for (int i = 0; i < potentialMoves.Count; i++)
                {
                    //redo color code 
                    ColorBlock cb = potentialMoves[i].colors;
                    cb.normalColor = firstPressed.colors.highlightedColor;
                    potentialMoves[i].colors = cb;
                }
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

    //used to check properties of button cords 
    public int SumCord(int[] arr)
    {
        int sum = 0;
        for (int i = 0; i < arr.Length; i++)
        {
            sum += arr[i];
        }
        return sum;
    }

    public List<Button> GetValidMoves(Button currentPressed)
    {
        string pieceType = currentPressed.GetComponentInChildren<Text>().text;
        int[] currentButtonCord = buttonMapping[currentPressed];
        Debug.Log("current grid coord: " + currentButtonCord[0] + "," + currentButtonCord[1]);
        List<int[]> possibleMoves = new List<int[]>();
        List<Button> validMoves = new List<Button>();
        //all possible moves bc currently to lazy to write out a loop that finds them all 
        // 1 up 
        int[] upCord = { currentButtonCord[0], currentButtonCord[1] + 1 };
        // 2 right  
        int[] rightCord = { currentButtonCord[0] + 1, currentButtonCord[1] };
        //3 down 
        int[] downCord = { currentButtonCord[0], currentButtonCord[1] - 1 };
        // 4 left
        int[] leftCord = { currentButtonCord[0] - 1, currentButtonCord[1] };
        // 5 up right diag 
        int[] upRightCord = { currentButtonCord[0] + 1, currentButtonCord[1] + 1 };
        // 6 down right diag
        int[] downRightCord = { currentButtonCord[0] + 1, currentButtonCord[1] - 1 };
        // 7 up left diag
        int[] upLeftCord = { currentButtonCord[0] - 1, currentButtonCord[1] + 1 };
        // 8 down left diag
        int[] downLeftCord = { currentButtonCord[0] - 1, currentButtonCord[1] - 1 };
        // 9 possible tiger moves 
        int[] upTwoCord = { currentButtonCord[0], currentButtonCord[1] + 2 };
        // 10 right  
        int[] rightTwoCord = { currentButtonCord[0] + 2, currentButtonCord[1] };
        // 11 down 
        int[] downTwoCord = { currentButtonCord[0], currentButtonCord[1] - 2 };
        // 12 left
        int[] leftTwoCord = { currentButtonCord[0] - 2, currentButtonCord[1] };
        // 13 up right diag 
        int[] upRightTwoCord = { currentButtonCord[0] + 2, currentButtonCord[1] + 2 };
        // 14 down right diag
        int[] downRightTwoCord = { currentButtonCord[0] + 2, currentButtonCord[1] - 2 };
        // 15 up left diag
        int[] upLeftTwoCord = { currentButtonCord[0] - 2, currentButtonCord[1] + 2 };
        // 16 down left diag
        int[] downLeftTwoCord = { currentButtonCord[0] - 2, currentButtonCord[1] - 2 };
        Debug.Log("generating valid moves");
        //these are always possible moves
        possibleMoves.Add(upCord);
        possibleMoves.Add(rightCord);
        possibleMoves.Add(downCord);
        possibleMoves.Add(leftCord);
        // check if sum is odd, allow for diag movement  
        if (SumCord(currentButtonCord) % 2 == 0)
        {
            // if diag is valid then these are possible  
            possibleMoves.Add(upRightCord);
            possibleMoves.Add(downRightCord);
            possibleMoves.Add(upLeftCord);
            possibleMoves.Add(downLeftCord); 
            // if tiger turn then add these as the tiger can possible capture, jumping over a space  
            if (pieceType == "T")
            {
                possibleMoves.Add(upTwoCord);
                possibleMoves.Add(rightTwoCord);
                possibleMoves.Add(downTwoCord);
                possibleMoves.Add(leftTwoCord);
                possibleMoves.Add(upRightTwoCord);
                possibleMoves.Add(downRightTwoCord);
                possibleMoves.Add(upLeftTwoCord);
                possibleMoves.Add(downLeftTwoCord);
            }
               // Debug.Log("Current move list size " + possibleMoves.Count);
        }
        else if (pieceType == "T")
        {
            possibleMoves.Add(upTwoCord);
            possibleMoves.Add(rightTwoCord);
            possibleMoves.Add(downTwoCord);
            possibleMoves.Add(leftTwoCord);
            //Debug.Log("Current move list size " + possibleMoves.Count);   
        }
        Debug.Log("possible move size list " + possibleMoves.Count);
        for(int i = 0; i < possibleMoves.Count; i++)
        {
            Debug.Log("up cord " + possibleMoves[i][0] + "," + possibleMoves[i][1]);
        }
        //asses if possible move is valid and adds to the valid list
        for (int i = 0; i < possibleMoves.Count; i++)
        {
            for(int x = 0; x < cordKeys.Count; x++)
            {
                if(possibleMoves[i][0] == cordKeys[x][0] && possibleMoves[i][1] == cordKeys[x][1])
                {
                    if (CheckIfEmpty(grid[cordKeys[x]]))
                    {
                        validMoves.Add(grid[cordKeys[x]]);
                    }
                }
            }
            //Debug.Log("x: " + possibleMoves[i][0] + "y: " + possibleMoves[i][0]);
          
        }
        Debug.Log("Current valid move list size: " + validMoves.Count);
        return validMoves; 
    }
    //when I become smarter I will write this 
    /*public void generatePossibleMoves(List<int[]> possibleMoves, int[] currentCord, string piece)
    {
        if(piece == "T")
        {

        }
        else
        {

        }
    }*/
    // set up a new board to play, may need to shift this to Start() once menu UI is put is in place 
    void Awake()
    {
        Debug.Log("list is size is " + buttons.Count);
        BoardSetup(buttons);
        Debug.Log("dict test " + grid.Count);
        int[] test = { 0, 0 };
        //Debug.Log("test name " + grid[test].name);
        int[] test2 = { 0, 0 };
        List<int> a = new List<int>() { 1 };
        List<int> b = new List<int>() { 1 };
        Debug.Log("Test " + test[0]+ "," + test[1]);
        Debug.Log("cordKey " + cordKeys[0][0] + "," + cordKeys[0][1]);
    }
}
