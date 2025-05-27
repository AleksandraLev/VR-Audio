using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Oculus.Voice;
using UnityEngine.InputSystem;

public class VoiceScript : MonoBehaviour
{
    public AppVoiceExperience voiceExperience;
    public InputActionReference inputActionReference;
    
    // Делегат, чтобы потом можно было отписаться от события voiceExperience
    private System.Action<InputAction.CallbackContext> _onPerformed;
    
    void OnEnable()
    {
        _onPerformed = context => voiceExperience.Activate();
        inputActionReference.action.performed += _onPerformed;
        inputActionReference.action.Enable();
    }

    void OnDisable()
    {
        if (_onPerformed != null)
        {
            inputActionReference.action.performed -= _onPerformed;
        }
        inputActionReference.action.Disable();
    }
}