using System.Collections.Generic;
using UnityEngine;
using Inputs;
using Unity.VisualScripting;

public class CardStateManager : MonoBehaviour
{
    #region Properties

    public Camera CardCamera;

    [SerializeField] private CardController _cardHovered;
    [SerializeField] private CardController _cardSelected;

    [field: SerializeField] public float GenericMovementSpeed { get; private set; }
    [field: SerializeField] public float GenericRotationSpeed { get; private set; }
    [field: SerializeField] public float GenericScaleSpeed { get; private set; }

    private float _offsetZCardCamera;
    private int _cardSelectedIndex;
    private RaycastHit[] _cardHits = new RaycastHit[8];

    [field: SerializeField] public Vector3 CardGenericRotation { get; private set; }
    [field: SerializeField] public Vector3 CardGenericScale { get; private set; }

    [field: SerializeField] public Vector3 CardHoveredScale { get; private set; }
    [field: SerializeField] public Vector3 CardDraggedScale { get; private set; }

    [field: SerializeField] public Vector3 CardDiscardedRotation { get; private set; }

    #endregion

    #region Methods

    private void Start()
    {
        InputCardController cardControllerInput = InputManager.Instance.CardControllerInput;
        cardControllerInput.OnLeftClickDown += SetSelectedCard;
        cardControllerInput.OnLeftClickUp += CheckSlot;
        cardControllerInput.OnMouseMoved += UpdateCardDetection;
        //cardControllerInput.OnMouseStopMoved += ResetCardMoved;
    }

    private void UpdateCardDetection()
    {
        if (_cardSelected == null)
        {
            DetectCardToHovered();
        }
        else
        {
            //SetSelectedCardTransform();
            _cardSelected.CardStatus = CardStatus.Dragged;
        }

        if (_cardHovered != null)
        {
            _cardHovered.CardStatus = CardStatus.Hovered;
        }
    }

    /// <summary>
    /// Make raycasts to find a card to hovered
    /// </summary>
    private void DetectCardToHovered()
    {
        Ray ray = CardCamera.ScreenPointToRay(Input.mousePosition);
        int hits = Physics.RaycastNonAlloc(ray, _cardHits);

        if (hits != 0)
        {
            for (int i = 0; i < hits; i++)
            {
                if (_cardHits[i].collider.TryGetComponent(out CardController card) &&
                    card.CardStatus != CardStatus.Discarded)
                {
                    if (_cardHovered != null)
                    {
                        if (_cardHits[i].collider.gameObject == _cardHovered.gameObject)
                        {
                            return;
                        }

                        _cardHovered = card;
                        return;
                    }

                    _cardHovered = card;
                    return;
                }

                return;
            }

            ResetCardsStatus();
        }
        else
        {
            if (_cardHovered != null)
            {
                ResetCardsStatus();
            }
        }
    }

    private void ResetCardsStatus()
    {
        print("reset cards");
        _cardHovered = null;

        foreach (var card in CardManager.Instance.Bar.CardsInBar)
        {
            card.GetComponent<CardController>().CardStatus = CardStatus.InBar;
        }
        
        _cardHovered = null;
    }


    /// <summary>
    /// Called when player makes left mouse button click
    /// </summary>
    private void SetSelectedCard()
    {
        if (_cardHovered != null)
        {
            _cardSelected = _cardHovered;

            _offsetZCardCamera =
                _cardSelected.transform.position.z -
                CardCamera.transform.position.z;

            _cardSelectedIndex =
                CardManager.Instance.Bar.CardsInBar.IndexOf(_cardHovered.GetComponent<CardController>().Data);

            CardManager.Instance.Bar.CardsInBar.Remove(_cardHovered.GetComponent<CardController>().Data);

            _cardHovered = null;
        }
    }


    private Vector3 GetMouseWorldPosition()
    {
        Vector3 mousePoint = Input.mousePosition;
        mousePoint.z = _offsetZCardCamera;
        return CardCamera.ScreenToWorldPoint(mousePoint);
    }

    private void AddCardFromMouseToBarSlot()
    {
        CardManager.Instance.Bar.CardsInBar.Insert(_cardSelectedIndex, _cardSelected.GetComponent<CardController>().Data);
        _cardSelected.CardStatus = CardStatus.InBar;
        _cardSelected = null;
    }

    private void CheckSlot()
    {
        if (Physics.Raycast(CardCamera.ScreenPointToRay(Input.mousePosition), out RaycastHit hit))
        {
            if (hit.collider.gameObject.CompareTag("InnSlot"))
            {
                print("coucou");

                CardManager.Instance.Inn.CardsInInn.Add(_cardSelected.Data);

                _cardSelected = null;

                return;
            }
        }

        if (_cardSelected != null)
            AddCardFromMouseToBarSlot();
    }

    #endregion
}