using Card;
using UnityEngine;

[CreateAssetMenu(fileName = "Goblins Leave", menuName = "Data/Leave/Goblins Leave", order = 0)]
public class GoblinsLeave : AbstractLeave
{
    public override int Execute(CardData card)
    {
        int count = 0;
        
        for (int i = GameManager.Instance.inn.GetCardPosition(card); i >= 0; i--)
        {
            if (GameManager.Instance.inn.GetCardAt(i).IsGoblin)
            {
                count++;
            }
        }
        
        GameManager.Instance.inn.CardsInInn.RemoveAll(data => data.IsGoblin);
        return count;
    }
}
