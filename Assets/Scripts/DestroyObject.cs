using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObject : MonoBehaviour
{
    public void DestroyThisGameObject() {
        Destroy(this.gameObject);
    }

    public void DestroyGameObject(GameObject gameObject) {
        Destroy(gameObject);
    }

}
