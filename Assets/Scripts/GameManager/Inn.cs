using System.Collections.Generic;
using Card;
using UnityEngine;
using UnityEngine.Serialization;

namespace GameManager
{
    public class Inn : MonoBehaviour
    {
        public Slot[] slots;
        public List<CardData> cards;

        public void AddCard(CardData card)
        {
            cards.Add(card);
        }
    }
}