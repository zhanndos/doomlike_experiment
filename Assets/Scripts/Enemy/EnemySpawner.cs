using UnityEngine;

public class EnemySpawner : MonoBehaviour, IEnemySpawner
{
    [SerializeField] private GameObject _enemyPrefab;
    [SerializeField] private Vector3 _spawnPos = new Vector3(0, 1, 0);

    public GameObject Spawn()
    {
        GameObject enemy = Instantiate(_enemyPrefab);
        enemy.transform.position = _spawnPos;
        enemy.transform.Rotate(0, Random.Range(0, 360), 0);
        return enemy;
    }
}
