using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class UserInputHandler : MonoBehaviour
{
    public HWeekend.Client_State client;
    public InputAction playerControls;

    private void OnEnable()
    {
        playerControls.Enable();
    }

    private void OnDisable(){
        playerControls.Disable();
    }

    void OnMove(InputValue value) {
        client.character.move(value.Get<Vector2>());
    }

    void OnAttackOne(){
        Debug.Log("Primary Attack");
        client.character.primary_attack();
    }

    void OnAttackTwo(){
        Debug.Log("Secondary Attack");
        client.character.secondary_attack();
    }

    void OnRespawn(){
        client.character.respawn();
    }

    void OnDebugKey() {
        Debug.Log("Debug key was triggered");
    }
}
