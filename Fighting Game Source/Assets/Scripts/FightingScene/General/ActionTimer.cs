using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionTimer : MonoBehaviour
{
    Action initialAction, constantAction, finalAction;
    float timer;

    public static void Create(GameObject o, Action finalAction, float time)
    {
        ActionTimer instance;
        instance = o.AddComponent<ActionTimer>();

        instance.finalAction = finalAction;

        instance.timer = time;
    }
    public static void Create(GameObject o, Action initialAction, Action finalAction, float time)
    {
        ActionTimer instance;
        instance = o.AddComponent<ActionTimer>();

        instance.initialAction = initialAction;
        instance.finalAction = finalAction;

        instance.timer = time;
    }

    private void Start()
    {
        initialAction?.Invoke();
    }

    private void Update()
    {
        timer -= Time.deltaTime;
        if(timer <= 0)
        {
            finalAction?.Invoke();
            Destroy(this);
        }
    }
}
