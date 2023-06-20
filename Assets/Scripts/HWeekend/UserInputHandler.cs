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

    void Awake(){
        client = HWeekend.Client_State.getInstance;
    }

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

    void OnActionButton1(){
        client.character.action1.activate();
    }

    void OnActionButton2(){
        client.character.action2.activate();
    }

    void OnActionButton3(){
        client.character.action3.activate();
    }

    void OnActionButton4(){
        client.character.action4.activate();
    }

    void OnActionButton5(){
        client.character.action5.activate();
    }

    void OnRespawn(){
        client.character.respawn();
    }

    void OnDebugKey() {
        Debug.Log("Debug key was triggered");
    }

    void Update(){
        client.character.aim_input = GetAimDirection();

        if (attack1){
            client.character.primary_attack.activate();
        }
        if (attack2){
            client.character.secondary_attack.activate();
        }
    }

    private Vector2 GetAimDirection(){
        Vector3 client_position = client.character.transform.Find("attack_pivot").transform.position;
        Vector3 cursor_position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        return new Vector2(cursor_position.x-client_position.x, cursor_position.y-client_position.y);
    }   
}
