using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class JoystickMovement : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    private Vector2 joystickDirection;
    private Vector2 originalPositionOfJoystick;
    public float radius;

    private float distanceFromOriginToFinger;

    public Vector2 getJoystickDirection()
    {
        if (this.joystickDirection == null) return Vector2.zero;
        return this.joystickDirection;
    }

    public float getDistanceFromFingerToJoystickOrigin()
    {
        return distanceFromOriginToFinger;
    }
    void Start()
    {
        originalPositionOfJoystick = this.transform.position;
        joystickDirection = Vector2.zero;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        // print("pointer pressed");
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector2 fingerPosition = eventData.position;
        // get distance from finger position to origin joystick position
        distanceFromOriginToFinger = Vector2.Distance(originalPositionOfJoystick, fingerPosition);
        // get the direction the joystick should be in
        joystickDirection = fingerPosition - originalPositionOfJoystick;
        // limit the vector to not exceed the radius
        joystickDirection = Vector2.ClampMagnitude(joystickDirection, radius);
        // print("finger position");
        // print(fingerPosition);
        // print("vector");
        // print(vectorFromJoystickOriginToFinger);
        // print("new joystick position");
        // print(newJoystickPosition);

        Vector2 newJoystickPosition = originalPositionOfJoystick + joystickDirection;
        this.transform.position = newJoystickPosition;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        joystickDirection = Vector2.zero;
        distanceFromOriginToFinger = 0;
        this.transform.position = originalPositionOfJoystick;
        // print("pointer is up");
    }
}
