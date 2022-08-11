using UnityEngine;

[CreateAssetMenu(menuName ="Scriptable/Player/PlayerData", fileName = "PlayerData", order = 0)]
public class PlayerData : ScriptableObject
{
    public string characterName;
    public float currentHp;
    public float maxHp;
    public float currentSpeed;
    public float maxSpeed;
    public float minSpeed;

    public AudioClip dieClip;
    public AudioClip hitClip;
}
