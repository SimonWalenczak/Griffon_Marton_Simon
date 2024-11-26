using System.Collections.Generic;
using Card;
using UnityEngine;

namespace Data
{
    [CreateAssetMenu(fileName = "Deck", menuName = "Data/Deck", order = 0)]
    public class DeckData : ScriptableObject
    {
        public List<CardData> cards = new List<CardData>();
    }
}