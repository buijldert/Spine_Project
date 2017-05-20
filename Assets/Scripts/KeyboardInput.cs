using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardInput : MonoBehaviour
{
    public delegate void AButtonAction();
    public static event AButtonAction OnAButton;
    public delegate void DButtonAction();
    public static event DButtonAction OnDButton;
    public delegate void NoMovementAction();
    public static event NoMovementAction OnNoMovement;

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
        else
        {
            if(OnNoMovement != null)
            {
                OnNoMovement();
            }
        }
	}
}
