using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class UserInputHandler : MonoBehaviour
{
    public HWeekend.Client_State client;
    public PlayerInput _inputManager;

    void OnMove(InputValue value) {
        client.c.move(value.Get<Vector2>());
    }

    void OnRespawn(){
        client.c.respawn();
    }

    void OnDebugKey() {
        Debug.Log("Debug key was triggered");
    }
}
