using UnityEngine;

public class SqueekChanceModel
{
    private int squeekChance { get; set; }
    private int minSqueekChance { get; set; }
    private int maxSqueekChance { get; set; }

    public SqueekChanceModel(int squeekChance, int minSqueekChance, int maxSqueekChance)
    {
        this.squeekChance = squeekChance;
        this.minSqueekChance = minSqueekChance;
        this.maxSqueekChance = maxSqueekChance;
    }

    public bool IsSqueekChance()
    {
        int chance = Random.Range(minSqueekChance, maxSqueekChance);

        return squeekChance > chance;
    }
}