using UnityEngine;

public class WanderingAI : MonoBehaviour
{
    public float speed = 3.0f;
    public float obstacle_Range = 5.0f; // дистанция, на которой мы будем обнаруживать препятствия

    private bool _alive; // жив ли враг

    [SerializeField] private GameObject _fireballPrefab; // снаряд врага
    private GameObject _fireball;

    private void Start()
    {
        _alive = true;
    }
    // Update is called once per frame
    void Update()
    {
        if (_alive)
        {
            transform.Translate(0, 0, speed * Time.deltaTime); // вперед
        }
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;
        if (Physics.SphereCast(ray, 0.75f, out hit))
        {
            if (hit.transform.gameObject.GetComponent<PlayerCharacter>()) // если задели игрока то появляетя огенный шар
            {
                if (_fireball == null)
                {
                    _fireball = Instantiate(_fireballPrefab) as GameObject;
                    _fireball.transform.position = transform.TransformPoint(Vector3.forward * 1.5f);
                    _fireball.transform.rotation = transform.rotation;
                }
            }
            else if (hit.distance < obstacle_Range)
            {
                float angle = Random.Range(-110f, 110f);
                transform.Rotate(0, angle, 0);
            }
        }
    }
    public void SetAlive(bool alive) // из других скриптов имеем доступ к параметру
    {
        _alive = alive;
    }
}
