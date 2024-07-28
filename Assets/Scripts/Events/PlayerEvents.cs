using UnityEngine.Events;

namespace Events
{
    public class PlayerEvents
    {
        public UnityAction<int> ScoreUpdate;
        public UnityAction LevelComplete;
    }
}