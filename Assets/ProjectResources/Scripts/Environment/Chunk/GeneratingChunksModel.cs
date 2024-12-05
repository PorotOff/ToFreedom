using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GeneratingChunksModel : MonoBehaviour
{
    private Tilemap mainTilemap { get; set; }
    private List<ChunkWeightPairModel> chunkPrefabs { get; set; }

    private float chunkScale { get; set; }

    public GeneratingChunksModel(Tilemap mainTilemap, List<ChunkWeightPairModel> chunkPrefabs, float chunkScale)
    {
        this.mainTilemap = mainTilemap;
        this.chunkPrefabs = chunkPrefabs;

        this.chunkScale = chunkScale;
    }

    public virtual void GenerateChunk(Vector3Int offsetPosition)
    {
        if (chunkPrefabs.Count == 0) return;

        Tilemap chunkPrefab = SelectChunkPrefab();
        
        ChunkCopyingModel chunkCopyingModel = new ChunkCopyingModel(chunkPrefab, mainTilemap, offsetPosition);
        chunkCopyingModel.Copy();
    }

    protected virtual Tilemap SelectChunkPrefab()
    {
        return chunkPrefabs[Random.Range(0, chunkPrefabs.Count)].tilemapPrefab;
    }
}