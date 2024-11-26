using System;
using Card;
using UnityEngine;

public class Slot : MonoBehaviour
{
    public bool IsOccupied;
    [field: SerializeField] public CardData CurrentCard { get; private set; }

    private void Update()
    {
        IsOccupied = CurrentCard != null;
    }

    public void PlaceCard(CardData card)
    {
        if (IsOccupied)
        {
            Debug.LogWarning("Slot is already occupied!");
            return;
        }

        CurrentCard = card;
        Debug.Log($"Card {card.cardName} placed in slot {gameObject.name}.");
    }
    
    public void RemoveCard()
    {
        if (!IsOccupied)
        {
            Debug.LogWarning("Slot is already empty!");
            return;
        }

        Debug.Log($"Card {CurrentCard.cardName} removed from slot {gameObject.name}.");
        CurrentCard = null;
        IsOccupied = false;
        
    }
}