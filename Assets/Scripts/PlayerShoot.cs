using UnityEngine;
using Spine.Unity;

public class PlayerShoot : MonoBehaviour
{
    public Spine.Bone _pistolBone;

    [SerializeField]
    private GameObject _bullet;

    [SerializeField]
    private float _bulletSpeed;

	private void OnEnable ()
    {
        KeyboardInput.OnLeftMouseButton += Shoot;
        _pistolBone = GetComponent<PlayAnimations>()._rightArmSkeleton.skeleton.FindBone("Pistol");
    }
	
	private void Shoot()
    {
        GameObject bulletClone = Instantiate(_bullet, _pistolBone.GetWorldPosition(GetComponent<PlayAnimations>()._rightArmSkeleton.transform), Quaternion.identity);

        Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - bulletClone.transform.position;
        direction.Normalize();

        bulletClone.GetComponent<Rigidbody2D>().velocity = direction * _bulletSpeed;
        Quaternion bulletRotation = Quaternion.Euler(0, 0, Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg + 90f);
        bulletClone.transform.rotation = bulletRotation;
    }

    private void OnDisable()
    {
        KeyboardInput.OnLeftMouseButton -= Shoot;
    }
}
