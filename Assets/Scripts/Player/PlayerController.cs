using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //ScriptableObject
    [SerializeField]
    private SO_Player player;
    [SerializeField]
    private SO_PlayersMoveTo m_PlayersMoveTo;

    public int currentIndex = -1;

    private int playerLocationX = 0;
    Vector3 positionToMoveTo;
    //Boolean to check if the movement is finished
    bool movementIsFinished = true;

    Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }
    void Update()
    {
        //Top movement
        if (Input.GetKeyDown(KeyCode.W) && currentIndex < 1 && movementIsFinished) // +1
        {
            playerLocationX += player.playerSpaceX;
            playerMoveTo("StrafeLeft");
            currentIndex++;
        }
        //Bottom movement
        if (Input.GetKeyDown(KeyCode.S) && currentIndex > -1 && movementIsFinished) // -1
        {
            playerLocationX -= player.playerSpaceX;
            playerMoveTo("StrafeRight");
            currentIndex--;
        }
        //Run movement
        if (Input.GetKeyDown(KeyCode.Z))
        {
            animator.SetBool("Run", true);
        }
    }

    //The smooth movement when the player must go to the new position 
    //Avoid the basic teleportation effect
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
    //The player goes to the new road with the lerp position 
    //The "direction" param is the animation
    private void playerMoveTo(string direction)
    {
        positionToMoveTo = m_PlayersMoveTo.MoveTo(this.gameObject, playerLocationX);
        StartCoroutine(LerpPosition(positionToMoveTo, player.lerpDuration, direction));
    }

}
