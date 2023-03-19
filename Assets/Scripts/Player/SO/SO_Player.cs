using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[CreateAssetMenu(fileName = "Player", menuName = "CreatePlayer")]
public class SO_Player : ScriptableObject
{
    public int health;
    public int maxHealth;
    public float speed;
    public float lerpDuration;
    public int playerSpaceX;
    public int indexForms;
    public TMP_Text healthText;


    public void ResetValues()
    {
        health = maxHealth;
    }
}
