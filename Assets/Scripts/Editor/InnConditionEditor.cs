using DefaultNamespace;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using Comparison = DefaultNamespace.Comparison;

[CustomEditor(typeof(InnCondition))]
public class InnConditionEditor : Editor
{
    private SerializedProperty _left;
    private SerializedProperty _comparison;
    private SerializedProperty _right;
    private SerializedProperty _number;
    private SerializedProperty _place;
    
    private void OnEnable()
    {
        _left = serializedObject.FindProperty("Left");
        _comparison = serializedObject.FindProperty("Comparison");
        _right = serializedObject.FindProperty("Right");
        _number = serializedObject.FindProperty("Number");
        _place = serializedObject.FindProperty("Place");
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.PropertyField(_left, new GUIContent(""));
        EditorGUILayout.PropertyField(_comparison, new GUIContent(""));
        Comparison comparisonType = (Comparison) _comparison.GetUnderlyingValue();
        if (comparisonType == DefaultNamespace.Comparison.AboveOrBelow)
        {
            serializedObject.ApplyModifiedProperties();
            EditorGUILayout.EndHorizontal();
            return;
        }
        
        EditorGUILayout.PropertyField(_right, new GUIContent(""));
        EditorGUILayout.EndHorizontal();

        ObjectType type = (ObjectType) _right.GetUnderlyingValue();
        if (type == ObjectType.Number)
        {
            ObjectType leftType = (ObjectType) _left.GetUnderlyingValue();
            EditorGUILayout.PropertyField(_number, new GUIContent($"{leftType.HumanName()} Count"));
        }
        
        EditorGUILayout.PropertyField(_place, new GUIContent("In"));
        serializedObject.ApplyModifiedProperties();
    }
}