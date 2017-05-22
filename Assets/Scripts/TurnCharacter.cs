using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;

public class TurnCharacter : MonoBehaviour
{
    private PlayAnimations _playAnimations;

    private void Start()
    {
        _playAnimations = GetComponent<PlayAnimations>();
    }

    private void Update()
    {
        Vector2 mousePos = Input.mousePosition;

        if(mousePos.x < Screen.width/2)
        {
            _playAnimations._headSkeleton.skeleton.FlipX = true;
            _playAnimations._bodySkeleton.skeleton.FlipX = true;
            _playAnimations._leftArmSkeleton.skeleton.FlipX = true;
            _playAnimations._rightArmSkeleton.skeleton.FlipX = true;
        }
        else
        {
            _playAnimations._headSkeleton.skeleton.FlipX = false;
            _playAnimations._bodySkeleton.skeleton.FlipX = false;
            _playAnimations._leftArmSkeleton.skeleton.FlipX = false;
            _playAnimations._rightArmSkeleton.skeleton.FlipX = false;
        }
    }
}
