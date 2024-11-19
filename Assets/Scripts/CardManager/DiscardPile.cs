using System.Collections.Generic;
using Card;
using UnityEngine;

public class DiscardPile : MonoBehaviour
{
    [field: SerializeField] public List<CardData> CardsInDiscardPile { get; set; }
}