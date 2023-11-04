using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerBehavior : MonoBehaviour
{
    private PlayerInputs playerInputs;
    private Vector2 moveDirection;

    [SerializeField] private int speed;

    private void Awake()
    {
        playerInputs = new PlayerInputs();

        playerInputs.Player.Move.started += MoveHandler;
        playerInputs.Player.Move.performed += MoveHandler;
        playerInputs.Player.Move.canceled += MoveHandler;
    }

    private void Update()
    {
        MovePlayer();
    }

    void MoveHandler(InputAction.CallbackContext value)
    {
        moveDirection = value.ReadValue<Vector2>();
    }

    void MovePlayer()
    {
        transform.Translate(new Vector2(moveDirection.x, moveDirection.y).normalized * speed * Time.deltaTime);
    }








    private void OnEnable()
    {
        playerInputs.Enable();   
    }

    private void OnDisable()
    {
        playerInputs.Disable();
    }
}
