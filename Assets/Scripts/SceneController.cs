using UnityEngine;

public class SceneController : MonoBehaviour
{
    [SerializeField] private EnemySpawner _spawner;
    private GameObject _enemy;

    private void Update()
    {
        if (_enemy == null)
        {
            _enemy = _spawner.Spawn();
        }
    }
}
