using System.Collections.Generic;
using UnityEngine;

public static class Data
{
    public static readonly float cos = Mathf.Cos(Mathf.PI / 2f);
    public static readonly float sin = Mathf.Sin(Mathf.PI / 2f);
    public static readonly float[] RotationMatrix = new float[] { cos, sin, -sin, cos };

    public static readonly Dictionary<Tetromino, Vector2Int[]> Cells = new Dictionary<Tetromino, Vector2Int[]>()
    {
        { Tetromino.I, new Vector2Int[] { new Vector2Int(-1, 1), new Vector2Int( 0, 1), new Vector2Int( 1, 1), new Vector2Int( 2, 1) } },
        { Tetromino.J, new Vector2Int[] { new Vector2Int(-1, 1), new Vector2Int(-1, 0), new Vector2Int( 0, 0), new Vector2Int( 1, 0) } },
        { Tetromino.L, new Vector2Int[] { new Vector2Int( 1, 1), new Vector2Int(-1, 0), new Vector2Int( 0, 0), new Vector2Int( 1, 0) } },
        { Tetromino.O, new Vector2Int[] { new Vector2Int( 0, 1), new Vector2Int( 1, 1), new Vector2Int( 0, 0), new Vector2Int( 1, 0) } },
        { Tetromino.S, new Vector2Int[] { new Vector2Int( 0, 1), new Vector2Int( 1, 1), new Vector2Int(-1, 0), new Vector2Int( 0, 0) } },
        { Tetromino.T, new Vector2Int[] { new Vector2Int( 0, 1), new Vector2Int(-1, 0), new Vector2Int( 0, 0), new Vector2Int( 1, 0) } },
        { Tetromino.Z, new Vector2Int[] { new Vector2Int(-1, 1), new Vector2Int( 0, 1), new Vector2Int( 0, 0), new Vector2Int( 1, 0) } },
        //Pentomino figures
        { Tetromino.Ip, new Vector2Int[] { new Vector2Int(-1, 0), new Vector2Int( 0, 0), new Vector2Int( 1, 0), new Vector2Int( 2, 0), new Vector2Int( 3, 0) } },
        { Tetromino.Lp, new Vector2Int[] { new Vector2Int(0, -2), new Vector2Int(0, 0), new Vector2Int(0, -1), new Vector2Int( 0, -3), new Vector2Int( 1, -3) } },
        { Tetromino.Jp, new Vector2Int[] { new Vector2Int(0, 0), new Vector2Int( 0, -1), new Vector2Int( 0, -2), new Vector2Int( 0, -3), new Vector2Int( -1, -3) } },
        { Tetromino.Tp, new Vector2Int[] { new Vector2Int(-1, 0), new Vector2Int( 0, 0), new Vector2Int( 1, 0), new Vector2Int( 0, -1), new Vector2Int( 0, -2) } },
        { Tetromino.Sp, new Vector2Int[] { new Vector2Int( 0, 0), new Vector2Int( 1, 0), new Vector2Int(0, -1), new Vector2Int( 0, -2), new Vector2Int(-1, -2) } },
        { Tetromino.Zp, new Vector2Int[] { new Vector2Int( 0, 0), new Vector2Int( -1, 0), new Vector2Int(0, -1), new Vector2Int( 0, -2), new Vector2Int(1, -2) } },
        { Tetromino.Bird1, new Vector2Int[] { new Vector2Int( 1, 0), new Vector2Int( 0, 0), new Vector2Int( 0, -1), new Vector2Int( 0, -2), new Vector2Int(-1, -1) } },
        { Tetromino.Bird2, new Vector2Int[] { new Vector2Int( -1, 0), new Vector2Int( 0, 0), new Vector2Int( 0, -1), new Vector2Int( 0, -2), new Vector2Int(1, -1) } },
        { Tetromino.P, new Vector2Int[] { new Vector2Int(1, 0), new Vector2Int( 0, 0), new Vector2Int( 0, -1), new Vector2Int( 1, -1), new Vector2Int(0, -2) } },
        { Tetromino.RevP, new Vector2Int[] { new Vector2Int(-1, 0), new Vector2Int( 0, 0), new Vector2Int( 0, -1), new Vector2Int( -1, -1), new Vector2Int(0, -2) } },
        { Tetromino.Worm1, new Vector2Int[] { new Vector2Int(0, 0), new Vector2Int( 0, -1), new Vector2Int( 0, -2), new Vector2Int( -1, -2), new Vector2Int( -1, -3) } },
        { Tetromino.Worm2, new Vector2Int[] { new Vector2Int(0, 0), new Vector2Int( 0, -1), new Vector2Int( 0, -2), new Vector2Int( 1, -2), new Vector2Int( 1, -3) } },
        { Tetromino.Cup, new Vector2Int[] { new Vector2Int(-1, 0), new Vector2Int( 1, 0), new Vector2Int( -1, -1), new Vector2Int( 0, -1), new Vector2Int( 1, -1) } },
        { Tetromino.Angle, new Vector2Int[] { new Vector2Int(1, 0), new Vector2Int( 1, -1), new Vector2Int( 1, -2), new Vector2Int( 0, -2), new Vector2Int( -1, -2) } },
        { Tetromino.Stairs, new Vector2Int[] { new Vector2Int( 1, 0), new Vector2Int( 1, -1), new Vector2Int( 0, -1), new Vector2Int( 0, -2), new Vector2Int( -1, -2) } },
        { Tetromino.Plus, new Vector2Int[] { new Vector2Int(0, 0), new Vector2Int( 0, -1), new Vector2Int( 1, -1), new Vector2Int( -1, -1), new Vector2Int( 0, -2) } },
        { Tetromino.Zombie1, new Vector2Int[] { new Vector2Int(0, -1), new Vector2Int( 0, 0), new Vector2Int( -1, -1), new Vector2Int( 0, -2), new Vector2Int( 0, -3) } },
        { Tetromino.Zombie2, new Vector2Int[] { new Vector2Int(0, -1), new Vector2Int( 0, 0), new Vector2Int( 1, -1), new Vector2Int( 0, -2), new Vector2Int( 0, -3) } },
    };

