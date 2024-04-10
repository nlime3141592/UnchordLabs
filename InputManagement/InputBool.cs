using UnityEngine;

namespace Unchord
{
    public class InputBool : InputBase
    {
        private const int c_MASK_DOWN = 0b001;
        private const int c_MASK_PRESS = 0b010;
        private const int c_MASK_UP = 0b100;

        public bool Down
        {
            get
            {
                if ((m_pressMask & InputBool.c_MASK_DOWN) > 0)
                    return true;
                else
                    return m_equivalentInputBool?.Down ?? false;
            }
        }

        public bool Press
        {
            get
            {
                if ((m_pressMask & InputBool.c_MASK_PRESS) > 0)
                    return true;
                else
                    return m_equivalentInputBool?.Press ?? false;
            }
        }

        public bool Up
        {
            get
            {
                if ((m_pressMask & InputBool.c_MASK_UP) > 0)
                    return true;
                else
                    return m_equivalentInputBool?.Up ?? false;
            }
        }

        public InputBool EquivalentInputBool
        {
            get => m_equivalentInputBool;
            set => m_equivalentInputBool = value;
        }

        public KeyCode Key
        {
            get => m_keyCode;
            set => m_keyCode = value;
        }

        private int m_pressMask;
        private InputBool m_equivalentInputBool;

        private KeyCode m_keyCode;

        public InputBool(KeyCode _keyCode, InputBool _equivalentInputBool = null)
        {
            m_keyCode = _keyCode;
            m_equivalentInputBool = _equivalentInputBool;
        }

        public override void OnUpdate()
        {
            m_equivalentInputBool?.OnUpdate();

            int pressMask = 0;

            if (Input.GetKeyDown(m_keyCode))
                pressMask |= 0b001;
            if (Input.GetKey(m_keyCode))
                pressMask |= 0b010;
            if (Input.GetKeyUp(m_keyCode))
                pressMask |= 0b100;

            m_pressMask = pressMask;
        }
    }
}