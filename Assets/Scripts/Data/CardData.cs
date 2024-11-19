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
        public Consequence Consequence;
    }

    [Serializable]
    public struct Attribute
    {
        public string name;
        public Sprite icon;
    }
}