using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int currentIndex = -1;

    public int playerSpaceX = 8;

    private int playerLocationX = 0;
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W) && currentIndex < 1) // +1
        {
            playerLocationX += playerSpaceX;
            playerMoveTo(playerLocationX);
            currentIndex++;
        }
        if (Input.GetKeyDown(KeyCode.S) && currentIndex > -1) // -1
        {
            playerLocationX -= playerSpaceX;
            playerMoveTo(playerLocationX);
            currentIndex--;
        }
    }

    private void playerMoveTo(int loc)
    {
        this.transform.position = new Vector3(playerLocationX, 
            this.transform.position.y, this.transform.position.z); 
    }

}
