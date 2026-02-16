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
        PlayerCharacter player = other.GetComponent<PlayerCharacter>();
        if (player != null ) // значит попали по игроку
        {
            player.TakeDamage(damage);
        }
        Destroy(this.gameObject);
    }
}
