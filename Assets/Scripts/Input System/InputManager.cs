using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour, IManager
{
    private PlayerInputActions _inputActions = null;

    public Action<bool> OnMousePressed;

    void Awake() => _inputActions = new PlayerInputActions();

    void OnEnable()
    {
        _inputActions.Enable();
        _inputActions.Controls.LMB.performed += OnLeftMouseButtonPressed;
        _inputActions.Controls.RMB.performed += OnRightMouseButtonPressed;
    }

    void OnDisable()
    {
        _inputActions.Disable();
        _inputActions.Controls.LMB.performed -= OnLeftMouseButtonPressed;
        _inputActions.Controls.RMB.performed -= OnRightMouseButtonPressed;
    }

    private void OnLeftMouseButtonPressed(InputAction.CallbackContext value) => OnMousePressed?.Invoke(true);

    private void OnRightMouseButtonPressed(InputAction.CallbackContext value) => OnMousePressed?.Invoke(false);
}
