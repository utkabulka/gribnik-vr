using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chunk : MonoBehaviour
{
    [SerializeField]
    private Biome biome;

    [SerializeField]
    private GameObject contents;

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Player") {
            contents.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.gameObject.tag == "Player") {
            contents.SetActive(false);
        }
    }

    // метод вызывается из ворлд гена
    public void GenerateObjects() {
        StartCoroutine(_generateObjects());
    }

    private IEnumerator _generateObjects(){ 
        
        yield return null;
    }
}
