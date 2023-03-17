using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Player", menuName = "PlayersMove")]
public class SO_PlayersMoveTo : ScriptableObject
{
   public Vector3 MoveTo(GameObject targetGameObject, int playerLocationX)
    {
        return new Vector3(playerLocationX, targetGameObject.transform.
            position.y, targetGameObject.transform.position.z);
    }
}
