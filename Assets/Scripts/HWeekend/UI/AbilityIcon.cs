using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using TMPro;

public class AbilityIcon : MonoBehaviour
{
    public HWeekend.Abilities.Ability ability;
    public string icon_action_name = "ActionButtonX";

    [SerializeField]
    private InputActionAsset input_map;

    [SerializeField]
    private TMP_Text hotkey;
    [SerializeField]
    private TMP_Text item_count;

    [SerializeField]
    private Image cooldown_image;
    [SerializeField]
    private TMP_Text cooldown_text;

    void Awake(){
        if (hotkey == null){hotkey = this.transform.Find("Hotkey Text").GetComponent<TMP_Text>();}
        if (item_count == null){item_count = this.transform.Find("Item Count Text").GetComponent<TMP_Text>();}
        if (cooldown_image == null){cooldown_image = this.transform.Find("Cooldown").GetComponent<Image>();}
        if (cooldown_text == null){cooldown_text = this.transform.Find("Cooldown Text").GetComponent<TMP_Text>();}
    }

    void syncHotkey(){
        hotkey.text = input_map.FindAction(icon_action_name).bindings[0].ToDisplayString();
    }

    void syncItemCount(){
        if (ability.isConsumable){
            item_count.gameObject.SetActive(true);
            item_count.text = ability.uses_left.ToString();
        }
        else {
            item_count.gameObject.SetActive(false);
        }
    }

    void syncCooldown(){
        if (ability.cooldown_timer > 0){
            cooldown_text.gameObject.SetActive(true);
            cooldown_image.gameObject.SetActive(true);
            cooldown_text.text = $"{Mathf.RoundToInt(ability.cooldown_timer).ToString()}s";
            cooldown_image.fillAmount = ability.cooldown_timer/ability.cooldown;
        }
        else {
            cooldown_text.gameObject.SetActive(false);
            cooldown_image.gameObject.SetActive(false);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        // Update Cooldown
        if(ability.cooldown_timer > 0){

        }
    }
    public void useAbility(){
        
    }
}
