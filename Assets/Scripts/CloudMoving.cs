using UnityEngine;
using TouchPhase = UnityEngine.InputSystem.TouchPhase;
using Touch = UnityEngine.InputSystem.EnhancedTouch.Touch;
using Unity.PolySpatial.InputDevices;

public class CloudMoving : MonoBehaviour
{
    void Update()
    {
        var activeTouches = Touch.activeTouches;
        if (activeTouches.Count > 0)
        {
            var primaryTouchPhase = activeTouches[0].phase;
            var primaryTouchData = EnhancedSpatialPointerSupport.GetPointerState(activeTouches[0]);
            if (primaryTouchPhase == TouchPhase.Moved)
            {
                var buttonObject = primaryTouchData.targetObject;
                if (buttonObject != null && buttonObject == gameObject)
                {
                    float step = 10f * Time.deltaTime; // 控制移动速度，可根据需要调整
                    // 限制移动范围 z  -0.446 0.173
                    float newX = Mathf.Clamp(primaryTouchData.interactionPosition.x, -2f, 2f);
                    float newZ = Mathf.Clamp(primaryTouchData.interactionPosition.z, -0.2f, 0.8f);
                    Vector3 targetPosition = new (newX, transform.position.y, newZ);
                    // 设置物体的新位置
                    transform.position = Vector3.MoveTowards(transform.position, targetPosition, step);
                }
            }
        }
    }
}
