using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardInput : MonoBehaviour
{
    public delegate void AButtonAction();
    public static event AButtonAction OnAButton;
    public delegate void DButtonAction();
    public static event DButtonAction OnDButton;
    public delegate void SpaceButtonAction();
    public static event SpaceButtonAction OnSpaceButton;
    public delegate void NoMovementAction();
    public static event NoMovementAction OnNoMovement;
    public delegate void LeftMouseButtonAction();
    public static event LeftMouseButtonAction OnLeftMouseButton;

    void Update ()
    {
        if (Input.GetKey(KeyCode.A))
        {
            if (OnAButton != null)
            {
                OnAButton();
            }
        }
        else if (Input.GetKey(KeyCode.D))
        {
            if (OnDButton != null)
            {
                OnDButton();
            }
        }
        else if(Input.GetKeyDown(KeyCode.Space))
        {
            if(OnSpaceButton != null)
            {
                OnSpaceButton();
            }
        }
        else
        {
            if(OnNoMovement != null)
            {
                OnNoMovement();
            }
        }

        if(Input.GetMouseButtonDown(0))
        {
            if(OnLeftMouseButton != null)
            {
                OnLeftMouseButton();
            }
        }
	}
}
