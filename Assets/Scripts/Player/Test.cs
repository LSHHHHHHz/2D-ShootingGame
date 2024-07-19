using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;

public class Test : MonoBehaviour
{
    PlayerAction inputActions;
    private void OnEnable()
    {
        Debug.Log("OnEnable");
        inputActions.Test.Enable();
    }
}
