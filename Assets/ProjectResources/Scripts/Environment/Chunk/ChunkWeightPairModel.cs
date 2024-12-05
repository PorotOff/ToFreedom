using UnityEngine;
using UnityEngine.Tilemaps;

[System.Serializable]
public class ChunkWeightPairModel
{
    [field: SerializeField] public Tilemap tilemapPrefab { get; set; }
    [field: SerializeField, Range(0, 100)] public int spawnWeight { get; set; }
}