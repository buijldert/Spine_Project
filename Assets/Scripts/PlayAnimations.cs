using Spine.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAnimations : MonoBehaviour
{
    [SerializeField]
    private GameObject _bodyObject;
    private SkeletonAnimation _bodySkeleton;

    [SerializeField]
    private GameObject _headObject;
    private SkeletonAnimation _headSkeleton;

    [SerializeField]
    private GameObject _leftArmObject;
    private SkeletonAnimation _leftArmSkeleton;

    [SerializeField]
    private GameObject _rightArmObject;
    private SkeletonAnimation _rightArmSkeleton;

    void OnEnable ()
    {
        KeyboardInput.OnAButton += AnimateRun;
        KeyboardInput.OnDButton += AnimateRun;
        KeyboardInput.OnNoMovement += AnimateIdle;
        _bodySkeleton = _bodyObject.GetComponent<SkeletonAnimation>();
        _headSkeleton = _headObject.GetComponent<SkeletonAnimation>();
        _leftArmSkeleton = _leftArmObject.GetComponent<SkeletonAnimation>();
        _rightArmSkeleton = _rightArmObject.GetComponent<SkeletonAnimation>();
    }

    private void AnimateRun()
    {
        _bodySkeleton.loop = true;
        _bodySkeleton.AnimationName = "Run";
        _headSkeleton.loop = true;
        _headSkeleton.AnimationName = "Run";
    }

    private void AnimateIdle()
    {
        _bodySkeleton.loop = true;
        _bodySkeleton.AnimationName = "Idle";
        _headSkeleton.loop = true;
        _headSkeleton.AnimationName = "Idle";
    }

	void OnDisable ()
    {
        KeyboardInput.OnAButton -= AnimateRun;
        KeyboardInput.OnDButton -= AnimateRun;
        KeyboardInput.OnNoMovement -= AnimateIdle;
    }
}
