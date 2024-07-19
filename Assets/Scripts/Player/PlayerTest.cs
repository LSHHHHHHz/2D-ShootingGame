using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerTest : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5;
    [SerializeField] float rotationSpeed = 30;

    float horizontal = 0;
    float vertical = 0;
    [SerializeField]float upRotation = 15;
    [SerializeField]float downRotation = -15;

    void Update()
    {
        Move();
        Rotation();
        FireAttack();
    }
    void Move()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
        Vector3 dir = new Vector3(horizontal, vertical, 0).normalized;

        transform.position += dir * moveSpeed * Time.deltaTime;
    }
    void Rotation()
    {
        Quaternion targetRotation;
        if (vertical < -0.01)
        {
            targetRotation = Quaternion.Euler(new Vector3(upRotation, 0, 0));
        }
        else if (vertical > 0.01)
        {
            targetRotation = Quaternion.Euler(new Vector3(downRotation, 0, 0));
        }
        else
        {
            targetRotation = Quaternion.Euler(new Vector3(0, 0, 0));
        }
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }
    void FireAttack()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            Debug.Log("АјАн!!");
        }
    }
}
