using Card;
using UnityEngine;

public class CardController : MonoBehaviour
{
    public CardData CardData;
    public Slot CurrentSlot;

    private void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0) && GameManager.Instance.GameState == GameState.BarPhase)
        {
            GameManager.Instance.MoveCardToInn(CardData, gameObject);
        }
    }
}