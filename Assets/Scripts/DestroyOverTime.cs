using System.Collections;
using UnityEngine;

public class DestroyOverTime : MonoBehaviour
{
    [SerializeField]
    private float _maxLifetime;

    private void Start()
    {
        StartCoroutine(DestroyDelay());
    }

    private IEnumerator DestroyDelay()
    {
        yield return new WaitForSeconds(_maxLifetime);
        Destroy(gameObject);
    }
}
