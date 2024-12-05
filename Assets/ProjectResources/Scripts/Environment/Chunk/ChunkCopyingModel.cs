using UnityEngine;
using UnityEngine.Tilemaps;

public class ChunkCopyingModel
{
    private Tilemap sourceTilemap { get; set; }
    private Tilemap targetTilemap { get; set; }

    private Vector3Int positionOffset { get; set; }

    public ChunkCopyingModel(Tilemap sourceTilemap, Tilemap targetTilemap, Vector3Int positionOffset)
    {
        this.sourceTilemap = sourceTilemap;
        this.targetTilemap = targetTilemap;

        this.positionOffset = positionOffset;
    }

    public void Copy()
    {
        BoundsInt bounds = sourceTilemap.cellBounds;

        for (int x = bounds.xMin; x < bounds.xMax; x++)
        {
            for (int y = bounds.yMin; y < bounds.yMax; y++)
            {
                Vector3Int cellPosition = new Vector3Int(x, y, 0);
                TileBase tile = sourceTilemap.GetTile(cellPosition);

                if (tile != null)
                {
                    Vector3Int targetPosition = cellPosition + positionOffset;
                    targetTilemap.SetTile(targetPosition, tile);
                }
            }
        }
    }
}