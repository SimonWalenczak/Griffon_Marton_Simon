using Common;
using GameManager;
using UnityEngine;

public enum CardStatus
{
    InBar = 0,
    Hovered = 1,
    Dragged = 2,
    InInn = 3,
    Discarded = 4
}

public class CardManager : Singleton<CardManager>
{
    public static CardManager Instance;

    [field: SerializeField] public CardDrawer CardDrawer { get; private set; }
    [field: SerializeField] public Bar Bar { get; private set; }
    [field: SerializeField] public Inn Inn { get; private set; }
    [field: SerializeField] public DiscardPile DiscardPile { get; private set; }
    [field: SerializeField] public CardStateManager CardStateManager { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Debug.LogError("There is already another Card Manager in this scene !");
        }
    }
}