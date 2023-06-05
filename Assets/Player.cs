using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private DialogData data;
    [SerializeField] private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        var horizontal = Input.GetAxis("Horizontal");

        rb.velocity = 100 * Time.fixedDeltaTime * horizontal * transform.right;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        UIManager.Instance.ShowDialogButton(false);
        UIManager.Instance.ShowQuizButton(false);
    }
}

[Serializable]
public class DialogData
{
    public string name;
    public string[] texts;
}