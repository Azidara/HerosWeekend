using UnityEngine;

namespace HWeekend{
    public class Client_State : MonoBehaviour
    {
        protected static Client_State _instance;
        public static Client_State getInstance{ // Singleton Accessor
            // If instance is null create a new instance otherwise return the existing one.
            get {return _instance ?? (_instance = new GameObject("Client_State").AddComponent<Client_State>());}
        }

        public Player_Character c;

        void Awake() {
            // Need to double check this is working correct but pretty sure it is 
            if (_instance != null && _instance != this){
                Destroy(this);
            }
            else {
                _instance = this;
            }
        }

        
    }
}

