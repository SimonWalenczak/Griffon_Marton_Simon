using System;
using System.Collections.Generic;
using System.Linq;
using Card;
using Data;
using UnityEngine;
using Random = UnityEngine.Random;

public class Deck : MonoBehaviour
{
    public DeckData _deckData;

    public List<CardData> CardsInDeck;

    private void Start()
    {
        foreach (var cardData in _deckData.cards)
        {
            CardsInDeck.Add(cardData);
        }
    }

    public CardData DrawCard()
    {
        if (IsEmpty())
        {
            Debug.LogWarning("Deck is empty! No card to draw.");
            return null;
        }

        CardData cardData = CardsInDeck[0];
        
        CardsInDeck.Remove(CardsInDeck[0]);
        
        return cardData;
    }
    
    public bool IsEmpty()
    {
        return _deckData == null || CardsInDeck.Count == 0;
    }

    private void Shuffle(List<CardData> cardList)
    {
        for (int i = 0; i < cardList.Count; i++)
        {
            int randomIndex = Random.Range(0, cardList.Count);
            (cardList[i], cardList[randomIndex]) = (cardList[randomIndex], cardList[i]);
        }
    }
    
    public int GetRemainingCards()
    {
        return _deckData != null ? CardsInDeck.Count : 0;
    }
}