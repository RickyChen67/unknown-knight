using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] protected PlayerInput inputReader;

    protected virtual void Awake()
    {
        if (inputReader == null)
        {
            Debug.LogError($"PlayerController \"{name}\"'s PlayerInput reference is null.");
            return;
        }
    }
}
