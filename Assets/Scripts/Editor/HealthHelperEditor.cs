using UnityEditor;
using UnityEngine;

namespace Editor
{
    [CustomEditor(typeof(HealthHelper))]
    public class HealthHelperEditor : UnityEditor.Editor
    {
        [SerializeField] private Texture2D constHealthTexture;
        [SerializeField] private Texture2D maxHealthTexture;
        [SerializeField] private Texture2D healthTexture;
        [SerializeField] private Texture2D strengthTexture;
        [SerializeField] private Texture2D agilityTexture;
        [SerializeField] private Texture2D intellectTexture;
    
        private SerializedProperty _constHealth;
        private SerializedProperty _maxHealth;
        private SerializedProperty _health;

        private SerializedProperty _isHero;
        private SerializedProperty _strength;
        private SerializedProperty _agility;
        private SerializedProperty _intellect;

        private void OnEnable()
        {
            _constHealth = serializedObject.FindProperty("ConstHealth");
            _maxHealth = serializedObject.FindProperty("MaxHealth");
            _health = serializedObject.FindProperty("Health");
        
            _isHero = serializedObject.FindProperty("IsHero");
            _strength = serializedObject.FindProperty("Strength");
            _agility = serializedObject.FindProperty("Agility");
            _intellect = serializedObject.FindProperty("Intellect");
        }

        public override void OnInspectorGUI()
        {
            HealthHelper healthHelper = target as HealthHelper;

            if (!healthHelper)
                return;
            serializedObject.Update();

            GUIStyle heroParamsStyle = new GUIStyle(EditorStyles.textField);
            heroParamsStyle.margin = new RectOffset(0, 0, 10, 0);
            heroParamsStyle.fontSize = 15;
        
            ShowConstHealth(heroParamsStyle);
            ShowIsHero();
            TryShowHeroParams(heroParamsStyle);
            ShowHealth(heroParamsStyle);
            ShowMaxHealth();

            serializedObject.ApplyModifiedProperties();
        }

        private void TryShowHeroParams(GUIStyle heroParamsStyle)
        {
            if (_isHero.boolValue)
            {
                ShowStrength(heroParamsStyle);
                ShowAgility(heroParamsStyle);
                ShowIntellect(heroParamsStyle);
            }
        }

        private void ShowStrength(GUIStyle heroParamsStyle)
        {
            GUILayout.BeginHorizontal();
            GUILayout.Label(strengthTexture, GUILayout.Width(30));
        
            int strength = EditorGUILayout.IntField("Strength: ", _strength.intValue, heroParamsStyle);
        
            if (strength < 0)
                strength = 0;

            _strength.intValue = strength;
        
            GUILayout.EndHorizontal();
        }

        private void ShowAgility(GUIStyle heroParamsStyle)
        {
            GUILayout.BeginHorizontal();
            GUILayout.Label(agilityTexture, GUILayout.Width(30));
        
            int agility = EditorGUILayout.IntField("Agility: ", _agility.intValue, heroParamsStyle);
        
            if (agility < 0)
                agility = 0;
        
            _agility.intValue = agility;
        
            GUILayout.EndHorizontal();
        }

        private void ShowIntellect(GUIStyle heroParamsStyle)
        {
            GUILayout.BeginHorizontal();
            GUILayout.Label(intellectTexture, GUILayout.Width(30));
        
            int intellect = EditorGUILayout.IntField("Intellect: ", _intellect.intValue, heroParamsStyle);
        
            if (intellect < 0)
                intellect = 0;
        
            _intellect.intValue = intellect;
        
            GUILayout.EndHorizontal();
        }

        private void ShowIsHero()
        {
            bool isHero = EditorGUILayout.Toggle("Is Hero: ", _isHero.boolValue);
            _isHero.boolValue = isHero;
        }

        private void ShowConstHealth(GUIStyle heroParamsStyle)
        {
            GUILayout.BeginHorizontal();
            GUILayout.Label(constHealthTexture, GUILayout.Width(30));
        
            int constHealth = EditorGUILayout.IntField("Const Health: ", _constHealth.intValue, heroParamsStyle);

            if (constHealth < 0)
                constHealth = 0;
        
            _constHealth.intValue = constHealth;
            GUILayout.EndHorizontal();
        }

        private void ShowMaxHealth()
        {
            GUILayout.BeginHorizontal();
            GUILayout.Label(maxHealthTexture, GUILayout.Width(30));

            GUIStyle style = new GUIStyle();
            style.normal.textColor = Color.green;
            style.margin = new RectOffset(0, 0, 10, 0);
            style.fontSize = 15;
        
            if (_isHero.boolValue)
            {
                _maxHealth.intValue = _constHealth.intValue + _strength.intValue * SettingsEditor.StrengthMultipl;
            }
            else
            {
                _maxHealth.intValue = _constHealth.intValue;
            }

            GUILayout.TextField("Max Health: " + _maxHealth.intValue, style);

            GUILayout.EndHorizontal();
        }

        private void ShowHealth(GUIStyle heroParamsStyle)
        {
            GUILayout.BeginHorizontal();
            GUILayout.Label(healthTexture, GUILayout.Width(30));
        
            int health = EditorGUILayout.IntField("Health: ", _health.intValue, heroParamsStyle);

            if (health < 0)
                health = 0;
        
            if (health > _maxHealth.intValue)
                health = _maxHealth.intValue;
        
            _health.intValue = health;
        
            GUILayout.EndHorizontal();
        }
    }
}