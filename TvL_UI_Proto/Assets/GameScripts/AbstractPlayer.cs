using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Player
{
    string name; // player name 
    string playerType; // human or AI players 
    string pieceType; // Tiger of lamb piece obj 

    //method will be same for all needs to be implemented once board and pieces are created
    public abstract bool IsValidMove(int x,int y, List<List<object>> board);
    // Updates the postion of a piece on the board
    public abstract void MovePiece(int x, int y, object piece);
    // Returns a list of possible moves from current board
    public abstract List<(int x, int y)> GetPossibleMoves( List<List<object>> board); 

}
