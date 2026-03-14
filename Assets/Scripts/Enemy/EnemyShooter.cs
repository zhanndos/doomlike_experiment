using UnityEngine;

public class EnemyShooter : MonoBehaviour
{
    [SerializeField] private GameObject _fireballPrefab;
    private GameObject _fireball;

    private void Update()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        if (Physics.SphereCast(ray, 0.75f, out RaycastHit hit))
        {
            if (hit.transform.gameObject.GetComponent<PlayerCharacter>())
            {
                _fireball = Instantiate(_fireballPrefab) as GameObject;
                _fireball.transform.position = transform.TransformPoint(Vector3.forward * 1.5f);
                _fireball.transform.rotation = transform.rotation;
            }
        }
    }

}
