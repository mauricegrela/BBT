using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System;

public class PoolManager : Singleton<PoolManager>
{
    private const string ASSET_PATH = "PoolObjects";

    private static Dictionary<Type, Stack<PoolObject>> poolObjects;

    protected override void Awake()
    {
        base.Awake();
        if (_instance != null && _instance != this)
            return;
        poolObjects = new Dictionary<Type, Stack<PoolObject>>();
        PreloadAll();
    }

    private void PreloadAll()
    {
        PoolObject[] objects = Resources.LoadAll<PoolObject>(ASSET_PATH);
        foreach (PoolObject obj in objects)
        {
            poolObjects.Add(obj.GetType(), new Stack<PoolObject>());
			
            for (int i = 0; i < obj.nPreloads; i++)
            {
                CreateNewInstance(obj);
            }
        }
    }

    private void CreateNewInstance(PoolObject obj)
    {
        PoolObject newObj = Instantiate(obj) as PoolObject;
        newObj.gameObject.SetActive(false);
        newObj.transform.parent = this.transform;
        newObj.name = obj.name;
        poolObjects[obj.GetType()].Push(newObj);
    }

    public T Spawn<T>(Transform parent, bool isActive = true) where T : PoolObject
    {
        Type t = typeof(T);
		
        if (poolObjects[t].Count == 1)
        {
            CreateNewInstance(poolObjects[t].Peek());
            Debug.LogWarning(string.Format("PoolManager instantiated one more {0} on runtime!", t));
        }
		
        PoolObject obj = poolObjects[t].Pop();
        obj.transform.parent = parent;
        obj.gameObject.SetActive(isActive);

        return obj as T;
    }

    public void DeSpawn(GameObject gameObj)
    {
        DeSpawn(gameObj.GetComponent<PoolObject>());
    }

    public void DeSpawn(PoolObject obj)
    {
        obj.gameObject.SetActive(false);
        obj.gameObject.transform.parent = this.transform;
        poolObjects[obj.GetType()].Push(obj);
    }
	
}
