using UnityEditor;
using UnityEngine;


[CreateAssetMenu(menuName = "Scriptable/ProjectileData", fileName = "ProjectileData", order = 0)]
public class ProjectileData : ScriptableObject
{
    public string name;
    public float damage;
    public float currentSpeed;
    public float maxSpeed;
    public float minSpeed;

    public AudioClip dieClip;
    public AudioClip hitClip;
}
