using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mushroom : MonoBehaviour
{
    public MushroomData mushroomData;

    public int GetPoints() {
        return (int)(this.transform.localScale.x * mushroomData.BasePoints);
    }
}
