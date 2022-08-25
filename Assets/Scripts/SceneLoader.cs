using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(ELoadScene))]
public class SceneLoader : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void LoadScene()
    {
        SceneManager.LoadScene((int)scene);
    }
    
    [SerializeField]
    private ELoadScene scene;
}

public enum ELoadScene
{
    Title,
    Lobby,
    Game
}