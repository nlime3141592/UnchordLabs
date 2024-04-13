using FMOD.Studio;
using System;
using UnityEngine;

namespace Unchord
{
    public class BGMController
    {
        public float fadeOutSpeed = 2.0f;
        public float fadeInSpeed = 3.0f;

        // private float m_volumeControlValue;
        private string m_eventPath;
        private EventInstance m_eventInstance;

        public BGMController(string _eventPath)
        {
            UnityEngine.Debug.Assert(_eventPath != null);

            // m_volumeControlValue = 1.0f; // TODO: 0.0f로 바꿀지 결정하기.
            m_eventPath = _eventPath;
            m_eventInstance = FMODUnity.RuntimeManager.CreateInstance(_eventPath);
        }

        public void Play()
        {
            m_eventInstance.start();
        }

        public void Stop()
        {
            m_eventInstance.stop(STOP_MODE.ALLOWFADEOUT);
        }

        // TEST: 테스트 코드입니다.
        public void Pause()
        {
            bool curPaused;
            m_eventInstance.getPaused(out curPaused);
            m_eventInstance.setPaused(!curPaused);
        }

        public void ChangeBGM(string _eventPath)
        {
            UnityEngine.Debug.Assert(_eventPath != null);

            if (m_eventPath.Equals(_eventPath))
                return;

            if (m_eventInstance.isValid())
                m_eventInstance.stop(STOP_MODE.ALLOWFADEOUT);

            m_eventPath = _eventPath;
            m_eventInstance = FMODUnity.RuntimeManager.CreateInstance(_eventPath);
            m_eventInstance.start();
        }
    }
}