using UnityEngine;
using UnityEngine.InputSystem;
public class JugglerController : MonoBehaviour
{
    // Stores the input action sheet used for input
    [SerializeField] private InputActionAsset InputActions;
    [SerializeField] private LayerMask interactableLayer;

    // COMPONENTS
    [SerializeField] private Camera cam;

    // ACTIONS
    private InputAction juggleAction;

    private void Awake()
    {
        // Assign our input action variables to their respective input actions
        juggleAction = InputActions.FindAction("Juggle");
    }

    private void OnEnable()
    {
        juggleAction.performed += OnJuggle;
        InputActions?.FindActionMap("Player")?.Enable();  
    }    
    private void OnDisable()
    {
        juggleAction.performed -= OnJuggle;
        InputActions?.FindActionMap("Player").Disable();
    }
     
    private void OnJuggle(InputAction.CallbackContext context)
    {
        // Read the current pos of the mouse
        Vector2 mousePosition = Mouse.current.position.ReadValue();
        // Shoot a ray at the mouse pos
        Ray ray = cam.ScreenPointToRay(mousePosition);

        if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity, interactableLayer))
        {   
            // Try to get the juggleable component off the object
            Juggleable juggleable = hit.collider.GetComponent<Juggleable>();
            // juggle the object if it is juggleable
            if (juggleable != null) juggleable.Juggle(hit.point);
        }
    }
}
