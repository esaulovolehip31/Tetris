using UnityEngine;
using UnityEngine.Tilemaps;

public class Ghost : MonoBehaviour
{
    public Tile tile;
    public Board mainBoard;
    public Piece trackingPiece;

    public Tilemap tilemap { get; private set; }
    public Vector3Int[] cells { get; private set; } // cells for ghost piece
    public Vector3Int position { get; private set; } // position of the ghost piece

    private void Awake()
    {
        tilemap = GetComponentInChildren<Tilemap>();
        cells = new Vector3Int[4];
    }

    private void LateUpdate()
    {
        Clear();
        Copy();
        Drop();
        Set();
    }

    private void Clear() // clear previous ghost pieces
    {
        for (int i = 0; i < cells.Length; i++)
        {
            Vector3Int tilePosition = cells[i] + position; //calculating tile position
            tilemap.SetTile(tilePosition, null);// clearing tile at the position
        }
    }

    private void Copy()
    {
        if (cells.Length != trackingPiece.cells.Length)
        {
            cells = new Vector3Int[trackingPiece.cells.Length];
        }
        
        for (int i = 0; i < trackingPiece.cells.Length; i++) {
            cells[i] = trackingPiece.cells[i]; // copying cells from tracking piece
        }
    }

    private void Drop()
    {
        Vector3Int position = trackingPiece.position;

        int current = position.y;
        int bottom = -mainBoard.boardSize.y / 2 - 1; // calculating bottom boundary

        mainBoard.Clear(trackingPiece);

        for (int row = current; row >= bottom; row--)
        {
            position.y = row; // moving the ghost piece

            if (mainBoard.IsValidPosition(trackingPiece, position)) {
                this.position = position; // updating position if position of ghost tile is valid
            } else {
                break;
            }
        }

        mainBoard.Set(trackingPiece);
    }

    private void Set()
    {
        for (int i = 0; i < cells.Length; i++)
        {
            Vector3Int tilePosition = cells[i] + position;
            tilemap.SetTile(tilePosition, tile); //setting tile at the position
        }
    }

}