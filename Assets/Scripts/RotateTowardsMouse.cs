using Spine.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateTowardsMouse : MonoBehaviour
{
    private SkeletonAnimation _skeletonAnimation;
    private Spine.Bone _rootBone;

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
        Vector3 diff = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        diff.Normalize();

        float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
        _rootBone.rotation = rot_z;//Quaternion.Euler(0f, 0f, rot_z - 90);
    }
}
