using System;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

namespace Card
{
    [CreateAssetMenu(fileName = "Card data", menuName = "Data/Card", order = 0)]
    public class CardData : ScriptableObject
    {
        public string cardName;
        public Sprite cardSprite;
        public List<Attribute> attributes;
        public Attribute BarCondition;
        public InnCondition InnCondition;
        public string InnConditionText; 
        public AbstractLeave LeaveEvent;
        public bool IsGoblin;

        public bool HasAttribute(Attribute conditionAttribute)
        {
            foreach (Attribute attribute in attributes)
            {
                if (attribute == conditionAttribute)
                {
                    return true;
                }
            }

            return false;
        }

        public bool WantsToLeave(CardAttributeManager.PlayState state)
        {
            if (state == CardAttributeManager.PlayState.InnState)
            {
                return InnCondition.CheckCondition(CardAttributeManager.Instance.Inn.GetCardPosition(this));
            }
            else
            {
                return CardAttributeManager.Instance.Bar.CountCardsByAttribute(BarCondition) >= 3;
            }
        }
    }

    public enum Attribute
    {
        None,
        Food,
        Beer,
        Fight,
        Noise,
        Smell,
    }
}