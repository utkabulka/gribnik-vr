using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Biome : ScriptableObject
{
    public GameObject baseChunk;
    public ObjectList TreeList;
    public int treeDensity = 5;
    public float maxTreeScale = 1.5f;
    public float minTreeScale = 0.7f;
    public ObjectList RockList;
}
