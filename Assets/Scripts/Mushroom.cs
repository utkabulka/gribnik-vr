using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mushroom : MonoBehaviour
{
    public MushroomData mushroomData;
    private bool isPickedUp = false;

    private void Start() {
        GetComponent<Rigidbody>().mass = this.transform.localScale.x;
    }

    public int GetPoints() {
        return (int)(this.transform.localScale.x * mushroomData.BasePoints);
    }

    public void SetPickedUp(bool value) {
        isPickedUp = value;
    }
}
