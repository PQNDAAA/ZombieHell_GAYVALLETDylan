using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int currentIndex = -1;

    public int playerSpaceX = 8;

    private int playerLocationX = 0;

    public float speed = 2.0f;

    public float lerpDuration = 2f;

    Vector3 positionToMoveTo;
    bool movementIsFinished = true;

    Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();     
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W) && currentIndex < 1) // +1
        {
            playerLocationX += playerSpaceX;
            playerMoveTo("StrafeLeft");
            currentIndex++;
        }
        if (Input.GetKeyDown(KeyCode.S) && currentIndex > -1) // -1
        {
            playerLocationX -= playerSpaceX;
            playerMoveTo("StrafeRight");
            currentIndex--;
        }
        if (Input.GetKeyDown(KeyCode.Z))
        {
            animator.SetBool("Run", true);
        }
    }

    IEnumerator LerpPosition(Vector3 targetPosition, float duration, string anim)
    {
        //isFinished false
        movementIsFinished = false;

        float time = 0;
        float t;

        Vector3 startPosition = transform.position;

        while (time < duration)
        {
            t = time / duration;
            //Smooth Step Lerp Math Formula
            t = t * t * (3f - 2f * t);
            animator.SetBool(anim, true);
            //Lerp between the start & target position 
            transform.position = Vector3.Lerp(startPosition, targetPosition, t);
            time += Time.deltaTime;

            yield return null;
        }

        transform.position = targetPosition;
        //IsFinished true
        movementIsFinished = true;
        animator.SetBool(anim, false);
    }
    private void playerMoveTo(string direction)
    {
        positionToMoveTo = new Vector3(playerLocationX, 
            this.transform.position.y, this.transform.position.z);
        StartCoroutine(LerpPosition(positionToMoveTo, lerpDuration, direction));
    }

}
