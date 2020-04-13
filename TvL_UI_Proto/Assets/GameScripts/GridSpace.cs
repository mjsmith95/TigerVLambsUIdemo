using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GridSpace : UIController
{
    public Button button;
    public Text buttonText;
    public void SetSpace()
    {
        currentPressed = buttonText;
        UpdateBaord(board);  
        Debug.Log("This button's tect is: " + buttonText.text );

     //   lastPressed = buttonText;
        
        /*
        Debug.Log(buttonText);
        string currentButtonName = this.button.name;
        int[] currentPeiceType = board[buttonText];
        buttonText.text = "";
        board[buttonText][2] = 0; 
        if (lastClickedPiece != null)
        {
            
            if(lastClickedPiece[2] == 1)
            {
                buttonText.text = "T";
                
            }
            else if(lastClickedPiece[2] == 2)
            {
                buttonText.text = "S";
            }
        }
        Debug.Log("The current piece type is " + currentPeiceType[2]);
        Debug.Log("The last clicked piece type was " + lastClickedPiece[2]);
        Debug.Log("The current selected button's name is "+button.name);
        lastClickedPiece = currentPeiceType;
        */    
    } 
}
