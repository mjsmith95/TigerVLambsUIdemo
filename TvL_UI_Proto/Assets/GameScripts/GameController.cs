using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public List<Button> buttons;
    public Dictionary<int[], string> grid;
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
                int[] cord = {x,y};
                string bName = buttonElments[count].name;

                Debug.Log(bName);

               // grid.Add(cord, bName);
                count += 1;
                Debug.Log("x: " + x + " y: " + y);
            }     
        }
    }
    void Awake()
    {
        Debug.Log("list is size is " + buttons.Count);
        BoardSetup(buttons);
    }
}
