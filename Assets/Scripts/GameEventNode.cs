using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GameEventNode : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public abstract void ExecuteEvent();
    

    public void EndEvent()
    {
        onEndEvent();
    }


    public Action onEndEvent;

}


