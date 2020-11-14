using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
namespace TheGameMecha.NPCBuilder
{
    [CustomEditor(typeof(NPCBodyPart))]
    public class NPCDataEditor : Editor
    {
        SerializedProperty prefab;
        SerializedProperty bodyPartType;

        Editor gameObjectEditor;

        private void OnEnable()
        {
            prefab = serializedObject.FindProperty("bodyPartPrefab");
            bodyPartType = serializedObject.FindProperty("bodyPartType");
        }

        public override void OnInspectorGUI()
        {
            EditorGUI.BeginChangeCheck();
            serializedObject.Update();
            EditorGUILayout.PropertyField(prefab);
            EditorGUILayout.PropertyField(bodyPartType);

            GUIStyle bgColor = new GUIStyle();
            bgColor.normal.background = EditorGUIUtility.whiteTexture;

            if (prefab != null)
            {
                if (gameObjectEditor == null)
                    gameObjectEditor = Editor.CreateEditor(prefab.objectReferenceValue);

                gameObjectEditor.OnInteractivePreviewGUI(GUILayoutUtility.GetRect(256, 256), bgColor);
            }

            if (prefab != null)
            {
                if (EditorGUI.EndChangeCheck())
                {
                    gameObjectEditor = Editor.CreateEditor(prefab.objectReferenceValue);
                }
            }
            serializedObject.ApplyModifiedProperties();
        }
    }
}