using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public GameObject bulletPrefab;
    public GameObject flashPrefab;
    public float spawnPos = 1;
    public float moveSpeed = 0.01f;

    Vector3 inputDirection = Vector3.zero;

    PlayerAction inputActions;
    Animator anim;
    Coroutine fireCoroutine;

    public int fireInterval = 1000;

    private void Awake()
    {
        inputActions = new PlayerAction();
        anim = GetComponent<Animator>();

    }

    private void OnEnable()
    {
        inputActions.Enable();                         
        inputActions.Player.Fire.performed += OnFire;   
        inputActions.Player.Move.performed += OnMove;
        inputActions.Player.Move.canceled += OnMove;
    }

    private void OnDisable()
    {
        inputActions.Player.Move.canceled -= OnMove;
        inputActions.Player.Move.performed -= OnMove;
        inputActions.Player.Fire.performed -= OnFire;
        inputActions.Disable();
    }
    private void OnMove(InputAction.CallbackContext context)
    {
        Vector2 input = context.ReadValue<Vector2>();  
        inputDirection = (Vector3)input;
        anim.SetFloat("MoveDir", input.y);
    }

    private void OnFire(InputAction.CallbackContext _)
    {
        Debug.Log("발사");    // 발사라고 출력
        //PoolManager.instance.setPool(bulletPrefab);
        // Instantiate(bulletPrefab,new Vector3(transform.position.x* spawnPos, transform.position.y,transform.position.z),Quaternion.identity);
        if (fireCoroutine == null)
        {
            fireCoroutine = StartCoroutine(FireCoroutine());
        }
        else
        {
            StopCoroutine(fireCoroutine);
            fireCoroutine = null;
        }
    }
    IEnumerator FireCoroutine()
    {
        while(true)
        {
            Debug.Log("Fire!!!");
            GameObject bullet = PoolManager.instance.setPool(bulletPrefab);
            bullet.transform.position = new Vector3(transform.position.x * spawnPos, transform.position.y, transform.position.z);
            flashPrefab.SetActive(true);
            yield return new WaitForSeconds(0.1f);
            flashPrefab.SetActive(false);
            yield return new WaitForSeconds(0.1f);
        }
    }
    private void Update()
    {
        transform.position += (Time.deltaTime* moveSpeed * inputDirection);
    }
}