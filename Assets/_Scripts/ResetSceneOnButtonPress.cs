using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class ResetSceneOnButtonPress : MonoBehaviour
{

    public InputActionProperty OnUseStartAction;

    // Start is called before the first frame update
    void Start()
    {
        OnUseStartAction.action.performed += OnUseStart;
    }

    private void OnUseStart(InputAction.CallbackContext obj)
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
