﻿using System.Collections.Generic;
using Card;
using UnityEngine;

public class Inn : MonoBehaviour
{
    public Transform spawnPoint;
    public float cardSpacing = 1.5f;
    public float cardScale;
    
    public List<CardData> CardsInInn = new();

    private List<GameObject> ObjectsInInn = new();

    public CardData GetCardAt(int cardFloor)
    {
        if (cardFloor < 0 || cardFloor + 1 > CardsInInn.Count)
        {
            return null;
        }

        return CardsInInn[cardFloor];
    }

    public int CountGoblins()
    {
        int count = 0;
        foreach (CardData card in CardsInInn)
        {
            if (card.IsGoblin)
            {
                count++;
            }
        }

        return count;
    }

    public int CountCardsByAttribute(Attribute conditionAttribute)
    {
        int count = 0;
        foreach (CardData card in CardsInInn)
        {
            if (card.HasAttribute(conditionAttribute))
            {
                count++;
            }
        }

        return count;
    }

    public int GetCardPosition(CardData cardData)
    {
        return CardsInInn.FindIndex(data => data.cardName == cardData.cardName);
    }

    public int RemoveCardWithHateAttribute(Attribute hateAttribute, int CardIndex = 99)
    {
        int countBelowCard = 0;
        
        for (int i = CardsInInn.Count - 1; i >= 0; i--)
        {
            CardData card = CardsInInn[i];
            if (card.BarCondition == hateAttribute)
            {
                if (i < CardIndex)
                {
                    countBelowCard++;
                }
                
                RemoveCard(card);
            }
        }

        return countBelowCard;
    }
    
    public void AddClient(CardData card)
    {
        CardsInInn.Add(card);
        SpawnCardGameObject(card);
        Debug.Log($"Card {card.cardName} added to the inn.");
    }
    
    public void RemoveCard(CardData card)
    {
        if (CardsInInn.Contains(card))
        {
            int cardIndex = GetCardPosition(card);
            RemoveCardAt(cardIndex);
            Debug.Log($"Card {card.cardName} removed from the inn.");
        }
        else
        {
            Debug.LogWarning($"Card {card.cardName} not found in the inn.");
        }
    }
    
    private void SpawnCardGameObject(CardData card)
    {
        Vector3 position = GetNextCardPosition();
        GameObject cardObject = Instantiate(GameManager.Instance.CardPrefab, position, this.transform.rotation);
        cardObject.GetComponent<CardVisual>().Initialize(card);
        cardObject.transform.localScale *= cardScale;
        cardObject.name = card.cardName;

        ObjectsInInn.Add(cardObject);
    }
    
    private Vector3 GetNextCardPosition()
    {
        return spawnPoint.position + new Vector3(0,1,CardsInInn.Count * -0.1f) * (CardsInInn.Count * cardSpacing);
    }

    public void ApplyInnEffects()
    {
        for (int i = CardsInInn.Count - 1; i >= 0; i--)
        {
            CardData card = CardsInInn[i];

            if (card.WantsToLeave(CardAttributeManager.PlayState.InnState))
            {
                i -= card.LeaveEvent.Execute(card);
                
                Debug.Log(card.cardName + " left the inn.");
            }
        }
    }

    public void RemoveCardAt(int index)
    {
        Destroy(ObjectsInInn[index]);
            
        CardsInInn.RemoveAt(index);
        ObjectsInInn.RemoveAt(index);

        for (int i = index; i < ObjectsInInn.Count; i++)
        {
            ObjectsInInn[i].transform.position -= new Vector3(0, cardSpacing, -0.1f);
        }
    }
}
