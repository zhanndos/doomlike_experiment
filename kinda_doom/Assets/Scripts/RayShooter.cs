using System.Collections;
using UnityEngine;

public class RayShooter : MonoBehaviour
{
    private Camera _camera;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _camera = GetComponent<Camera>();

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 point = new Vector3(_camera.pixelWidth / 2, _camera.pixelHeight / 2, 0);
            Ray ray = _camera.ScreenPointToRay(point);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                GameObject hitObject = hit.transform.gameObject;
                ActiveTarget target = hitObject.GetComponent<ActiveTarget>();
                if (target != null) // если попали в врага
                {
                    target.ReactToHit();
                }
                else
                {
                    StartCoroutine(SphereIndicator(hit.point));
                }
            }
        }
        
    }

    private void OnGUI()
    {
        int size = 12;
        float posX = _camera.pixelWidth / 2 - size/4;
        float posY = _camera.pixelHeight / 2 - size/2;
        GUI.Label(new Rect(posX, posY, size, size), "*");

    }
    // возникновение сферы на месте попадания
    private IEnumerator SphereIndicator(Vector3 pos)
    {
        GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        sphere.transform.position = pos;
        sphere.GetComponent<Renderer>().material.color = new Color(1f, 0f, 0.6f);

        yield return new WaitForSeconds(1);

        Destroy(sphere);
    }
}
