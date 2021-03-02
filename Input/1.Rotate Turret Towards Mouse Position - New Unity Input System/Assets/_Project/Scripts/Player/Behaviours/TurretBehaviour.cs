using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretBehaviour : MonoBehaviour
{
    #region VARIABLES

    [Header("Turret")]
    public Transform Turret;

    [Header("LayerMask")]
    public LayerMask WhatIsGround;

    [Header("Options")]
    public bool AllowTurretRotation = false;

    private Camera _camera;
    private Vector3 _playerToMouse = Vector2.zero;
    private Vector3 _mousePosition = Vector3.zero;
    private Ray _ray;
    private RaycastHit _rayHit;
    private Quaternion _targetRotation;
    private float _targetAngle = 0f;

    #endregion

    #region UNITY METHODS

    private void Awake()
    {
        _camera = Camera.main;
    }

    #endregion

    #region METHODS

    public void RotateByMousePosition(Vector2 inputAxis)
    {
        TurnThePlayer(inputAxis);
    }

    private void TurnThePlayer(Vector2 inputAxis)
    {
        _ray = _camera.ScreenPointToRay(inputAxis);

        if (!Physics.Raycast(_ray, out _rayHit, WhatIsGround)) return;
        _playerToMouse = _rayHit.point - transform.position;
        _playerToMouse.y = 0f;
        _playerToMouse.Normalize();

        Turret.rotation = Quaternion.LookRotation(_playerToMouse);
    }

    #endregion
}