    private static readonly Vector2Int[,] WallKicksI = new Vector2Int[,] {
        { new Vector2Int(0, 0), new Vector2Int(-2, 0), new Vector2Int( 1, 0), new Vector2Int(-2,-1), new Vector2Int( 1, 2) },
        { new Vector2Int(0, 0), new Vector2Int( 2, 0), new Vector2Int(-1, 0), new Vector2Int( 2, 1), new Vector2Int(-1,-2) },
        { new Vector2Int(0, 0), new Vector2Int(-1, 0), new Vector2Int( 2, 0), new Vector2Int(-1, 2), new Vector2Int( 2,-1) },
        { new Vector2Int(0, 0), new Vector2Int( 1, 0), new Vector2Int(-2, 0), new Vector2Int( 1,-2), new Vector2Int(-2, 1) }
    };

    private static readonly Vector2Int[,] WallKicksJLOSTZ = new Vector2Int[,] {
        { new Vector2Int(0, 0), new Vector2Int(-1, 0), new Vector2Int(-1, 1), new Vector2Int( 0,-2), new Vector2Int(-1,-2) },
        { new Vector2Int(0, 0), new Vector2Int( 1, 0), new Vector2Int( 1,-1), new Vector2Int( 0, 2), new Vector2Int( 1, 2) },
        { new Vector2Int(0, 0), new Vector2Int( 1, 0), new Vector2Int( 1, 1), new Vector2Int( 0,-2), new Vector2Int( 1,-2) },
        { new Vector2Int(0, 0), new Vector2Int(-1, 0), new Vector2Int(-1,-1), new Vector2Int( 0, 2), new Vector2Int(-1, 2) }
    };

    public static readonly Dictionary<Tetromino, Vector2Int[,]> WallKicks = new Dictionary<Tetromino, Vector2Int[,]> {
        { Tetromino.I, WallKicksI },
        { Tetromino.J, WallKicksJLOSTZ },
        { Tetromino.L, WallKicksJLOSTZ },
        { Tetromino.O, WallKicksJLOSTZ },
        { Tetromino.S, WallKicksJLOSTZ },
        { Tetromino.T, WallKicksJLOSTZ },
        { Tetromino.Z, WallKicksJLOSTZ },
        // Removed duplicate Tetromino.Ip and combined it with WallKicksI or WallKicksJLOSTZ depending on desired behavior
        { Tetromino.Ip, WallKicksI }, 
        { Tetromino.Lp, WallKicksJLOSTZ },
        { Tetromino.Jp, WallKicksJLOSTZ },
        { Tetromino.Tp, WallKicksJLOSTZ },
        { Tetromino.Sp, WallKicksJLOSTZ },
        { Tetromino.Zp, WallKicksJLOSTZ },
        { Tetromino.Bird1, WallKicksJLOSTZ },
        { Tetromino.Bird2, WallKicksJLOSTZ },
        { Tetromino.P, WallKicksJLOSTZ },
        { Tetromino.RevP, WallKicksJLOSTZ },
        { Tetromino.Worm1, WallKicksJLOSTZ },
        { Tetromino.Worm2, WallKicksJLOSTZ },
        { Tetromino.Cup, WallKicksJLOSTZ },
        { Tetromino.Angle, WallKicksJLOSTZ },
        { Tetromino.Stairs, WallKicksJLOSTZ },
        { Tetromino.Plus, WallKicksJLOSTZ },
        { Tetromino.Zombie1, WallKicksJLOSTZ },
        { Tetromino.Zombie2, WallKicksJLOSTZ }
    };
}
