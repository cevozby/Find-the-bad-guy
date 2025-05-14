using UnityEngine;

[CreateAssetMenu(fileName = "BuffSO", menuName = "Scriptable Objects/BuffSO")]
public class BuffSO : ScriptableObject
{
    public string buffName;
    public Sprite buffIcon;
    public BuffType buffType;
    public float buffValue;
    public float buffDuration;

}

public enum BuffType
{
    Speed,
    AttackSpeed,
    Damage,
}
