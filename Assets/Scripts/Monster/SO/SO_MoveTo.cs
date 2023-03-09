using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "Enemy", menuName = "Move")]
public class SO_MoveTo : ScriptableObject
{
    public Vector3 MoveTo(GameObject targetGameObject,Vector3 direction, float speed)
    {
        return targetGameObject.transform.position += direction * speed;
    }
}
