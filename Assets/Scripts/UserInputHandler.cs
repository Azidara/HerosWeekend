using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class UserInputHandler : MonoBehaviour
{
    public HWeekend.Client_State client;
    public InputAction playerControls;

    public bool attack1;
    public bool attack2;

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
        attack1 = !attack1;
    }

    void OnAttackTwo(){
        attack2 = !attack2;
    }

    void OnRespawn(){
        client.character.respawn();
    }

    void OnDebugKey() {
        Debug.Log("Debug key was triggered");
    }

    void Update(){
        if (attack1){
            client.character.primary_attack();
        }
        if (attack2){
            client.character.secondary_attack();
        }
    }
}
