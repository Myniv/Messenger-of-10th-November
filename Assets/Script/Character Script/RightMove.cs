using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class RightMove : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{

    [SerializeField] Character character;
    bool isPressed = false;
    bool m_FacingRight = true;


    void Update()
    {
        if (isPressed)
        {
            character.transform.Translate(character.force * Time.deltaTime, 0, 0);
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        isPressed = true;
        character.Flip(m_FacingRight);
        character.RunAnimation(1);

    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isPressed = false;
        character.RunAnimation(0);
    }
}