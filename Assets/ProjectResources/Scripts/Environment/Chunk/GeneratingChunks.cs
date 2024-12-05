using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GeneratingChunks : MonoBehaviour
{
    [SerializeField] private Tilemap mainTilemap;
    [SerializeField] private List<ChunkWeightPairModel> chunkPrefabs;
    [SerializeField] private float chunkScale;

    private GeneratingChunksModel chunkGenerator;

    private void Awake()
    {
        List<Tilemap> tilemaps = new List<Tilemap>();
        List<int> weights = new List<int>();

        foreach (var chunkPrefab in chunkPrefabs)
        {
            tilemaps.Add(chunkPrefab.tilemapPrefab);
            weights.Add(chunkPrefab.spawnWeight);
        }

        // chunkGenerator = new GeneratingChunksModel();
    }
}