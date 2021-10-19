using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldGen : MonoBehaviour
{
    [SerializeField]
    private bool randomizeSeedOnStart;
    [SerializeField]
    private int seed = 228;

    private void Start() {
        if (randomizeSeedOnStart)
            seed = Random.Range(int.MinValue, int.MaxValue);
        Random.InitState(seed);
    }
}
