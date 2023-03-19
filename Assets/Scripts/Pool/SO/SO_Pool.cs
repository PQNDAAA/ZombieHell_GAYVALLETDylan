using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Pool", menuName = "Pool/CreatePool")]
public class SO_Pool : ScriptableObject
{
    public int poolSize;
    public GameObject[] prefabToPool;
}
