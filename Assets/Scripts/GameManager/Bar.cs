using System.Collections.Generic;
using Card;
using UnityEngine;

namespace GameManager
{
    public class Bar : MonoBehaviour
    {
        public Slot[] slots = new Slot[4];
        public List<CardData> cards;
    }
}