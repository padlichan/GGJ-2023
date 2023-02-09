using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatePlanet : MonoBehaviour
{
    [SerializeField] private Camera cam;
    [SerializeField] private float camPositionZ;
    [SerializeField] private Transform target;
    public float distanceToTarget;

    [SerializeField] private Vector3 previousPosition;

    [SerializeField] private bool rotate;

    private void Start()
    {
        rotate = false;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            previousPosition = cam.ScreenToViewportPoint(Input.mousePosition);
        }
        else if (Input.GetMouseButton(1))
        {
            Vector3 newPosition = cam.ScreenToViewportPoint(Input.mousePosition);
            Vector3 direction = previousPosition - newPosition;

            float rotationAroundYAxis = -direction.x * 180; // camera moves horizontally
            float rotationAroundXAxis = direction.y * 180; // camera moves vertically

            cam.transform.position = target.position;

            cam.transform.Rotate(new Vector3(1, 0, 0), rotationAroundXAxis);
            cam.transform.Rotate(new Vector3(0, 1, 0), rotationAroundYAxis, Space.World);

            cam.transform.Translate(new Vector3(0, 0, -distanceToTarget));

            previousPosition = newPosition;
        }
        if(!Input.GetMouseButton(1))
        {
            cam.transform.position = target.position;
            cam.transform.Translate(new Vector3(0, 0, -distanceToTarget));
        }
    }
}
