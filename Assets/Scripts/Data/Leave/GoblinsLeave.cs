using Card;
using UnityEngine;

[CreateAssetMenu(fileName = "Goblins Leave", menuName = "Data/Leave/Goblins Leave", order = 0)]
public class GoblinsLeave : AbstractLeave
{
    public override void Execute(CardData card)
    {
        GameManager.Instance.inn.CardsInInn.RemoveAll(data => data.IsGoblin);
    }
}
