using UnityEngine;
using UnityEngine.InputSystem;

public class JugglerController : MonoBehaviour
{
    // INPUT
    [SerializeField] private InputActionAsset inputActions;

    // COMPONENTS
    [SerializeField] private Camera cam;

    // SETTINGS
    [SerializeField] private LayerMask interactableLayer;
    [SerializeField, Min(0f)] private float clickRadius = 0.35f;

    // ACTIONS
    private InputAction juggleAction;

    private void Awake()
    {
        juggleAction = inputActions.FindAction("Juggle");
    }

    private void OnEnable()
    {
        juggleAction.performed += OnJuggle;
        inputActions.FindActionMap("Player")?.Enable();
    }

    private void OnDisable()
    {
        juggleAction.performed -= OnJuggle;
        inputActions.FindActionMap("Player")?.Disable();
    }

    private void OnJuggle(InputAction.CallbackContext context)
    {
        // Read the current mouse position
        Vector2 mousePosition = Mouse.current.position.ReadValue();

        // Create a ray from the mouse cursor
        Ray ray = cam.ScreenPointToRay(mousePosition);

        // Cast a thick ray for more forgiving clicks
        if (Physics.SphereCast(
                ray,
                clickRadius,
                out RaycastHit hit,
                Mathf.Infinity,
                interactableLayer))
        {
            if (hit.collider.TryGetComponent(out Juggleable juggleable))
            {
                juggleable.Juggle(hit.point);
            }
        }
    }
}