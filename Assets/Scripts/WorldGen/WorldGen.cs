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
    private bool randomizeSeedOnStart = true;
    [SerializeField]
    private int seed = 228;
    
    // пока что тупой генератор
    [SerializeField]
    private int worldSize = 10;

    [Header("Objects")]
    [SerializeField]
    private Biome[] biomes;

    private void Start() {
        if (randomizeSeedOnStart) {
            seed = Random.Range(int.MinValue, int.MaxValue);
        }
        Random.InitState(seed);
        Debug.Log("сид этого мира: " + seed);
        GenerateWorld();
    }

    public void GenerateWorld() {
        StartCoroutine(_generateWorld());
    }

    private IEnumerator _generateWorld() {
        for (int x = 0; x < worldSize; x++)
        {
            for (int z = 0; z < worldSize; z++)
            {
                GameObject newChunk = Instantiate(biomes[Random.Range(0, biomes.Length)].baseChunk, this.transform);
                newChunk.transform.localPosition = new Vector3(x * 10, 0, z * 10);
                newChunk.GetComponent<Chunk>().GenerateObjects();
            }
        }

        Debug.Log("мир сгенерирован");
        onWorldGenerated.Raise();
        Destroy(this);
        yield return null;
    }
}
