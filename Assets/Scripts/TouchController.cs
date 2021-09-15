using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchController : MonoBehaviour
{
    [SerializeField] private MoveController player;
    [SerializeField] private GameObject joystick;
    [SerializeField] private float maxR;
    public bool ButtonHold { private get; set; }
    private RectTransform rectTransform;

    private void Start()
    {
        ButtonHold = false;
    }
    private void Update()
    {
        if (ButtonHold)
            TouchDown();
    }
    public void TouchDown()
    {
        Vector2 mousePosition=Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 moveDirection = mousePosition - (Vector2)transform.position;
        if (moveDirection != null)
        {
            if (moveDirection.magnitude < maxR)
            {
                player.Move(moveDirection);
                joystick.transform.position = mousePosition;
            }
        }
    }
    public void TouchUp()
    {
        player.Move(Input.mousePosition - transform.position);
        joystick.transform.position = transform.position;
    }
}
