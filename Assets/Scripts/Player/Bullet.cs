using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;

public class Bullet : MonoBehaviour
{
    public int moveSpeed = 2;
    float interval = 2;
    float elapsed = 0;
    private void Start()
    {
        
    }
    private void Update()
    {
        Move();
        elapsed += Time.deltaTime;
        if (elapsed > interval)
        {
            gameObject.SetActive(false);
        }
    }
    private void OnEnable()
    {
        elapsed = 0;
    }
    private void Move()
    {
        transform.position += Time.deltaTime * moveSpeed * Vector3.right;
    }
}
