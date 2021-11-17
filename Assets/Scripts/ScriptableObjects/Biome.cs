using UnityEngine;

[CreateAssetMenu]
public class Biome : ScriptableObject
{
    public GameObject baseChunk;
    public ObjectList TreeList;
    public int treeDensity = 5;
    public float maxTreeScale = 1.5f;
    public float minTreeScale = 0.7f;
    public ObjectList MushroomList;
    public int mushroomDensity = 5;
    public float maxShroomScale = 2f;
    public float minShroomScale = 1f;
}
