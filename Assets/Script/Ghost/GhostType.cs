using UnityEngine;

[CreateAssetMenu(fileName = "GhostType", menuName = "Scriptable Objects/GhostType")]
public class GhostType : ScriptableObject
{
    public string ghostName;
    public Color ghostColor;
    public float damage;
    public float regeneration;
    public int scrorePoint;
}
