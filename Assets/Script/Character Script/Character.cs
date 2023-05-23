using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Character : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] UnityEvent meetNPC;
    [SerializeField] UnityEvent foundObject;
    public float force = 5f;

    public virtual void RunAnimation(float Speed = 0.0f){
        animator.SetFloat("Speed",Mathf.Abs(Speed));
    }
    public virtual void Flip(bool m_FacingRight)
    {
        // Switch the way the player is labelled as facing.
        Vector3 theScale = transform.localScale;
        //Face Right
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
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("NPC")){
            meetNPC.Invoke();
        }
    }    
}
