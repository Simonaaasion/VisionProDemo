using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.EnhancedTouch;
using UnityEngine.InputSystem.LowLevel;
using TouchPhase = UnityEngine.InputSystem.TouchPhase;
using Touch = UnityEngine.InputSystem.EnhancedTouch.Touch;
using System.Linq;

namespace PolySpatial.Template
{
    public class SpatialUIInputManager : MonoBehaviour
    {
        [SerializeField]
        InputActionReference m_Touch;
        // Èý¿ÃÊ÷
        public GameObject Tree1;
        public GameObject Tree2;
        public GameObject Tree3;
      
        void OnEnable()
        {
            EnhancedTouchSupport.Enable();
            m_Touch.action.Enable();
        }

        void Update()
        {
            var touchData = m_Touch.action.ReadValue<SpatialPointerState>();
            var activeTouches = Touch.activeTouches;
            if (activeTouches.Count > 0)
            {
                var primaryTouchPhase = activeTouches[0].phase;

                if (primaryTouchPhase == TouchPhase.Began)
                {
                    var buttonObject = touchData.targetObject;
                    if (buttonObject != null)
                    {
                        if (buttonObject.TryGetComponent(out SpatialUI uiElement))
                        {
                            uiElement.PressStart();
                        }
                    }
                }

                if (primaryTouchPhase == TouchPhase.Ended)
                {
                    var buttonObject = touchData.targetObject;
                    if (buttonObject != null)
                    {
                        if (buttonObject.TryGetComponent(out SpatialUI uiElement))
                        {
                            uiElement.PressEnd();
                            return;
                        }
                        GameObject[] treeList = new GameObject[]
                           {
                                Tree1,
                                Tree2,
                                Tree3
                           };
                        if (treeList.Contains(buttonObject))
                        {
                            buttonObject.TryGetComponent(out SpatialUI a);
                        }
                    }
                }
            }
        }
    }
}
