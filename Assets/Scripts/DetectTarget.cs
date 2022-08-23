using System;
using System.Collections;
using UnityEngine;

public class DetectTarget : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(DetectTargetCoroutine());
    }

    IEnumerator DetectTargetCoroutine()
    {
        WaitForSeconds time = new WaitForSeconds(0.2f);

        while(true)
        {
            Transform target = GameManager.GameManagerInstance.Player.transform;

            float dist = Vector3.Distance(target.position, transform.position);

            if ( dist <= detectRange)
            {
                hasTarget = true;
                targetTransform = target;
                onDetect();
            }
            else
            {
                hasTarget = false;
            }
            
            yield return time;
        }
    }
    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.tag == "Player")
    //    {
    //        hasTarget = true;
    //        targetTransform = other.transform;

    //        onDetect();
    //    }

    //}

    //private void OnTriggerExit(Collider other)
    //{
    //    if (other.tag == "Player")
    //    {
    //        hasTarget = false;
    //    }
    //}

    public bool HasTarget
    {
        get { return hasTarget; }
    }

    public Transform TargetTransform
    {
        get { return targetTransform; }
    }

    public Action onDetect;
    public float detectRange;

    private bool hasTarget;
    private Transform targetTransform;

}
