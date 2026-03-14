using System;
using UnityEngine;

public class FireBall : MonoBehaviour
{
    public float speed = 10.0f;
    public int damage = 1;

    private void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
    private void OnTriggerEnter(Collider other)
    {
        IDamageable damageable = other.GetComponent<IDamageable>();
        if (damageable != null )
        {
            damageable.TakeDamage(damage);
        }
        Destroy(this.gameObject);
    }

}
