using UnityEngine;

public class PlayerCharacter : MonoBehaviour, IDamageable
{
    private int _health;
    private void Start()
    {
        _health = 5;
    }
    public void TakeDamage(int damage)
    {
        _health -= damage;
        Debug.Log("здоровье игрока: " + _health);
    }
}
