using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleMoveCamera : MonoBehaviour
{
    public float speed = 1.0f;
    public float jumpSpeed;
    public float gravity;
    public float speedRot = 0.1f;
    private Vector3 moveDirection = Vector3.zero;
    private CharacterController controller;
    public Transform piv_y_cam;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (controller.isGrounded)
        {
            moveDirection = piv_y_cam.TransformDirection(new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")));
            moveDirection = moveDirection * speed;
            if (Input.GetButton("Jump"))
            {
                moveDirection.y = jumpSpeed;
            }
        }
        Vector3 temp_Rot_Vector = piv_y_cam.TransformDirection(new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"))* 0.01f);
        if(temp_Rot_Vector.magnitude > 0.1)
        {
            transform.forward = temp_Rot_Vector.normalized;
        }
        moveDirection.y = moveDirection.y - (gravity * Time.deltaTime);
        controller.Move(moveDirection * Time.deltaTime);
    }
}
