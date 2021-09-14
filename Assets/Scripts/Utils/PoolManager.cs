using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    public GameObject prefabProjectile;
    public List<GameObject> pooledProjectiles;

    public int amount = 10;

    private void Awake()
    {
        StartPool();
    }
    private void StartPool()
    {
        pooledProjectiles = new List<GameObject>();
        for(int i = 0; i < amount; i++)
        {
            var obj = Instantiate(prefabProjectile, transform);
            obj.SetActive(false);
            pooledProjectiles.Add(obj);
        }
    }
    public GameObject GetPooledObject()
    {
        for (int i = 0; i < amount; i++)
        {
            if (!pooledProjectiles[i].activeInHierarchy)
            {
                return pooledProjectiles[i];
            }
        }
        return null;
    }
}
