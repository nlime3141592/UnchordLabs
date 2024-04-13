using UnityEngine;

namespace Unchord
{
    public class TestBGMManager : MonoBehaviour
    {
        public string eventPath = "event:/BGM/Test/A0";

        public BGMController controller;

        [Header("control booleans")]
        public bool doChange;
        public bool doStop;
        public bool doPlay;
        public bool doPause;

        private void Start()
        {
            controller = new BGMController(eventPath);
        }

        private void Update()
        {
            if(doChange)
            {
                doChange = false;
                controller.ChangeBGM(eventPath);
            }

            if (doStop)
            {
                doStop = false;
                controller.Stop();
            }

            if (doPlay)
            {
                doPlay = false;
                controller.Play();
            }
            
            if(doPause)
            {
                doPause = false;
                controller.Pause();
            }
        }
    }
}