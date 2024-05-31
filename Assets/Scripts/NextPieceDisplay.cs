using UnityEngine;
using UnityEngine.UI;

public class NextPieceDisplay : MonoBehaviour
{
    public Image[] gridImages; 

    private void ClearGrid()
    {
        foreach (var image in gridImages)
        {
            image.enabled = false; 
        }
    }

    public void UpdateNextPiece(TetrominoData nextPieceData)
    {
        ClearGrid();
        
        Vector2Int offset = new Vector2Int(2, 2);

        foreach (Vector2Int cell in nextPieceData.cells)
        {
            int x = cell.x + offset.x;
            int y = cell.y + offset.y;
            
            int index = y * 5 + x;
            
            if (index >= 0 && index < gridImages.Length)
            {
                gridImages[index].enabled = true;
                gridImages[index].sprite = nextPieceData.tile.sprite;
            }
        }
    }
}