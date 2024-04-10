namespace Unchord
{
    public class InputController
    {
        public bool CanInput { get; set; } = true;
        public InputSet InputSet { get; set; }

        public InputController(InputSet _inputSet)
        {
            this.InputSet = _inputSet;
        }

        public bool GetDown(InputAction _inputAction)
        {
            return this.CanInput && this.InputSet.GetBool(_inputAction).Down;
        }

        public bool GetPress(InputAction _inputAction)
        {
            return this.CanInput && this.InputSet.GetBool(_inputAction).Press;
        }

        public bool GetUp(InputAction _inputAction)
        {
            return this.CanInput && this.InputSet.GetBool(_inputAction).Up;
        }

        public float GetAxis(InputAction _inputAction)
        {
            if (this.CanInput)
                return this.InputSet.GetAxis(_inputAction).Value;
            else
                return 0.0f;
        }
    }
}