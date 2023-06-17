using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTarget : MonoBehaviour
{
    public float height = -10;
    public GameObject target = null;

    void Start(){
        if (target == null){
            target = HWeekend.Client_State.getInstance.character.gameObject;
        }
    }
    // Update is called once per frame
    void Update()
    {
        this.transform.position = target.transform.position + new Vector3(0,0,height);
    }
}
