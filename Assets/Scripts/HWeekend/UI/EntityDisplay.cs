using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace HWeekend.UI {
    public class EntityDisplay : MonoBehaviour
    {
        #region Config Variables
        public Color health_bar_color = Color.green;
        #endregion

        #region Reference Variables
        public Character character;
        public TMP_Text nameplate_text;
        public Image health_bar_image;
        #endregion

        void Awake() {
            // Initalize References
            character ??= this.GetComponentInParent<Character>();
            nameplate_text ??= this.transform.Find("NamePlate").GetComponent<TMP_Text>();
            health_bar_image ??= this.transform.Find("HealthBar/Health").GetComponent<Image>();

            // Subscribe to events
            character.OnCharacterNameChange += syncNamePlate;
            character.OnHealthChange += syncHealthBar;

            health_bar_image.color = health_bar_color;
        }

        void Start() {
            syncNamePlate();
            syncHealthBar();
        }

        void syncNamePlate(){
            nameplate_text.text = character.character_name;
        }

        void syncHealthBar(){
            health_bar_image.fillAmount = Mathf.Max(0, character.health/character.max_health);
        }
    }
}

