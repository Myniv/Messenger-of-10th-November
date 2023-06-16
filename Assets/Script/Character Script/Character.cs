using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Character : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] Button button;
    public float force = 5f;
    bool corner=false;
    public bool Corner { get => corner;}
    [SerializeField] UnityEvent enterNPC;
    [SerializeField] UnityEvent leaveNPC;
    [SerializeField] UnityEvent enterObject;
    [SerializeField] UnityEvent leaveObject;

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
            enterNPC.Invoke();
        }
     
    } 

    private void OnTriggerExit2D(Collider2D other) {
        if(other.CompareTag("NPC")){
            leaveNPC.Invoke();
        }

    }   
}
