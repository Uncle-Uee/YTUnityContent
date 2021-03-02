using UnityEngine;
using UnityEngine.InputSystem;

public class MovementBehaviour : MonoBehaviour
{
    #region VARIABLES

    [Header("Required Components")]
    public Rigidbody Rigidbody;

    [Header("Movement")]
    public float MovementSpeed = 10f;
    public float RotationSpeed = 5f;

    private Transform _cameraTransform;
    private Transform _transform;
    private Vector3 _target = Vector3.zero;
    private float _targetAngle = 0f;

    #endregion

    #region UNITY METHODS

    private void Awake()
    {
        _transform = transform;
        _cameraTransform = Camera.main.transform;
    }

    #endregion

    #region METHODS

    public void Move(Vector2 inputAxis)
    {
        _target.x = inputAxis.x;
        _target.z = inputAxis.y;
        _target = _cameraTransform.forward * inputAxis.y + _cameraTransform.right * inputAxis.x;
        _target.y = 0f;

        Rigidbody.velocity = _target * MovementSpeed;
        Rotate(inputAxis);
    }

    private void Rotate(Vector2 inputAxis)
    {
        if (inputAxis == Vector2.zero) return;
        _targetAngle = Mathf.Atan2(inputAxis.x, inputAxis.y) * Mathf.Rad2Deg;
        _transform.rotation = Quaternion.LerpUnclamped(_transform.rotation,
                                                       Quaternion.Euler(0f, _targetAngle, 0f),
                                                       Time.deltaTime * RotationSpeed);
    }

    #endregion
}
