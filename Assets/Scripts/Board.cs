using UnityEngine;
using UnityEngine.Tilemaps;

public class Board : MonoBehaviour
{
    public Tilemap tilemap { get; private set; }
    public Piece activePiece { get; private set; }
    public int scoreThreshold = 10000; //score threshold for speed increase
    public float speedIncreaseFactor = 0.8f;
    public TetrominoData[] tetrominoes;
    public Vector2Int boardSize = new Vector2Int(10, 20);
    public Vector3Int spawnPosition = new Vector3Int(-1, 8, 0);
    public GameOver GameOverScreen;
    public ScoreManager scoreManager;
    public int points;
    public NextPieceDisplay nextPieceDisplay;
    
    private TetrominoData nextPieceData;

    public RectInt Bounds
    {
        get
        {
            Vector2Int position = new Vector2Int(-boardSize.x / 2, -boardSize.y / 2); // calculating bottom left corener
            return new RectInt(position, boardSize); // return the bounds of the board
        }
    }

    private void Awake()
    {
        tilemap = GetComponentInChildren<Tilemap>(); // get tilemap
        activePiece = GetComponentInChildren<Piece>();// get active piece
        scoreManager = FindObjectOfType<ScoreManager>(); // find score manager in the scene

        for (int i = 0; i < tetrominoes.Length; i++)
        {
            tetrominoes[i].Initialize(); // initializing tiles data
        }
    }

    public void IncreaseSpeed()
    {
        activePiece.stepDelay *= speedIncreaseFactor;
        Debug.Log($"Speed increased. New step delay: {activePiece.stepDelay}"); // log the new speed delay
    }

    private void Start()
    {
        SetNextPiece(); // setting next piece to spawn
        SpawnPiece(); // spawn the initial piece
    }

    public void SpawnPiece()
    {
        TetrominoData data = nextPieceData;  // get next piece data
        SetNextPiece();  //update next piece  data

        activePiece.Initialize(this, spawnPosition, data);

        if (IsValidPosition(activePiece, spawnPosition))
        {
            Set(activePiece); // set active piece on board
        }
        else
        {
            GameOver(); // end the game if piece is out of bounds
        }
    }
    
    private void SetNextPiece()
    {
        int random = Random.Range(0, tetrominoes.Length); // pick random piece
        nextPieceData = tetrominoes[random]; // update next piece data

        if (nextPieceDisplay != null)
        {
            nextPieceDisplay.UpdateNextPiece(nextPieceData); // show the next piece
        }
    }

    public void GameOver()
    {
        GameOverScreen.Setup(); // activate game over screen
        enabled = false; // disable the board
        activePiece.enabled = false;// disable the active piece
    }

    public void Set(Piece piece)
    {
        for (int i = 0; i < piece.cells.Length; i++)
        {
            Vector3Int tilePosition = piece.cells[i] + piece.position;
            tilemap.SetTile(tilePosition, piece.data.tile);
        }
    }

    public void Clear(Piece piece)
    {
        for (int i = 0; i < piece.cells.Length; i++)
        {
            Vector3Int tilePosition = piece.cells[i] + piece.position;
            tilemap.SetTile(tilePosition, null);
        }
    }

    public bool IsValidPosition(Piece piece, Vector3Int position)
    {
        RectInt bounds = Bounds; // get the bounds

        for (int i = 0; i < piece.cells.Length; i++)
        {
            Vector3Int tilePosition = piece.cells[i] + position; //calculate tile position

            if (!bounds.Contains((Vector2Int)tilePosition))
            {
                return false;
            }

            if (tilemap.HasTile(tilePosition))
            {
                return false;
            }
        }

        return true;
    }

    public void ClearLines()
    {
        RectInt bounds = Bounds;
        int row = bounds.yMin; // start from the bottom
        int line = 0;

        while (row < bounds.yMax)
        {
            if (IsLineFull(row))
            {
                LineClear(row); // clear the line
                line += 1;
            }
            else
            {
                row++; 
            }
        }

        if (line > 0)
        {
            int pointsEarned = CalculatePoints(line);
            points += pointsEarned;
            scoreManager.UpdateScore(points); // update the score display

            if (points >= scoreThreshold)
            {
                scoreThreshold += 10000;
                IncreaseSpeed();
            }
        }
    }

    private int CalculatePoints(int line)
    {
        switch (line)
        {
            case 1: return 100;
            case 2: return 300;
            case 3: return 700;
            case 4: return 1500;
            default: return 0;
        }
    }

    public bool IsLineFull(int row)
    {
        RectInt bounds = Bounds;

        for (int col = bounds.xMin; col < bounds.xMax; col++)
        {
            Vector3Int position = new Vector3Int(col, row, 0);

            if (!tilemap.HasTile(position))
            {
                return false;
            }
        }

        return true;
    }

    public void LineClear(int row)
    {
        RectInt bounds = Bounds;

        for (int col = bounds.xMin; col < bounds.xMax; col++)
        {
            Vector3Int position = new Vector3Int(col, row, 0);
            tilemap.SetTile(position, null);
        }

        while (row < bounds.yMax)
        {
            for (int col = bounds.xMin; col < bounds.xMax; col++)
            {
                Vector3Int position = new Vector3Int(col, row + 1, 0);
                TileBase above = tilemap.GetTile(position);

                position = new Vector3Int(col, row, 0);
                tilemap.SetTile(position, above); // move the row down
            }

            row++;
        }
    }
}

