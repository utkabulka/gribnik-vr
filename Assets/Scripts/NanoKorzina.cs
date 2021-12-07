using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NanoKorzina : MonoBehaviour
{
    [SerializeField]
    private Game game;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Mushroom")
        {
            Mushroom mushroom = other.transform.parent.GetComponent<Mushroom>();
            if (mushroom.wasPickedUp)
            {
                game.AddScore(other.transform.parent.gameObject.GetComponent<Mushroom>().GetPoints());
                Destroy(other.transform.parent.gameObject);
            }
        }
    }
}
