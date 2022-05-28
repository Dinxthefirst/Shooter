using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerController))]
[RequireComponent(typeof(WeaponController))]
public class Player : MonoBehaviour
{
    public float moveSpeed = 5f;

    Camera viewCamera;
    float cameraHeight = 10f;
    PlayerController controller;
    WeaponController weaponController;

    Vector3 moveInput;

    void Start() 
    {
        controller = GetComponent<PlayerController>();
        weaponController = GetComponent<WeaponController>();
        viewCamera = Camera.main;
    }
    
    void Update()
    {
        // moveInput = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        moveInput45Degrees();

        CameraFollow();

        Vector3 moveVelocity = moveInput.normalized * moveSpeed;

        controller.Move(moveVelocity);

        Ray ray = viewCamera.ScreenPointToRay(Input.mousePosition);
        Plane groundPlane = new Plane(Vector3.up, Vector3.zero);
        float rayDistance;

        if (groundPlane.Raycast(ray, out rayDistance))
        {
            Vector3 point = ray.GetPoint(rayDistance);
            Debug.DrawLine(ray.origin, point, Color.red);
            controller.LookAt(point);
        }
        if (Input.GetMouseButton(0))
        {
            weaponController.Shoot();
        }
    }

    void CameraFollow()
    {
        float x = Mathf.Cos(Mathf.Deg2Rad * 45f) * cameraHeight;
        float z = Mathf.Sin(Mathf.Deg2Rad * 45f) * cameraHeight;
        
        Vector3 newPosition = new Vector3(-x, cameraHeight, -z);

        viewCamera.transform.position = transform.position + newPosition;
    }

    void moveInput45Degrees()
    {
        if (Input.GetKey(KeyCode.W))
        {
            moveInput.x = 1f;
            moveInput.z = 1f;
        }
        if (Input.GetKey(KeyCode.S))
        {
            moveInput.x = -1f;
            moveInput.z = -1f;
        }
        if (Input.GetKey(KeyCode.A))
        {
            moveInput.x = -1f;
            moveInput.z = 1f;
        }
        if (Input.GetKey(KeyCode.D))
        {
            moveInput.x = 1f;
            moveInput.z = -1f;
        }
        if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.A))
        {
            moveInput.x = 0;
            moveInput.z = 1f;
        }
        if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.D))
        {
            moveInput.x = 1f;
            moveInput.z = 0;
        }
        if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.A))
        {
            moveInput.x = -1f;
            moveInput.z = 0;
        }
        if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.D))
        {
            moveInput.x = 0;
            moveInput.z = -1f;
        }
        if (!Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
        {
            moveInput.x = 0;
            moveInput.z = 0;
        }
    }
}
