using System.Collections.Generic;
using DefaultNamespace;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using Comparison = DefaultNamespace.Comparison;

[CustomEditor(typeof(InnCondition))]
public class InnConditionEditor : Editor
{
    private SerializedProperty _conditionList;
    
    private void OnEnable()
    {
        _conditionList = serializedObject.FindProperty("Conditions");
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        List<Condition> conditions = (List<Condition>) _conditionList.GetUnderlyingValue();
        for (int i = 0; i < conditions.Count; ++i)
        {
            SerializedProperty serializedCondition = _conditionList.GetArrayElementAtIndex(i);
            
            SerializedProperty left = serializedCondition.FindPropertyRelative("Left");
            SerializedProperty comparison = serializedCondition.FindPropertyRelative("Comparison");
            SerializedProperty right = serializedCondition.FindPropertyRelative("Right");
            SerializedProperty number = serializedCondition.FindPropertyRelative("Number");
            SerializedProperty place = serializedCondition.FindPropertyRelative("Place");
            
            
            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.PropertyField(left, new GUIContent(""));
            ObjectType leftType = (ObjectType) left.GetUnderlyingValue();
            EditorGUILayout.PropertyField(comparison, new GUIContent(""));

            if (leftType == ObjectType.Floor)
            {
                EditorGUILayout.EndHorizontal();
                right.SetUnderlyingValue(ObjectType.Number);
                
                Comparison comparisonType = (Comparison) comparison.GetUnderlyingValue();
                if (comparisonType != Comparison.LastFloor)
                {
                    EditorGUILayout.PropertyField(number, new GUIContent($"{leftType.HumanName()} Count"));                    
                }
            }
            else
            {
                Comparison comparisonType = (Comparison) comparison.GetUnderlyingValue();
                if (comparisonType == Comparison.AboveOrBelow)
                {
                    EditorGUILayout.EndHorizontal();
                }
                else if (comparisonType == Comparison.Adjascent)
                {
                    EditorGUILayout.EndHorizontal();
                    right.SetUnderlyingValue(ObjectType.Number);
                
                    EditorGUILayout.PropertyField(number, new GUIContent($"{leftType.HumanName()} Count"));
                }
                else
                {
                    EditorGUILayout.PropertyField(right, new GUIContent(""));
                    EditorGUILayout.EndHorizontal();
            
                    ObjectType type = (ObjectType) right.GetUnderlyingValue();
                    if (type == ObjectType.Number)
                    {
                        EditorGUILayout.PropertyField(number, new GUIContent($"{leftType.HumanName()} Count"));
                    }
            
                    EditorGUILayout.PropertyField(place, new GUIContent("In"));
                }
            }

            SerializedProperty conditionTypeField = serializedCondition.FindPropertyRelative("ConditionType");
            EditorGUILayout.PropertyField(conditionTypeField);
            ConditionType conditionType = (ConditionType) conditionTypeField.GetUnderlyingValue();

            if (conditionType == ConditionType.None)
            {
                conditions.RemoveRange(i + 1, conditions.Count - i - 1);
                serializedObject.ApplyModifiedProperties();
                break;
            }
            
            if (i == conditions.Count - 1)
            {
                conditions.Add(new Condition());
                serializedObject.ApplyModifiedProperties();
                break;
            }
            
            serializedObject.ApplyModifiedProperties();
            EditorGUILayout.Separator();
        }
    }
}