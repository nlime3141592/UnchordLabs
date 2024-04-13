using UnityEngine;

namespace Unchord
{
    public class SoundSystemTester : MonoBehaviour
    {
        public string eventPath;
        public float interval;

        public SoundEmitter emitter;
        public SoundLooper looper;
        public bool paused = false;

        private void Start()
        {

        }

        private void Update()
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                if (Input.GetKeyDown(KeyCode.E))
                    emitter = new SoundEmitter(eventPath);
                if (Input.GetKeyDown(KeyCode.R))
                    looper = new SoundLooper(eventPath, interval, paused);
            }
            else if(Input.GetKeyDown(KeyCode.E))
            {
                emitter?.Emit().start();
            }

            if (Input.GetKeyDown(KeyCode.P) && looper != null)
                looper.Paused = !looper.Paused;

            looper?.UpdateAndPlay();
        }
    }
}