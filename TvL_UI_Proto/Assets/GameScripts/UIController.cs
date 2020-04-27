using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIController : MonoBehaviour
{
    public List<Button> buttons;
    public Dictionary<Button,string> grid;

    public void BoardSetup(List<Button> buttonElments)
    {
        for(int i =0; i < 25; i++)
        {
            Debug.Log("Button name is " + buttonElments[i].name);
            // add a new button + string to the dict 
            grid.Add(buttonElments[i], "");
            // check if the button is a corner space 
            if (buttonElments[i].name == "GridSpace" || buttonElments[i].name == "GridSpace4" || buttonElments[i].name == "GridSpace20" || buttonElments[i].name == "GridSpace24")
            {
                //update the value in the dict 
                grid[buttonElments[i]] = "T";
                //set the actual text in game to the correct char
                buttonElments[i].GetComponentInChildren<Text>().text = "T";
            }
        }
    }

    void Awake()
    {
        Debug.Log("list is size is " + buttons.Count);
        BoardSetup(buttons);  
    }
}
