using System.Collections;
using System.Collections.Generic;
using Card;
using Common;
using UnityEngine;

public enum GameState
{
    BarPhase = 0,
    InnPhase = 1
}

public class GameManager : Singleton<GameManager>
{
    public GameState GameState;
    
    public Deck deck;
    public Bar bar;
    public Inn inn;

    public int turnCounter = 0;
    public bool isGameOver = false;

    private const int victoryClientCount = 7;

    public GameObject CardPrefab;
    public Camera MainCamera;

    private void Start()
    {
        StartGame();
    }

    private void StartGame()
    {
        turnCounter = 0;
        isGameOver = false;

        List<CardData> initialClients = new List<CardData>();
        for (int i = 0; i < bar.MaxCapacity && !deck.IsEmpty(); i++)
        {
            initialClients.Add(deck.DrawCard());
        }

        bar.FillSlots(initialClients);

        Debug.Log("Game started!");
        StartTurn();
    }

    private void StartTurn()
    {
        if (isGameOver)
            return;

        GameState = GameState.BarPhase;
        
        Debug.Log($"Turn {turnCounter + 1} started.");
    }

    public void EndTurn()
    {
        if (isGameOver)
            return;

        //inn.ApplyInnEffects();

        List<CardData> newClients = new List<CardData>();
        int nbSlotEmpty = bar.NbSlotEmpty();

        for (int i = 0; i < nbSlotEmpty; i++)
        {
            if (!deck.IsEmpty())
            {
                newClients.Add(deck.DrawCard());
            }
        }

        bar.FillSlots(newClients);

        CheckGameState();

        turnCounter++;
        StartTurn();
    }

    private void CheckGameState()
    {
        if (deck.IsEmpty())
        {
            isGameOver = true;

            if (inn.CardsInInn.Count >= victoryClientCount)
            {
                Debug.Log("Victory! The inn has enough clients.");
            }
            else
            {
                Debug.Log("Defeat! Not enough clients in the inn.");
            }
        }
    }

    public void MoveCardToInn(CardData card, GameObject objToDestroy)
    {
        if (isGameOver)
            return;
        
        bar.RemoveCard(card);

        inn.AddClient(card);
        
        Destroy(objToDestroy);
        
        GameState = GameState.InnPhase;
        
        StartCoroutine(GoToEndTurn());
    }
    
    IEnumerator GoToEndTurn()
    {
        yield return new WaitForSeconds(2);

        EndTurn();
    }
}