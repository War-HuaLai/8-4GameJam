using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ScrollWheel : MonoBehaviour
{
    public float Speed = 5f;
    private Control control;

    Vector2 MouseDir;
    private void Awake()
    {
        control= new Control();
        control.Player.WindDir.started += Dir;
        control.Player.WindDir.performed += Dir;
        control.Player.WindDir.canceled += Dir;

    }
    void Start()
    {
        
    }

    
    void Update()
    {
        WindingDir();
    }
    void Dir(InputAction.CallbackContext context)
    {
        MouseDir = context.ReadValue<Vector2>();
       
    }
    void WindingDir()
    {
        
            
        
    }
    private void OnEnable()
    {
        
    }
    private void OnDisable()
    {

    }
}
