using UnityEngine;
using UnityEngine.InputSystem;

public class CameraManager : MonoBehaviour
{
    [SerializeField] private GameObject camera_1st;
    [SerializeField] private GameObject camera_3rd;
    [SerializeField] private PlayerInput playerInput;
    private InputAction switchAction;

    private void Awake()
    {
        if (playerInput == null) playerInput = GetComponent<PlayerInput>();
        switchAction = playerInput.actions["SwitchCamera"];
    }

    private void Start()
    {
        camera_1st.SetActive(false);
        camera_3rd.SetActive(true);
    }

    private void OnEnable()  => switchAction.performed += OnSwitchCamera;
    private void OnDisable() => switchAction.performed -= OnSwitchCamera;

    private void OnSwitchCamera(InputAction.CallbackContext context)
    {
        bool firstActive = camera_1st.activeSelf;
        camera_1st.SetActive(!firstActive);
        camera_3rd.SetActive(firstActive);
    }
}
