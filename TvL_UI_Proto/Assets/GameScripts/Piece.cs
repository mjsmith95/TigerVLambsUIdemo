using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieceInterface : MonoBehaviour
{
    string pieceType;
    string id;
    int xCord;
    int yCord;
    bool inPlay;
    int boardPos;

    public int BoardPos { get => boardPos; set => boardPos = value; } 
    public bool InPlay { get => inPlay; set => InPlay = value; }
    public string ID { get => id; set => id = value; }
    public string PieceType { get => pieceType; set => pieceType = value; }

}
