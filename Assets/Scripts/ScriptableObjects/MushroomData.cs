using UnityEngine;

[CreateAssetMenu]
public class MushroomData : ScriptableObject
{
    public bool isEdible = true;
    public bool isToxic = false;
    public int BasePoints = 100;
}
