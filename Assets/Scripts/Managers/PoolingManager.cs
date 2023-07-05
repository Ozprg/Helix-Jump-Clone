using System.Collections.Generic;
using UnityEngine;
using System;
using System.Collections;

public class PoolingManager : MonoBehaviour
{
    private List<GameObject> pooledObjects;
    [SerializeField] private GameObject objectToPool;
    [SerializeField] private int amountToPool;
    #region Singleton
    public static PoolingManager Instance { get; private set; }
    private void Awake()
    {
        Instance = this;
    }
    #endregion
    private void Start()
    {
        pooledObjects = new List<GameObject>();

        CreatePool();
    }
    public GameObject GetPooledObject()
    {
        for(int i = 0; i < pooledObjects.Count; i++)
        {
            if(!pooledObjects[i].activeInHierarchy)
            {
                return pooledObjects[i];
            }
        }
        return null;
    }

    private void CreatePool()
    {
        for (int i = 0; i < amountToPool; i++)
        {
            GameObject obj = Instantiate(objectToPool);
            obj.SetActive(false);
            pooledObjects.Add(obj);
        }
    } 
}