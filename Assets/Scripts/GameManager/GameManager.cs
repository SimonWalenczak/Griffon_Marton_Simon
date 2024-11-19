using System.Collections.Generic;
using Common;

namespace GameManager
{
    public class GameManager : Singleton<GameManager>
    {
        public List<Slot> slots = new List<Slot>();
    }
}
