using UnityEngine;

namespace Unchord
{
    public class InputManager : MonoBehaviour
    {
        public InputSet InputSet => m_inputSet;

        private static InputManager s_m_instance;
        private InputSet m_inputSet;

        public InputController GetNewController()
        {
            return new InputController(m_inputSet);
        }

        private void Awake()
        {
            if(s_m_instance != null)
            {
                Destroy(this.gameObject);
                return;
            }

            s_m_instance = this;

            m_inputSet = new InputSet();
        }

        private void OnDestroy()
        {
            if (s_m_instance == this)
                s_m_instance = null;
        }
    }
}