using UnityEngine;
using FMOD.Studio;
using FMODUnity;
using FMOD;

namespace Unchord
{
    public class SoundEmitter
    {
        private string m_eventPath;

        public SoundEmitter(string _eventPath)
        {
            m_eventPath = _eventPath;
        }

        public EventInstance Emit()
        {
            EventInstance instance = FMODUnity.RuntimeManager.CreateInstance(m_eventPath);
            return instance;
        }
    }
}
