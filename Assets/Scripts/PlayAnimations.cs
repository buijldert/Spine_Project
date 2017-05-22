using Spine.Unity;
using System.Collections;
using UnityEngine;

public class PlayAnimations : MonoBehaviour
{
    [SerializeField]
    private GameObject _bodyObject;
    [HideInInspector]
    public SkeletonAnimation _bodySkeleton;

    [SerializeField]
    private GameObject _headObject;
    [HideInInspector]
    public SkeletonAnimation _headSkeleton;

    [SerializeField]
    private GameObject _leftArmObject;
    [HideInInspector]
    public SkeletonAnimation _leftArmSkeleton;

    [SerializeField]
    private GameObject _rightArmObject;
    [HideInInspector]
    public SkeletonAnimation _rightArmSkeleton;

    void OnEnable ()
    {
        KeyboardInput.OnAButton += AnimateRun;
        KeyboardInput.OnDButton += AnimateRun;
        KeyboardInput.OnNoMovement += AnimateIdle;
        KeyboardInput.OnSpaceButton += AnimateJump;
        _bodySkeleton = _bodyObject.GetComponent<SkeletonAnimation>();
        _headSkeleton = _headObject.GetComponent<SkeletonAnimation>();
        _leftArmSkeleton = _leftArmObject.GetComponent<SkeletonAnimation>();
        _rightArmSkeleton = _rightArmObject.GetComponent<SkeletonAnimation>();
    }

    private void AnimateRun()
    {
        _bodySkeleton.loop = true;
        _bodySkeleton.AnimationName = "Run";
    }

    private void AnimateIdle()
    {
        if (GetComponent<PlayerMovement>().isGrounded == true)
        {
            _bodySkeleton.loop = true;
            _bodySkeleton.AnimationName = "Idle";
        }
    }

    private void AnimateJump()
    {
        if (GetComponent<PlayerMovement>().isGrounded == true)
        {
            StartCoroutine(JumpAnimation());
        }
    }

    private IEnumerator JumpAnimation()
    {
        _bodySkeleton.AnimationName = "Jump_windup";
        yield return new WaitForSeconds(0.05f);
        _bodySkeleton.loop = true;
        _bodySkeleton.AnimationName = "Jump_float";
        while(GetComponent<PlayerMovement>().isGrounded == false)
        {
            yield return new WaitForEndOfFrame();
        }
        _bodySkeleton.AnimationName = "Jump_Land";
    }

	void OnDisable ()
    {
        KeyboardInput.OnAButton -= AnimateRun;
        KeyboardInput.OnDButton -= AnimateRun;
        KeyboardInput.OnNoMovement -= AnimateIdle;
        KeyboardInput.OnSpaceButton -= AnimateJump;
    }
}
