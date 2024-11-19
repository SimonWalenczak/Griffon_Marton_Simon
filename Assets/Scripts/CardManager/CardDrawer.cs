using System;
using System.Collections.Generic;
using Card;
using UnityEngine;

public class CardDrawer : MonoBehaviour
{
    [field: SerializeField] public Deck DeckData { get; private set; }
    [field: SerializeField] public GameObject cardPrefab { get; private set; }

    [SerializeField] private List<CardData> CardData;

    private void Start()
    {
        CardData.AddRange(DeckData.cards);
    }

    public void DrawCard()
    {
        // foreach (Slot slot in CardManager.Instance.Bar.CardsInBar)
        // {
        //     if (slot.HasCard == false)
        //     {
        //         CreateCard(slot);
        //         break;
        //     }
        // }
    }

    private void CreateCard(Slot targetSlot)
    {
        if (DeckData.cards.Count > 0 && !targetSlot.HasCard)
        {
            CardData drawnCard = CardData[0];
            CardData.RemoveAt(0);

            GameObject newCard = Instantiate(cardPrefab);
            newCard.transform.position = targetSlot.transform.position;
            newCard.GetComponent<CardController>().Data = drawnCard;
            newCard.GetComponent<CardController>().CurrentSlot = targetSlot;
            newCard.GetComponent<CardVisual>().Initialize(drawnCard);
            targetSlot.PlaceCard(drawnCard);
            CardManager.Instance.Bar.CardsInBar.Add(drawnCard);
        }
    }
}