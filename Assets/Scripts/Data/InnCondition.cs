using UnityEngine;

namespace DefaultNamespace
{
    public enum ObjectType
    {
        Beer,
        Food,
        Noise,
        Number,
    }

    public enum Comparison
    {
        Less,
        LessOrEqual,
        Greater,
        GreaterOrEqual,
        Equals,
        AboveOrBelow
    }

    public enum Place
    {
        Inn,
        Bar,
    }
    
    [CreateAssetMenu(fileName = "InnCondition", menuName = "Data/Condition/InnCondition", order = 0)]
    public class InnCondition : ScriptableObject
    {
        public ObjectType Left;
        public Comparison Comparison;
        public ObjectType Right;
        public Place Place;
        public int Number;

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