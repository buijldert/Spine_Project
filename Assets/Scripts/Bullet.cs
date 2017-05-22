using UnityEngine;
using EZCameraShake;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    private GameObject _explosion;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Target" || collision.gameObject.tag == "Ground")
        {
            CameraShaker.Instance.Shake(CameraShakePresets.Explosion);
            Instantiate(_explosion, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
