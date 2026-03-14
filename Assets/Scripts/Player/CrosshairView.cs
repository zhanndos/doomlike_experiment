using UnityEngine;

public class CrosshairView : MonoBehaviour
{
    [SerializeField] private Texture _crosshair;
    private Camera _camera;

    void Start()
    {
        _camera = GetComponent<Camera>();
    }

    private void OnGUI()
    {
        int size = 36;
        float posX = _camera.pixelWidth / 2 - size / 4;
        float posY = _camera.pixelHeight / 2 - size / 2;
        GUI.Label(new Rect(posX, posY, size, size), _crosshair);
    }

}
