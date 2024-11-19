using System.Collections.Generic;
using Card;
using UnityEngine;

public class CardAttributeManager : MonoBehaviour
{
    public static CardAttributeManager Instance { get; private set; }

    public Inn Inn;
    public Bar Bar;
    
    public List<Sprite> AttributeSprites;
    
    private void Awake()
    {
        Instance = this;
    }

    public Sprite GetSprite(Attribute cardAttribute)
    {
        return AttributeSprites[(int) cardAttribute];
    }
}
