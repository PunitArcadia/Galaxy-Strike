using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    [SerializeField] private float controlSpeed = 10f;
    [SerializeField] private float xRange = 10f;
    [SerializeField] private float yRange = 10f;
    [SerializeField] private float rollingFactor = 10f;
    [SerializeField] private float pitchFactor = 10f;
    [SerializeField] private float rotationSpeed = 10f;
    Vector2 movement;

    private void Update()
    {
        ProcessTranslation();
        //if (allowRotation && movement != Vector2.zero)
        //{
        //    ProcessRotation();
        //}
    }

    private void ProcessTranslation()
    {
        float xOffset = movement.x * controlSpeed * Time.deltaTime;
        float xRaw = transform.localPosition.x + xOffset;
        float xFinal = Mathf.Clamp(xRaw, -xRange, xRange);
        float yOffset = movement.y * controlSpeed * Time.deltaTime;
        float yRaw = transform.localPosition.y + yOffset;
        float yFinal = Mathf.Clamp(yRaw, -yRange, yRange);
        Vector3 currentPos = transform.localPosition;
        transform.localPosition = new Vector3(xFinal, yFinal, currentPos.z);
    }

    private void ProcessRotation()
    {
        Quaternion targetRotation = Quaternion.Euler(-pitchFactor * movement.y, 0f, -rollingFactor * movement.x);
        transform.localRotation = Quaternion.Lerp(transform.localRotation, targetRotation, rotationSpeed * Time.deltaTime);
    }

    private void OnMove(InputValue value)
    {
        //Debug.Log(value.Get<Vector2>());
        movement = value.Get<Vector2>();
    }    
}
