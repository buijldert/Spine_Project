using Spine.Unity;
using UnityEngine;

public class RotateTowardsMouse : MonoBehaviour
{
    private SkeletonAnimation _skeletonAnimation;
    private Spine.Bone _rootBone;

    private float rotationZ;
    private float rotationOffset = 180f;

    private Vector3 _mousePos;
	// Use this for initialization
	void Start ()
    {
        _skeletonAnimation = GetComponent<SkeletonAnimation>();
        _rootBone = _skeletonAnimation.skeleton.FindBone("root");
	}
	
	// Update is called once per frame
	void Update ()
    {
        Vector3 diff = Camera.main.ScreenToWorldPoint(Input.mousePosition) - _rootBone.GetWorldPosition(transform);
        diff.Normalize();

        rotationZ = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;

        if (gameObject.GetComponent<SkeletonAnimation>().skeleton.FlipX != true)
        {
            _rootBone.rotation = rotationZ;
        }
        else
        {
            _rootBone.rotation = rotationOffset - rotationZ;
        }
        
    }
}
