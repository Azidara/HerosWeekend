using System.IO;
using UnityEngine;
using UnityEditor;

/*
namespace HWeekend.Editor{
    public class MyScriptableObjects : MonoBehaviour
    {
        public static string AbilitiesPath = Path.Combine("Assets","Resources","Abilities");
        
        [MenuItem("Assets/Create/HWeekend/Abilities/ProjectileAbility")]
        public static void CreateProjectileAbility(){
            Directory.CreateDirectory(AbilitiesPath);

            Abilities.Projectile_Ability asset = ScriptableObject.CreateInstance<Abilities.Projectile_Ability>();

            AssetDatabase.CreateAsset(asset, Path.Combine(AbilitiesPath, "NewProjectileAbilityTemplate.asset"));
            AssetDatabase.SaveAssets();

            EditorUtility.FocusProjectWindow();
            Selection.activeObject = asset;
        }
    }
}
*/
