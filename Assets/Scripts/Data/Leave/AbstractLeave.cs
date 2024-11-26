using Card;
using UnityEngine;

public abstract class AbstractLeave : ScriptableObject
{
    public string Description;
    
    public abstract int Execute(CardData card);
}