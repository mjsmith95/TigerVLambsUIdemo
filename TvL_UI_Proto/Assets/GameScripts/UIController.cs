using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIController : MonoBehaviour
{
    public Text[] girdSpaceList;
    string gameOverText;
    public Dictionary<Text, int[]> board;

    public Dictionary<Text,int[]> SetUI(Text[] UIElements)
    {
        Dictionary<Text, int[]> boardUIMapping = new Dictionary<Text, int[]>();

        boardUIMapping.Add(UIElements[0], new int[] { 0, 4, 1 });
        boardUIMapping.Add(UIElements[1], new int[] { 1, 4, 0 });
        boardUIMapping.Add(UIElements[2], new int[] { 2, 4, 0 });
        boardUIMapping.Add(UIElements[3], new int[] { 3, 4, 0 });
        boardUIMapping.Add(UIElements[4], new int[] { 4, 4, 1 });
        boardUIMapping.Add(UIElements[5], new int[] { 0, 3, 0 });
        boardUIMapping.Add(UIElements[6], new int[] { 1, 3, 0 });
        boardUIMapping.Add(UIElements[7], new int[] { 2, 3, 0 });
        boardUIMapping.Add(UIElements[8], new int[] { 3, 3, 0 });
        boardUIMapping.Add(UIElements[9], new int[] { 4, 3, 0 });
        boardUIMapping.Add(UIElements[10], new int[] { 0, 2, 0 });
        boardUIMapping.Add(UIElements[11], new int[] { 1, 2, 0 });
        boardUIMapping.Add(UIElements[12], new int[] { 2, 2, 0 });
        boardUIMapping.Add(UIElements[13], new int[] { 3, 2, 0 });
        boardUIMapping.Add(UIElements[14], new int[] { 4, 2, 0 });
        boardUIMapping.Add(UIElements[15], new int[] { 0, 1, 0 });
        boardUIMapping.Add(UIElements[16], new int[] { 1, 1, 0 });
        boardUIMapping.Add(UIElements[17], new int[] { 2, 1, 0 });
        boardUIMapping.Add(UIElements[18], new int[] { 3, 1, 0 });
        boardUIMapping.Add(UIElements[19], new int[] { 4, 1, 0 });
        boardUIMapping.Add(UIElements[20], new int[] { 0, 0, 1 });
        boardUIMapping.Add(UIElements[21], new int[] { 1, 0, 0 });
        boardUIMapping.Add(UIElements[22], new int[] { 2, 0, 0 });
        boardUIMapping.Add(UIElements[23], new int[] { 3, 0, 0 });
        boardUIMapping.Add(UIElements[24], new int[] { 4, 0, 1 });

        board = boardUIMapping;

        return boardUIMapping;
    }

    public void OnStart(Text[] UIElements)
    {

        Dictionary<Text,int[]> startBoard =  SetUI(UIElements);
        foreach (KeyValuePair<Text, int[]> boardPos in startBoard)
        {
            if (boardPos.Value[2] == 1)
            {
                boardPos.Key.text = "T"; 
            }
        }
    }

    public void UpdateBaord(Dictionary<Text,int[]> currentBoard)
    {

        foreach (KeyValuePair<Text, int[]> boardPos in currentBoard)
        {
            if (boardPos.Value[2] == 1)
            {
                boardPos.Key.text = "T";
            }
            else if (boardPos.Value[2] == 2)
            {
                boardPos.Key.text = "S";
            }
        }
    }

    void Start()
    {
        Debug.Log("the size on start is " + girdSpaceList.Length);
        OnStart(girdSpaceList);

    }
}
