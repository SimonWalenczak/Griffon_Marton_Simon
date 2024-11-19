using System;
using Common;

namespace Inputs
{
    /// <summary>
    /// This class handle the input scheme and create classes to handle each action scheme
    /// </summary>
    public class InputManager : Singleton<InputManager>
    {
        public InputActionScheme Scheme { get; private set; }
        public InputCardController CardControllerInput { get; private set; }
        
        protected override void InternalAwake()
        {
            Scheme = new InputActionScheme();
            Scheme.Enable();
            
            CardControllerInput = new InputCardController(this);
        }
    }
    
    /// <summary>
    /// This class handle the inputs related to cards control
    /// </summary>
    public class InputCardController
    {
        public Action OnLeftClickDown { get; set; }
        public Action OnLeftClickUp { get; set; }
        public Action OnMouseMoved { get; set; }
        public Action OnMouseStopMoved { get; set; }

        public InputCardController(InputManager manager)
        {
            manager.Scheme.CardController.LeftClickPress.started += context => OnLeftClickDown?.Invoke();
            manager.Scheme.CardController.LeftClickPress.canceled += context => OnLeftClickUp?.Invoke();

            manager.Scheme.CardController.MouseMove.started += context => OnMouseMoved?.Invoke();
            manager.Scheme.CardController.MouseMove.canceled += context => OnMouseStopMoved?.Invoke();
        }
    }
}