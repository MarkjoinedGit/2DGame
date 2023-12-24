using UnityEngine;

public class KnightMovement : MonoBehaviour
{
    public KnightController knightController;
    public LogicManager manager;
    public Animator animator;
    bool jump = false;

    void Update()
    {
        if(Input.GetButtonDown("Jump") && knightController.KnightIsAlive && !manager.gameIsFinish)
        {
            jump = true;
            animator.SetBool("IsJumping", true);
        }
    }

    public void OnLanding()
    {
        animator.SetBool("IsJumping", false);
    }

    private void FixedUpdate()
    {
        knightController.Move(0, jump);
        jump = false;
    }
}
