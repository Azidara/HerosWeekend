using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using TMPro;

namespace HWeekend.UI{
    public class ActionBarButton : MonoBehaviour
    {
        #region Reference Variables
        [SerializeField] private InputActionAsset input_action_map;
        [SerializeField] public string input_action_name;
        [SerializeField] private Abilities.Ability _ability;
        [SerializeField] private Button ability_button;
        [SerializeField] private TMP_Text hotkey_text;
        [SerializeField] private TMP_Text item_count_text;
        [SerializeField] private TMP_Text cooldown_text;
        [SerializeField] private Image cooldown_image;
        #endregion

        #region Accessors
        public Abilities.Ability ability {get{return _ability;} set{_ability = value; OnAbilityChanged?.Invoke();}}
        #endregion
        
        #region Events
        public event VoidDelegate OnAbilityChanged;
        #endregion

        void Awake(){
            // Initalize References
            ability_button ??= this.GetComponent<Button>();
            hotkey_text ??= this.transform.Find("HotkeyText").GetComponent<TMP_Text>();
            item_count_text ??= this.transform.Find("ItemCountText").GetComponent<TMP_Text>();
            cooldown_text ??= this.transform.Find("CooldownText").GetComponent<TMP_Text>();
            cooldown_image ??= this.transform.Find("CooldownOverlay").GetComponent<Image>();
            
            this.OnAbilityChanged += syncAll;
        }

        public void syncAll(){
            syncIcon();
            syncHotkey();
            syncItemCount();
            syncCooldown();
        }

        public void syncIcon(){
            if (ability.icon != null){
                ability_button.GetComponent<Image>().overrideSprite = ability.icon;
            }
            else {
                // Default is EmptyIcon
                ability_button.GetComponent<Image>().overrideSprite = Resources.Load<Sprite>(Path.Combine(ResourcesIndex.ability_sprites_path, "EmptyIcon"));
            }
        }

        public void syncHotkey(){
            string hotkey = input_action_map.FindAction(input_action_name).bindings[0].ToDisplayString();
            if (hotkey != null){
                hotkey_text.gameObject.SetActive(true);
                hotkey_text.text = hotkey;
            }
            else {
                hotkey_text.gameObject.SetActive(false);
            }
            
        }

        public void syncItemCount(){
            if (ability.isConsumable){
                item_count_text.gameObject.SetActive(true);
                item_count_text.text = ability.uses_left.ToString();
            }
            else {
                item_count_text.gameObject.SetActive(false);
            }
        }

        public void syncCooldown(){
            if (ability.cooldown_timer > 0){
                cooldown_image.gameObject.SetActive(true);
                cooldown_text.gameObject.SetActive(true);
                cooldown_text.text = $"{formatCooldownText(ability.cooldown_timer)}";
                cooldown_image.fillAmount = ability.cooldown_timer/ability.cooldown;
            }
            else {
                cooldown_text.gameObject.SetActive(false);
                cooldown_image.gameObject.SetActive(false);
            } 
        }

        private string formatCooldownText(float t){
            string output = $"{t.ToString("0.0")}s";
            if (t > 10){
                output = $"{Mathf.FloorToInt(t)}s";
            }
            if (t > 120){
                output = $"{Mathf.FloorToInt(t/60)}mins";
            }
            return output;
        }

        // Update is called once per frame
        void Update()
        {
            // Update Cooldown
            if(ability.cooldown_timer > -0.5){
                syncCooldown();
            }
        }
        public void useAbility(){
            ability.activate();
        }
    }
}
