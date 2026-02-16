using UnityEngine;

[RequireComponent(typeof(CharacterController))] // если компонента нет на объекте, то скрипт работать не будет

public class KeyboardInput : MonoBehaviour
{
    public float speed = 10.0f;

    private CharacterController _characterController;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        float deltaX = Input.GetAxis("Horizontal");
        float deltaZ = Input.GetAxis("Vertical");
        Vector3 movement = transform.right * deltaX + transform.forward * deltaZ;
        movement = Vector3.ClampMagnitude(movement, 1.0f); // чтобы по диагонали скорость не отличалась

        _characterController.Move(movement * speed * Time.deltaTime);

    }
    
}
