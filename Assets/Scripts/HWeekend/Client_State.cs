using System.IO;
using UnityEngine;

namespace HWeekend{
    public class Client_State : MonoBehaviour
    {
        #region Reference Variables
        protected static Client_State _instance;
        [SerializeField] private Player_Character? _character = null;
        #endregion

        #region Accessors
        public Player_Character character {get{return _character;} set{_character = value; OnCharacterChange?.Invoke();}}
        public static Client_State getInstance{ // Singleton Accessor
            // If instance is null create a new instance otherwise return the existing one.
            get {
                if (_instance == null){
                    // Find any existing object in scene
                    if(Object.FindObjectsOfType<Client_State>().Length > 0){
                        _instance = Object.FindObjectsOfType<Client_State>()[0];
                    }
                    // Create a new one if none exist
                    else {
                        _instance = new GameObject("Client_State").AddComponent<Client_State>();
                    }
                }
                return _instance;
            }
        }
        #endregion

        #region Events
        public VoidDelegate OnCharacterChange;
        #endregion

        void Awake() {
            // Need to double check this is working correct but pretty sure it is 
            if (_instance != null && _instance != this){
                Destroy(this);
            }
            else {
                _instance = this;
            }

            if (character == null){
                //Debug.Log(character.gameObject.name);
                GameObject charGO = Instantiate(Resources.Load<GameObject>(Path.Combine("Prefabs","Default_Character")));
                character = charGO.GetComponent<Player_Character>();
            }
        }
    }
}

