using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;

public class Enemy : MonoBehaviour
{
    public int moveSpeed;
    float interval = 10;
    float elapsed = 0;
    private void Update()
    {
        transform.position += new Vector3(0.1f, 0, 0) * moveSpeed * Time.deltaTime;
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
}
