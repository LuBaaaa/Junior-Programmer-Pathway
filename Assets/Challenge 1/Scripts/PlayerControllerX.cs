
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControllerX : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float rotationSpeed;
    [SerializeField] private InputAction verticalAction;
    private float verticalInput;

    // Start is called before the first frame update
    void Start()
    {
        verticalAction.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        // get the user's vertical input
        verticalInput = verticalAction.ReadValue<float>();

        // move the plane forward at a constant rate
        transform.Translate(Vector3.forward * (Time.deltaTime * speed));

        // tilt the plane up/down based on up/down arrow keys
        transform.Rotate(Vector3.right * (Time.deltaTime * rotationSpeed * verticalInput));
    }
}
