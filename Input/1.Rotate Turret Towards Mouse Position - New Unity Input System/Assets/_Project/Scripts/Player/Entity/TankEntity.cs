using UnityEngine;
using UnityEngine.InputSystem;

public class TankEntity : MonoBehaviour
{
    #region VARIABLES

    [Header("Behaviours")]
    public MovementBehaviour Movement;
    public TurretBehaviour Turret;

    [Header("Input Actions")]
    public InputActionReference MovementAction;
    public InputActionReference TurretRotationAction;
    private PlayerControls _playerControls;

    #endregion

    #region UNITY METHODS

    private void Awake()
    {
        _playerControls = new PlayerControls();
    }

    private void OnEnable()
    {
        _playerControls.Enable();
        MovementAction.action.Enable();
        TurretRotationAction.action.Enable();
    }

    private void OnDisable()
    {
        _playerControls.Disable();
        MovementAction.action.Disable();
        TurretRotationAction.action.Disable();
    }

    private void Update()
    {
        Movement.Move(MovementAction.action.ReadValue<Vector2>());
        Turret.RotateByMousePosition(TurretRotationAction.action.ReadValue<Vector2>());
    }

    #endregion
}