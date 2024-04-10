using UnityEngine;

namespace Unchord
{
    public class InputAxis : InputBase
    {
        public float Value
        {
            get
            {
                int pressMask = m_pressMask;
                pressMask |= m_equivalentInputAxis?.m_pressMask ?? 0;

                if (pressMask == 0b01)
                    return 1.0f;
                else if (pressMask == 0b10)
                    return -1.0f;
                else
                    return 0.0f;
            }
        }

        public InputAxis EquivalentInputAxis
        {
            get => m_equivalentInputAxis;
            set => m_equivalentInputAxis = value;
        }

        public KeyCode KeyPositive
        {
            get => m_positive;
            set => m_positive = value;
        }

        public KeyCode KeyNegative
        {
            get => m_negative;
            set => m_negative = value;
        }

        private int m_pressMask;
        private InputAxis m_equivalentInputAxis;

        private KeyCode m_positive;
        private KeyCode m_negative;

        public InputAxis(KeyCode _positive, KeyCode _negative, InputAxis _equivalentInputAxis = null)
        {
            m_positive = _positive;
            m_negative = _negative;
            m_equivalentInputAxis = _equivalentInputAxis;
        }

        public override void OnUpdate()
        {
            m_equivalentInputAxis?.OnUpdate();

            int pressMask = 0;

            if (Input.GetKey(m_positive))
                pressMask |= 0b01;
            if(Input.GetKey(m_negative))
                pressMask |= 0b10;

            m_pressMask = pressMask;
        }
    }
}