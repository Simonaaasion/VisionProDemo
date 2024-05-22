using UnityEngine;
using TouchPhase = UnityEngine.InputSystem.TouchPhase;
using Touch = UnityEngine.InputSystem.EnhancedTouch.Touch;
using Unity.PolySpatial.InputDevices;
using System.Collections;

public class HouseMoving:MonoBehaviour {
	public GameObject PinkCloud;
	public GameObject GameOverBtn;
	public AudioSource HouseDown;
	public float moveSpeed = 3f; // 移动速度
	private bool moved = false;

	private void OnEnable() {
		GameOverBtn.SetActive(true);
		PinkCloud.SetActive(true);
		if(gameObject.TryGetComponent(out BoxCollider boxCollider)) {
			boxCollider.enabled=false;
		}
	}
	void Update() {

		/*
		var activeTouches = Touch.activeTouches;
		if(activeTouches.Count>0) {
			var primaryTouchPhase = activeTouches[0].phase;
			var primaryTouchData = EnhancedSpatialPointerSupport.GetPointerState(activeTouches[0]);
			if(primaryTouchPhase==TouchPhase.Moved) {
				var buttonObject = primaryTouchData.targetObject;
				if(buttonObject!=null&&buttonObject==gameObject) {
					float step = 10f*Time.deltaTime; // 控制移动速度，可根据需要调整
																					 // 限制移动范围
					float newX = Mathf.Clamp(primaryTouchData.interactionPosition.x,-1.5f,-1f);
					float newZ = Mathf.Clamp(primaryTouchData.interactionPosition.z,-0.398f,0.662f);
					// 设置物体的新位置
					Vector3 targetPosition = new(newX,transform.position.y,newZ);
					transform.position=Vector3.MoveTowards(transform.position,targetPosition,step);
					moved=true;
				}
			}
			if(primaryTouchPhase==TouchPhase.Ended) {
				var buttonObject = primaryTouchData.targetObject;
				if(buttonObject!=null&&buttonObject==gameObject) {
					if(moved) {
						HouseDown.Play();
						// 移动后松开 -0.467
						gameObject.transform.position=new Vector3(gameObject.transform.position.x,gameObject.transform.position.y,gameObject.transform.position.z);
						// 关闭house碰撞器 云彩滑出 开启结束按钮
						if(boxCollider) {
							boxCollider.enabled=false;
							StartCoroutine(MoveToTarget(new Vector3(PinkCloud.transform.position.x+1.5f,PinkCloud.transform.position.y,PinkCloud.transform.position.z),moveSpeed));
							GameOverBtn.SetActive(true);

						}
					}
				}
			}
		}
		*/
	}
	private IEnumerator MoveToTarget(Vector3 target,float speed) {
		while(Vector3.Distance(PinkCloud.transform.position,target)>0.01f) {
			PinkCloud.transform.position=Vector3.MoveTowards(PinkCloud.transform.position,target,speed*Time.deltaTime);
			yield return null;
		}
	}
}
