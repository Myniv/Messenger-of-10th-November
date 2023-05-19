using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] Animator animator;
    public float force = 5f;

    public virtual void MovementSpeed(float Speed = 0.0f){
        animator.SetFloat("Speed",Mathf.Abs(Speed));
    }
    public virtual void Flip(bool m_FacingRight)
    {
        // Switch the way the player is labelled as facing.
        //Face Right
        Vector3 theScale = transform.localScale;
        if (m_FacingRight == true && theScale.x < 0)
        {
            theScale.x *= -1;
        }
        //Face Left
        else if (m_FacingRight == false && theScale.x > 0)
        {
            theScale.x *= -1;
        }
        transform.localScale = theScale;

        // Multiply the player's x local scale by -1.

    }
}
