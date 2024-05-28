using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.LowLevel;
using TouchPhase = UnityEngine.InputSystem.TouchPhase;
using Touch = UnityEngine.InputSystem.EnhancedTouch.Touch;
using Unity.PolySpatial.InputDevices;
using TMPro;
using System.Runtime.CompilerServices;
using Unity.XR.CoreUtils;
using System.Diagnostics;
public class GroundUpdate:MonoBehaviour {
	public GameObject[] flowers; // 通过Inspector面板关联三个物体
	public AudioSource audioSource;
	public GameObject Scoreboard;
	public TMP_Text textMeshPro;
	public GameObject nextBtn;

	[SerializeField] float lowestLevel = -0.06173228f;

	public GameObject prefab;
	GameObject hotBar;

	public int maxObjects = 10;
	private int currentObjects = 0;
	bool isWorking;

	public static GroundUpdate instance;
	public void Enter(int maxObjects,GameObject hotBar,GameObject nextBtn) {
		isWorking=true;
		currentObjects=0;
		this.maxObjects=maxObjects;
		Scoreboard.SetActive(true);
		if(gameObject.TryGetComponent(out MeshCollider meshCollider)) {
			meshCollider.enabled=true;
		}
		if(textMeshPro!=null) {
			textMeshPro.text=$"x {maxObjects-currentObjects}";
		}
		this.hotBar=hotBar;
		hotBar.SetActive(true);
		this.nextBtn=nextBtn;
		HotBarElement target = hotBar.GetComponentInChildren<HotBarElement>();
		prefab=target.targetPrefab;
	}

	private void Start() {
		instance=this;
	}
	void Update() {
		if(!isWorking) return;
		var activeTouches = Touch.activeTouches;
		if(activeTouches.Count>0) {
			var primaryTouchPhase = activeTouches[0].phase;
			var primaryTouchData = EnhancedSpatialPointerSupport.GetPointerState(activeTouches[0]);
			
			if(primaryTouchPhase==TouchPhase.Began) {
				var buttonObject = primaryTouchData.targetObject;

				for(;buttonObject!=null&&buttonObject!=gameObject;buttonObject=buttonObject.transform.parent?.gameObject) ;

				Vector3 sourcePosition = primaryTouchData.interactionPosition; // 起始位置
				if(buttonObject!=null&&sourcePosition.y>=lowestLevel) {
					if(buttonObject==gameObject) {


						int randomIndex = Random.Range(0,flowers.Length); // 生成一个范围在0到objects.Length之间的随机整数
						GameObject copiedObject = Instantiate(prefab);
						// 将复制的对象放置在目标位置
						copiedObject.transform.position=sourcePosition;
						copiedObject.transform.localScale*=0.3f;
						copiedObject.SetActive(true);
						// 将复制的对象放置在目标位置的父级下
						copiedObject.transform.parent=gameObject.transform.parent;
						currentObjects+=1;
						if(textMeshPro!=null) {
							// 修改 TextMeshPro 的文本内容
							textMeshPro.text=$"x {maxObjects-currentObjects}"; // 将 "新的文本内容" 替换为您想要显示的文本
						}
						if(currentObjects>=maxObjects) {
							// 关闭种植模式 关闭地面碰撞器 关闭计分板 显示house按钮
							isWorking=false;
							Scoreboard.SetActive(false);
							hotBar.SetActive(false);
							nextBtn.SetActive(true);
							if(gameObject.TryGetComponent(out MeshCollider meshCollider)) {
								meshCollider.enabled=false;
							}
						}
						if(currentObjects<=maxObjects) {
							audioSource.volume=0.25f;
							audioSource.Play();
						}
					}
				}
			}
		}
	}
}
