using System;
using System.Collections.Generic;
using Card;
using Unity.VisualScripting;
using UnityEngine;
using Attribute = Card.Attribute;

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
        Adjacent,
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

        public bool CheckCondition(int CardFloor)
        {
            bool output = true;
            foreach (Condition condition in Conditions)
            {
                bool evaluation = EvaluateCondition(condition, CardFloor);
                switch (condition.ConditionType)
                {
                    case ConditionType.And:
                    {
                        output &= evaluation;
                        break;
                    }
                    
                    case ConditionType.Or:
                    {
                        output |= evaluation;
                        break;
                    }

                    case ConditionType.None:
                    {
                        output = evaluation;
                        break;
                    }
                }
            }
            
            return output;
        }

        private bool EvaluateCondition(Condition condition, int CardFloor)
        {
            switch (condition.Comparison)
            {
                case Comparison.AboveOrBelow:
                {
                    return EvaluateAboveOrBelow(condition, CardFloor);
                }

                case Comparison.LastFloor:
                {
                    return CardFloor + 1 == CardAttributeManager.Instance.Inn.CardsInInn.Count;
                }

                case Comparison.Adjacent:
                {
                    return EvaluateAdjacent(condition);
                }

                default:
                {
                    return EvaluateComparison(condition);
                }
            }
        }

        private void Count(ref int count, ObjectType objectType, Condition condition)
        {
            if (objectType == ObjectType.Goblin)
            {
                if (condition.Place == Place.Inn)
                {
                    count = CardAttributeManager.Instance.Inn.CountGoblins();
                }
                else
                {
                    count = CardAttributeManager.Instance.Bar.CountGoblins();
                }
            }
            else if (objectType == ObjectType.Floor)
            {
                count = CardAttributeManager.Instance.Inn.CardsInInn.Count;
            }
            else if (objectType == ObjectType.Number)
            {
                count = condition.Number;
            }
            else if (Enum.TryParse(objectType.HumanName(), out Attribute attribute))
            {
                if (condition.Place == Place.Inn)
                {
                    count = CardAttributeManager.Instance.Inn.CountCardsByAttribute(attribute);
                }
                else
                {
                    count = CardAttributeManager.Instance.Bar.CountCardsByAttribute(attribute);
                }
            }
        }

        private bool EvaluateComparison(Condition condition)
        {
            int leftCount = -1;
            int rightCount = -1;
            
            Count(ref leftCount, condition.Left, condition);
            Count(ref rightCount, condition.Right, condition);
            
            switch (condition.Comparison)
            {
                case Comparison.Equals:         return leftCount == rightCount;
                case Comparison.Less:           return leftCount < rightCount;
                case Comparison.LessOrEqual:    return leftCount <= rightCount;
                case Comparison.Greater:        return leftCount > rightCount;
                case Comparison.GreaterOrEqual: return leftCount >= rightCount;
            }
            
            return false;
        }

        private bool EvaluateAdjacent(Condition condition)
        {
            if (!Enum.TryParse(condition.Left.DisplayName(), out Attribute conditionAttribute))
            {
                return false;
            }
            
            int count = 0;

            bool previousCardCounted = true;
            foreach (CardData card in CardAttributeManager.Instance.Inn.CardsInInn)
            {
                if (card.HasAttribute(conditionAttribute))
                {
                    if (previousCardCounted)
                    {
                        count++;
                    }
                    else
                    {
                        previousCardCounted = true;
                        count = 1;
                    }
                }
                else
                {
                    previousCardCounted = false;
                    count = 0;
                }
            }
            
            return count >= condition.Number;
        }

        private bool EvaluateAboveOrBelow(Condition condition, int cardFloor)
        {
            CardData belowCard = CardAttributeManager.Instance.Inn.GetCardAt(cardFloor - 1);
            CardData aboveCard = CardAttributeManager.Instance.Inn.GetCardAt(cardFloor + 1);

            if (!Enum.TryParse(condition.Left.DisplayName(), out Attribute conditionAttribute))
            {
                return false;
            }
            
            return (belowCard != null && belowCard.HasAttribute(conditionAttribute)) ||
                   (aboveCard != null && aboveCard.HasAttribute(conditionAttribute));
        }
    }
}
