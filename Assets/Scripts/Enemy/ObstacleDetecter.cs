using UnityEngine;

public class ObstacleDetecter : MonoBehaviour
{
    // дистанция, на которой мы будем обнаруживать препятствия
    public float obstacleRange = 5.0f;

    private void Update()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        if (Physics.SphereCast(ray, 0.75f, out RaycastHit hit))
        {
            if (hit.distance < obstacleRange && !hit.transform.GetComponent<PlayerCharacter>())
            {
                float angle = Random.Range(-110f, 110f);
                transform.Rotate(0, angle, 0);
            }
        }
    }
}
