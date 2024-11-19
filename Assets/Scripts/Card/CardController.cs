using UnityEngine;
using Card;

public class CardController : MonoBehaviour
{
    public CardData Data;
    public Slot CurrentSlot;
    [field: SerializeField] public CardVisual CardVisual { get; private set; }

    public CardStatus CardStatus;

    public Vector3 CardPosition;
    public Quaternion CardRotation;
    public Vector3 CardScale;

    CardStateManager _cardStateManager;

    private void Start()
    {
        _cardStateManager = CardManager.Instance.CardStateManager;
        CardVisual = GetComponent<CardVisual>();
        CardVisual.Initialize(Data);
    }

    private void Update()
    {
        switch (CardStatus)
        {
            case CardStatus.InBar:
                CardPosition = CurrentSlot.transform.position;
                CardRotation = new Quaternion(0, 0, 0, 0);
                CardScale = _cardStateManager.CardGenericScale;
                break;

            case CardStatus.Hovered:
                CardPosition = CurrentSlot.transform.position;
                CardRotation = new Quaternion(0, 0, 0, 0);
                CardScale = _cardStateManager.CardHoveredScale;
                break;

            case CardStatus.Dragged:
                CardPosition = CurrentSlot.transform.position;
                CardRotation = new Quaternion(0, 0, 0, 0);
                CardScale = _cardStateManager.CardDraggedScale;
                break;

            case CardStatus.InInn:
                CardPosition = CurrentSlot.transform.position;
                CardRotation = new Quaternion(0, 0, 0, 0);
                CardScale = _cardStateManager.CardGenericScale;
                break;

            case CardStatus.Discarded:
                CardPosition = CurrentSlot.transform.position;
                CardRotation = new Quaternion(0, 0, 0, 0);
                CardScale = _cardStateManager.CardGenericScale;
                break;
        }

        transform.position = Vector3.Lerp(transform.position, CardPosition, Time.deltaTime * _cardStateManager.GenericRotationSpeed);
        transform.rotation = Quaternion.Lerp(transform.rotation, CardRotation, Time.deltaTime * _cardStateManager.GenericRotationSpeed);
        transform.localScale = Vector3.Lerp(transform.localScale, CardScale, Time.deltaTime * _cardStateManager.GenericScaleSpeed);
    }
}