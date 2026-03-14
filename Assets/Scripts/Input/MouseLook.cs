using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public enum RotationAxes
    {
        mouseXandY = 0,
        mouseX = 1,
        mouseY = 2,
    }

    public RotationAxes axes = RotationAxes.mouseXandY;
    public float sensativityHor = 100.0f; // скорость поворота по гор
    public float sensativityVer = 50.0f; // скорость поворота по верт
    public float maximumVert = 45.0f;   // макс.угол поврота по верт(по Y)
    public float minimumVert = -45.0f;  // мин угол поворота по гор(по X) 

    private float _xRotation = 0f; // 

    private void Start()
    {
        Rigidbody body = GetComponent<Rigidbody>();

        if (body != null)
        {
            body.freezeRotation = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (axes == RotationAxes.mouseX) // вращение по горизонтали
        {
            transform.Rotate(0, Input.GetAxis("Mouse X") * sensativityHor * Time.deltaTime, 0);
        }
        else if (axes == RotationAxes.mouseY) // вращение по вертикали
        {
            float mouseY = Input.GetAxis("Mouse Y") * sensativityVer * Time.deltaTime;
            _xRotation-= mouseY;
            _xRotation = Mathf.Clamp(_xRotation, minimumVert, maximumVert); // ограничили значение 

            transform.localRotation = Quaternion.Euler(_xRotation, 0, 0); // вращение камеры относительно игрока
        }
    }
}
