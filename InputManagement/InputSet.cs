using System.Collections.Generic;
using UnityEngine;

namespace Unchord
{
    public class InputSet
    {
        private Dictionary<InputAction, InputBase> m_inputSets;

        public InputSet()
        {
            m_inputSets = new Dictionary<InputAction, InputBase>(32);
            m_inputSets.Add(InputAction.MoveX, new InputAxis(KeyCode.RightArrow, KeyCode.LeftArrow));
            m_inputSets.Add(InputAction.MoveY, new InputAxis(KeyCode.UpArrow, KeyCode.DownArrow));
            m_inputSets.Add(InputAction.Rush, new InputBool(KeyCode.LeftShift, new InputBool(KeyCode.RightShift)));
            m_inputSets.Add(InputAction.Jump, new InputBool(KeyCode.Space));
            m_inputSets.Add(InputAction.Active000, new InputBool(KeyCode.Z));
            m_inputSets.Add(InputAction.Active001, new InputBool(KeyCode.X));
            m_inputSets.Add(InputAction.Active002, new InputBool(KeyCode.C));
            m_inputSets.Add(InputAction.Active003, new InputBool(KeyCode.V));
            m_inputSets.Add(InputAction.Active004, new InputBool(KeyCode.A));
            m_inputSets.Add(InputAction.Active005, new InputBool(KeyCode.S));
            m_inputSets.Add(InputAction.Active006, new InputBool(KeyCode.D));
            m_inputSets.Add(InputAction.Active007, new InputBool(KeyCode.F));
            m_inputSets.Add(InputAction.Confirm, new InputBool(KeyCode.Z));
            m_inputSets.Add(InputAction.Cancel, new InputBool(KeyCode.X));
            m_inputSets.Add(InputAction.Back, new InputBool(KeyCode.C));
            m_inputSets.Add(InputAction.Exit, new InputBool(KeyCode.Escape));
        }

        public InputBool GetBool(InputAction _inputAction)
        {
            return m_inputSets[_inputAction] as InputBool;
        }

        public InputAxis GetAxis(InputAction _inputAction)
        {
            return m_inputSets[_inputAction] as InputAxis;
        }
    }
}