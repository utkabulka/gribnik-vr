using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldGen : MonoBehaviour
{
    [Header("Events")]
    [SerializeField]
    private GameEvent onWorldGenerated;

    [Header("Generation")]
    [SerializeField]
    private bool randomizeSeedOnStart;
    [SerializeField]
    private int seed = 228;

    [Header("Objects")]
    [SerializeField]
    private Biome[] biomes;

    private void Start() {
        if (randomizeSeedOnStart)
            seed = Random.Range(int.MinValue, int.MaxValue);
        Random.InitState(seed);
        GenerateWorld();
    }

    public void GenerateWorld() {
        StartCoroutine(_generateWorld());
    }

    private IEnumerator _generateWorld() {
        // че
        Debug.Log("мир сгенерирован");
        yield return null;
        onWorldGenerated.Raise();
    }
}
