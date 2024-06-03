using UnityEngine;
using UnityEngine.Tilemaps;

public enum Tetromino
{
    //tetrominoes:
    I, J, L, O, S, T, Z, 
    //pentominoes:
    Ip, Lp, Jp, Tp, Sp, Zp, Bird1, Bird2, P, RevP, Worm1, Worm2, Cup, Angle, Stairs, Plus, Zombie1, Zombie2 // pentomino
}

[System.Serializable]
public struct TetrominoData
{
    public Tile tile;
    public Tetromino tetromino;

    public Vector2Int[] cells { get; private set; }
    public Vector2Int[,] wallKicks { get; private set; }

    public void Initialize()
    {
        cells = Data.Cells[tetromino]; // initializing cells based on tile type
        wallKicks = Data.WallKicks[tetromino]; // initializing wallkicks based on tile type
    }

}