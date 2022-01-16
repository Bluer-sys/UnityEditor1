using UnityEditor;
using UnityEngine;

namespace Editor
{
    [CustomEditor(typeof(NPCHelper))]
    public class NPCHelperEditor : UnityEditor.Editor
    {
        private SerializedProperty _agroRadius;

        private void OnEnable()
        {
            _agroRadius = serializedObject.FindProperty("AgroRadius");
        }

        private void OnSceneGUI()
        {
            NPCHelper npcHelper = target as NPCHelper;
            
            Handles.color = Color.yellow;
            Handles.DrawWireDisc(npcHelper.transform.position, Vector3.up, npcHelper.AgroRadius);

            _agroRadius.floatValue = Handles.ScaleValueHandle(
                npcHelper.AgroRadius,
                npcHelper.transform.position + new Vector3(0, 0, npcHelper.AgroRadius),
                Quaternion.identity,
                1f,
                Handles.DotHandleCap,
                1f);
            
            serializedObject.ApplyModifiedProperties();
        }
    }
}