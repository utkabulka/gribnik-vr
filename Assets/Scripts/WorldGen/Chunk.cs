using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chunk : MonoBehaviour
{
    [SerializeField]
    private Biome biome;

    [SerializeField]
    private GameObject contents;

    // чтобы объекты одного типа не накладывались
    [SerializeField]
    private float minDistanceBetweenObjects = 3f;
    [SerializeField]
    private float borderOffset = 0.5f;

    private const int maxTriesForSpacing = 10;

    /*
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
    */

    // метод вызывается из ворлд гена
    public void GenerateObjects() {
        StartCoroutine(_generateObjects());
    }

    private IEnumerator _generateObjects(){
        GameObject lastGeneratedObject = null;
        GameObject newObject;

        // делаем деревья
        for (int i = 0; i < biome.treeDensity; i++)
        {
            newObject = Instantiate(biome.TreeList.props[Random.Range(0, biome.TreeList.props.Length)], contents.transform);
            newObject.transform.localPosition = _getRandomVector3();
            float randomScale = Random.Range(biome.minTreeScale, biome.maxTreeScale);
            newObject.transform.localScale = new Vector3(randomScale, randomScale, randomScale);
            newObject.transform.localEulerAngles = new Vector3(0, Random.Range(0f, 359f), 0);

            // пропускаем проверку в первую итерацию
            if (i == 0) {
                lastGeneratedObject = newObject;
                continue;
            }

            // шобы не накладывались
            GameObject gameObject = _avoidClipping(lastGeneratedObject, newObject);
            if (gameObject != null) {
                lastGeneratedObject = newObject;
            }
        }

        // грибы
        for (int i = 0; i < biome.mushroomDensity; i++)
        {
            newObject = Instantiate(biome.MushroomList.props[Random.Range(0, biome.MushroomList.props.Length)], contents.transform);
            newObject.transform.localPosition = _getRandomVector3();
            float randomScale = Random.Range(biome.minShroomScale, biome.maxShroomScale);
            newObject.transform.localScale = new Vector3(randomScale, randomScale, randomScale);
            newObject.transform.localEulerAngles = new Vector3(0, Random.Range(0f, 359f), 0);

            // пропускаем проверку в первую итерацию
            if (i == 0) {
                lastGeneratedObject = newObject;
                continue;
            }

            // шобы не накладывались
            GameObject gameObject = _avoidClipping(lastGeneratedObject, newObject);
            if (gameObject != null) {
                lastGeneratedObject = newObject;
            }
        }

        //contents.SetActive(false);
        yield return null;
    }

    private Vector3 _getRandomVector3() {
        return new Vector3(Random.Range(-5f - borderOffset, 5f - borderOffset), 0, Random.Range(-5f - borderOffset, 5f - borderOffset));
    }

    private GameObject _avoidClipping(GameObject lastGeneratedObject, GameObject newObject) {
        if (Vector3.Distance(lastGeneratedObject.transform.localPosition, newObject.transform.localPosition) < minDistanceBetweenObjects) {
            bool positionFound = false;
            for (int j = 0; j < maxTriesForSpacing; j++)
            {
                newObject.transform.localPosition = _getRandomVector3();
                if (Vector3.Distance(lastGeneratedObject.transform.localPosition, newObject.transform.localPosition) >= minDistanceBetweenObjects) {
                    positionFound = true;
                    return newObject;
                }
            }
            if (!positionFound) {
                Destroy(newObject);
                return null;
            }
        }
        return null;
    }
}
