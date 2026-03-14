using UnityEngine;
using System.Collections;

public class EnemyMover : MonoBehaviour, IEnemy, IKillable
{
    public const float baseSpeed = 3.0f;
    public float speed = 3.0f;
    private bool _alive = true;

    private void Update()
    {
        if (_alive)
        {
            transform.Translate(0, 0, speed * Time.deltaTime); 
        }
    }

    public void SetAlive(bool alive) => _alive = alive;
    public void Die()
    {
        SetAlive(false);
        StartCoroutine(DieCor());
    }

    // managing events
    private void OnEnable()
    {
        Messenger<float>.AddListener(GameEvent.SPEED_CHANGED, OnSpeedChanged);
    }

    private void OnDisable()
    {
        Messenger<float>.RemoveListener(GameEvent.SPEED_CHANGED, OnSpeedChanged);
    }
    private void OnSpeedChanged(float value) => speed = value * baseSpeed;

    private IEnumerator DieCor()
    {
        this.transform.Rotate(-75f, 0, 0);
        yield return new WaitForSeconds(1f);

        Destroy(this.gameObject);
    }
}
