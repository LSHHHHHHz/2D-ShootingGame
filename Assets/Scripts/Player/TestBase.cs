using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;

public class TestBase : MonoBehaviour
{
    PlayerAction inputActions;
    private void Awake()
    {
        inputActions = new PlayerAction();
    }
    private void OnEnable()
    {
        inputActions.Test.Enable();
        inputActions.Test.Test1.performed += OnTest1;
        inputActions.Test.Test2.performed += OnTest2;
        inputActions.Test.Test3.performed += OnTest3;
        inputActions.Test.Test4.performed += OnTest4;
        inputActions.Test.Test5.performed += OnTest5;
        inputActions.Test.LClick.performed += OnTestLClick;
        inputActions.Test.RClick.performed += OnTestRClick;
        inputActions.Test.TestWASD.performed += OnTestWASD;
        inputActions.Test.Fire.performed += OnTestFire;
    }
    private void OnDisable()
    {
        inputActions.Test.Test1.performed += OnTest1;
        inputActions.Test.Test2.performed += OnTest2;
        inputActions.Test.Test3.performed += OnTest3;
        inputActions.Test.Test4.performed += OnTest4;
        inputActions.Test.Test5.performed += OnTest5;
        inputActions.Test.LClick.performed += OnTestLClick;
        inputActions.Test.RClick.performed += OnTestRClick;
        inputActions.Test.TestWASD.performed -= OnTestWASD;
        inputActions.Test.Fire.performed -= OnTestFire;
        inputActions.Test.Disable();
    }
    protected virtual void OnTest1(InputAction.CallbackContext context)
    {
        Debug.Log("Å×½ºÆ®1");
    }
    protected virtual void OnTest2(InputAction.CallbackContext context)
    {

    }
    protected virtual void OnTest3(InputAction.CallbackContext context)
    {

    }
    protected virtual void OnTest4(InputAction.CallbackContext context)
    {

    }
    protected virtual void OnTest5(InputAction.CallbackContext context)
    {

    }
    protected virtual void OnTestLClick(InputAction.CallbackContext context)
    {

    }
    protected virtual void OnTestRClick(InputAction.CallbackContext context)
    {

    }
    protected virtual void OnTestWASD(InputAction.CallbackContext context)
    {

    }
    protected virtual void OnTestFire(InputAction.CallbackContext context)
    {

    }
}
