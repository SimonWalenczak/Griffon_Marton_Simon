using System;
using System.Collections.Generic;
using UnityEngine;

namespace DefaultNamespace
{
    public enum ConditionType
    {
        None,
        Or,
        And,
    }
    
    public enum ObjectType
    {
        Beer,
        Food,
        Noise,
        Number,
        Goblin,
        Floor,
    }

    public enum Comparison
    {
        Less,
        LessOrEqual,
        Greater,
        GreaterOrEqual,
        Equals,
        AboveOrBelow,
        Adjascent,
        LastFloor,
    }

    public enum Place
    {
        Inn,
        Bar,
    }

    [Serializable]
    public class Condition
    {
        public ConditionType ConditionType;
        public ObjectType Left;
        public Comparison Comparison;
        public ObjectType Right;
        public Place Place;
        public int Number;
    }
    
    [CreateAssetMenu(fileName = "InnCondition", menuName = "Data/Condition/InnCondition", order = 0)]
    public class InnCondition : ScriptableObject
    {
        public List<Condition> Conditions;

        public bool CheckCondition()
        {
            return false;
        }
    }
}

/*
OBJECT COMPARISON COUNT PLACE
OBJECT ABOVEORBELOW
OBJECT COMPARISON OBJECT
 */