using MoreMountains.TopDownEngine;
using UnityEngine;

public class CharacterRelativeCameraMovement : CharacterMovement
{
    [SerializeField] private Transform _cameraTransform;

    protected override void Initialization()
    {
        base.Initialization();

        if (Camera.main != null)
        {
            _cameraTransform = Camera.main.transform;
        }
    }
    
    protected override void HandleMovement()
    {
        if (!AbilityAuthorized
            || _condition.CurrentState != CharacterStates.CharacterConditions.Normal)
        {
            return;
        }

        if (_cameraTransform == null)
        {
            base.HandleMovement();
            return;
        }

        Vector2 input = _inputManager.PrimaryMovement;

        // Camera directions
        Vector3 camForward = _cameraTransform.forward;
        Vector3 camRight = _cameraTransform.right;

        // Flatten (important)
        camForward.y = 0f;
        camRight.y = 0f;

        camForward.Normalize();
        camRight.Normalize();

        // Camera-relative direction
        Vector3 direction = camForward * input.y + camRight * input.x;

        // Assign movement vector (THIS is what TopDown Engine expects)
        _movementVector = direction.normalized * MovementSpeed;
    }
}
