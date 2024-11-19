using System.Collections.Generic;
using UnityEngine;

namespace Card
{
    [CreateAssetMenu(fileName = "Deck", menuName = "Data/Deck", order = 0)]
    public class Deck : ScriptableObject
    {
        public List<CardData> cards = new List<CardData>();
    }
}