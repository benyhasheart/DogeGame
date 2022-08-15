using UnityEditor;
using UnityEngine;


    [CreateAssetMenu(menuName = "Scriptable/BulletData", fileName = "BulletData", order = 0)]
    public class BulletData : ScriptableObject
    {
    public string bulletName;
    public float damage;
    public float currentSpeed;
    public float maxSpeed;
    public float minSpeed;

    public AudioClip dieClip;
    public AudioClip hitClip;
}
