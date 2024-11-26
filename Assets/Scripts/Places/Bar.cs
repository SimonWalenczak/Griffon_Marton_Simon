using System.Collections.Generic;
using Card;
using UnityEngine;

public class Bar : MonoBehaviour
{
    public List<Slot> slots;
    public int MaxCapacity = 4;
    
    public int CountGoblins()
    {
        int count = 0;
        foreach (Slot cardSlot in slots)
        {
            if (cardSlot.CurrentCard.IsGoblin)
            {
                count++;
            }
        }

        return count;
    }
    public int CountCardsByAttribute(Attribute conditionAttribute)
    {
        int count = 0;
        foreach (Slot cardSlot in slots)
        {
            if (cardSlot.CurrentCard == null)
            {
                continue;
            }
            
            if (cardSlot.CurrentCard.HasAttribute(conditionAttribute))
            {
                count++;
            }
        }

        return count;
    }
    
    public int NbSlotEmpty()
    {
        int nmSlotEmpty = 0;
        
        foreach (Slot slot in slots)
        {
            if (!slot.IsOccupied)
            {
                nmSlotEmpty++;
            }
        }
        
        return nmSlotEmpty;
    }
    
    public void FillSlots(List<CardData> newCards)
    {
        int cardIndex = 0;

        foreach (Slot slot in slots)
        {
            if (!slot.IsOccupied && cardIndex < newCards.Count)
            {
                CardData card = newCards[cardIndex];
                slot.PlaceCard(card);

                SpawnCardGameObject(card, slot.transform.position, slot.transform.rotation, slot);

                cardIndex++;
            }
        }
    }
    
    public void RemoveCard(CardData card)
    {
        foreach (Slot slot in slots)
        {
            if (slot.CurrentCard == card)
            {
                slot.RemoveCard();
                break;
            }
        }
    }
    
    private void SpawnCardGameObject(CardData card, Vector3 position, Quaternion rotation, Slot slot)
    {
        GameObject cardObject = Instantiate(GameManager.Instance.CardPrefab, position, Quaternion.identity);
        cardObject.transform.rotation = rotation;
        cardObject.name = card.cardName;
        cardObject.GetComponent<CardController>().CardData = card;
        cardObject.GetComponent<CardController>().CurrentSlot = slot;
        cardObject.GetComponent<CardVisual>().Initialize(card);
    }
}
