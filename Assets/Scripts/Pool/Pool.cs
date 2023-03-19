using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pool : MonoBehaviour
{
    [SerializeField]
    private SO_Pool m_pool;

    private List<GameObject> poolList;

    void Start()
    {
        //New list of poollist
        poolList = new List<GameObject>();

        //Instantiate all new objects with poolsize and we add them in the list 
        for(int i = 0; i < m_pool.poolSize; i++)
        {
            GameObject newPool = Instantiate(m_pool.prefabToPool
                [Random.Range(0, m_pool.prefabToPool.Length)]);
            newPool.SetActive(false);
            poolList.Add(newPool);
        }
    }

    //Function to check if a object is inactive or not
    public GameObject GetAvailaibleObject()
    {
        if(poolList != null)
        {
            foreach(GameObject pool in poolList)
            {
                if (!pool.activeSelf)
                {
                    return pool;
                }
            }
        }
        return null;
    }
}
