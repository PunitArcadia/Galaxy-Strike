using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerWeapon : MonoBehaviour
{
    [SerializeField] private ParticleSystem[] lasers;
    [SerializeField] private RectTransform crosshair;
    [SerializeField] private Transform trackingTarget;
    [SerializeField] private float targetDistance = 100f;
    bool isFiring = false;
    private void Start()
    {
        Cursor.visible = false;
    }
    private void OnFire(InputValue value)
    {
        isFiring = value.isPressed;
    }

    private void Update()
    {
        ProccessFire();
        if (Mouse.current != null)
        {
            Vector2 mousePos = Mouse.current.position.ReadValue();
            TrackTarget(mousePos);
            TrackMouse(mousePos);
            RotateToTarget();
        }
    }

    private void RotateToTarget()
    {
        foreach (ParticleSystem laser in lasers)
        {
            Vector3 dir = trackingTarget.position - transform.position;
            Quaternion lookRotation = Quaternion.LookRotation(dir); 
            laser.transform.rotation = lookRotation;
        }
    }

    private void TrackTarget(Vector2 mousePos)
    {
        Vector3 targetPosition = new Vector3(mousePos.x, mousePos.y, targetDistance);
        trackingTarget.position = Camera.main.ScreenToWorldPoint(targetPosition);
    }

    private void TrackMouse(Vector2 mousePos)
    {
        crosshair.position = mousePos;
    }

    private void ProccessFire()
    {
        foreach (ParticleSystem laser in lasers) 
        {
            var emissionModule = laser.emission;
            emissionModule.enabled = isFiring;
        }
    }
}
