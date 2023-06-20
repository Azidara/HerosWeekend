using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HWeekend.UI{
    public class ActionBar : MonoBehaviour
    {
        #region Reference Variables
        public Character character;
        public ActionBarButton action1;
        public ActionBarButton action2;
        public ActionBarButton action3;
        public ActionBarButton action4;
        public ActionBarButton action5;
        #endregion

        void Awake(){
            // Initalize References
            character ??= Client_State.getInstance.character;
            action1 ??= this.transform.Find("GridContent/ActionBarButton1").GetComponent<ActionBarButton>();
            action2 ??= this.transform.Find("GridContent/ActionBarButton2").GetComponent<ActionBarButton>();
            action3 ??= this.transform.Find("GridContent/ActionBarButton3").GetComponent<ActionBarButton>();
            action4 ??= this.transform.Find("GridContent/ActionBarButton4").GetComponent<ActionBarButton>();
            action5 ??= this.transform.Find("GridContent/ActionBarButton5").GetComponent<ActionBarButton>();
        
            action1.input_action_name = "ActionButton1";
            action2.input_action_name = "ActionButton2";
            action3.input_action_name = "ActionButton3";
            action4.input_action_name = "ActionButton4";
            action5.input_action_name = "ActionButton5";

            // Subscribe to events
            Client_State.getInstance.OnCharacterChange += syncActionBar;
        }

        void Start(){
            syncActionBar();
        }

        void syncActionBar(){
            character = Client_State.getInstance.character;
            action1.ability = character.action1;
            action2.ability = character.action2;
            action3.ability = character.action3;
            action4.ability = character.action4;
            action5.ability = character.action5;
        }
    }
}

