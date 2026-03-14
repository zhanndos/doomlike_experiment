using UnityEngine;

[RequireComponent(typeof(CharacterController))] // если компонента нет на объекте, то скрипт работать не будет

public class KeyboardInput : MonoBehaviour
{
    public const float baseSpeed = 10.0f;
    public float speed = 10.0f;

    private CharacterController _characterController;

    void Start()
    {
        _characterController = GetComponent<CharacterController>();
    }


    void Update()
    {
        float deltaX = Input.GetAxis("Horizontal");
        float deltaZ = Input.GetAxis("Vertical");
        Vector3 movement = transform.right * deltaX + transform.forward * deltaZ;
        movement = Vector3.ClampMagnitude(movement, 1.0f); // чтобы по диагонали скорость не отличалась

        _characterController.Move(movement * speed * Time.deltaTime);

    }

    void OnEnable()
    {
        Messenger<float>.AddListener(GameEvent.SPEED_CHANGED, OnSpeedChanged);
    }
    void OnDisable()
    {
        Messenger<float>.RemoveListener(GameEvent.SPEED_CHANGED, OnSpeedChanged);
    }

    private void OnSpeedChanged(float value)
    {
        speed = baseSpeed * value;
    }

}
