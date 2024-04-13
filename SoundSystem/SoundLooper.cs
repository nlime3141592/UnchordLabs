using UnityEngine;
using FMOD.Studio;
using FMODUnity;
using FMOD;

namespace Unchord
{
    public class SoundLooper
    {
        public float Interval
        {
            get => m_interval;
            set
            {
                UnityEngine.Debug.Assert(value > 0.0f);
                m_interval = value;
            }
        }

        public bool Paused
        {
            get => m_paused;
            set
            {
                if (m_paused == value)
                    return;

                m_paused = value;
                m_soundInstance.setPaused(m_paused);
                m_leftInterval = 0.0f;
            }
        }

        public string EventPath
        {
            get => m_eventPath;
            set
            {
                if(m_soundInstance.isValid())
                    m_soundInstance.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);

                m_eventPath = value;
                m_soundInstance = FMODUnity.RuntimeManager.CreateInstance(m_eventPath);
                m_soundInstance.setPaused(m_paused);
            }
        }

        private FMOD.Studio.EventInstance m_soundInstance;
        private string m_eventPath;
        private float m_interval;
        private float m_leftInterval;
        private bool m_paused;

        public SoundLooper(string _eventPath, float _interval, bool _initialPaused = true)
        {
            UnityEngine.Debug.Assert(_interval > 0.0f);

            m_soundInstance = FMODUnity.RuntimeManager.CreateInstance(_eventPath);
            m_eventPath = _eventPath;
            m_interval = _interval;
            m_leftInterval = 0.0f;
            m_paused = _initialPaused;
            m_soundInstance.setPaused(_initialPaused);
        }

        public bool UpdateAndPlay()
        {
            if (m_paused || !m_soundInstance.isValid())
                return false;
            else if ((m_leftInterval -= Time.deltaTime) > 0.0f)
                return false;
            else if (m_soundInstance.start() != RESULT.OK)
                return false;
            else
                return (m_leftInterval += m_interval) > 0.0f;
        }
    }
}