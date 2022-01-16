using UnityEditor;
using UnityEngine;

namespace Editor
{
    public class SettingsEditor : EditorWindow
    {
        public const string StrengthMultiplPref = "StrengthMultipl";
        public const string AgilityMultiplPref = "AgilityMultipl";
        public const string IntellectMultiplPref = "IntellectMultipl";

        public static int StrengthMultipl = 1;
        public static int AgilityMultipl = 1;
        public static int IntellectMultipl = 1;

        [MenuItem("Window/My Settings")]
        public static void ShowSettingsEditor()
        {
            SettingsEditor window = (SettingsEditor) GetWindow(typeof(SettingsEditor));
            window.Show();
        }

        private void OnEnable()
        {
            StrengthMultipl = PlayerPrefs.GetInt(StrengthMultiplPref, StrengthMultipl);
            AgilityMultipl = PlayerPrefs.GetInt(AgilityMultiplPref, AgilityMultipl);
            IntellectMultipl = PlayerPrefs.GetInt(IntellectMultiplPref, IntellectMultipl);
        }

        private void OnGUI()
        {
            ShowStrengthMultiplier();
            ShowAgilityMultiplier();
            ShowIntellectMultiplier();
        }

        private static void ShowStrengthMultiplier()
        {
            int strengthMultipl = EditorGUILayout.IntField("Strength Multiplier: ", StrengthMultipl);

            if (strengthMultipl < 1)
                strengthMultipl = 1;
            
            if (StrengthMultipl != strengthMultipl)
            {
                StrengthMultipl = strengthMultipl;
                PlayerPrefs.SetInt(StrengthMultiplPref, StrengthMultipl);
            }
        }

        private static void ShowAgilityMultiplier()
        {
            int agilityMultipl = EditorGUILayout.IntField("Agility Multiplier: ", AgilityMultipl);

            if (agilityMultipl < 1)
                agilityMultipl = 1;
            
            if (AgilityMultipl != agilityMultipl)
            {
                AgilityMultipl = agilityMultipl;
                PlayerPrefs.SetInt(AgilityMultiplPref, AgilityMultipl);
            }
        }

        private static void ShowIntellectMultiplier()
        {
            int intellectMultipl = EditorGUILayout.IntField("Intellect Multiplier: ", IntellectMultipl);

            if (intellectMultipl < 1)
                intellectMultipl = 1;
            
            if (IntellectMultipl != intellectMultipl)
            {
                IntellectMultipl = intellectMultipl;
                PlayerPrefs.SetInt(IntellectMultiplPref, IntellectMultipl);
            }
        }
    }
}