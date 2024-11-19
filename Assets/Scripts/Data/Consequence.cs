using UnityEngine;

namespace DefaultNamespace
{
    [CreateAssetMenu(fileName = "Consequence", menuName = "Data/Condition/Consequences", order = 0)]
    public class Consequence : ScriptableObject
    {
        public string ConsequenceText;
    }
}