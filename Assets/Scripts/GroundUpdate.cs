using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.LowLevel;
using TouchPhase = UnityEngine.InputSystem.TouchPhase;
using Touch = UnityEngine.InputSystem.EnhancedTouch.Touch;
using Unity.PolySpatial.InputDevices;
using TMPro;
public class GroundUpdate : MonoBehaviour
{
    public GameObject[] flowers; // 通过Inspector面板关联三个物体
    public AudioSource audioSource;
    public GameObject Scoreboard;
    public TMP_Text textMeshPro;
    public GameObject houseBtn;
    public bool isGrassMode = false;
    public int maxFlowers = 10;
    private int flowersNum = 0;
    private void Start()
    {
        if (textMeshPro != null)
        {
            // 修改 TextMeshPro 的文本内容
            textMeshPro.text = $"x {maxFlowers - flowersNum}"; // 将 "新的文本内容" 替换为您想要显示的文本
        }
    }
    void Update()
    {
        if (!isGrassMode) return;
        var activeTouches = Touch.activeTouches;
        if (activeTouches.Count > 0)
        {
            var primaryTouchPhase = activeTouches[0].phase;
            var primaryTouchData = EnhancedSpatialPointerSupport.GetPointerState(activeTouches[0]);
            if (primaryTouchPhase == TouchPhase.Began)
            {
                var buttonObject = primaryTouchData.targetObject;
                if (buttonObject != null)
                {
                    if (buttonObject == gameObject)
                    {
                        Vector3 sourcePosition = primaryTouchData.interactionPosition; // 起始位置
                        int randomIndex = Random.Range(0, flowers.Length); // 生成一个范围在0到objects.Length之间的随机整数
                        GameObject selectedObject = flowers[randomIndex]; // 根据随机数选择对应的物体
                        GameObject copiedObject = Instantiate(selectedObject);
                        // 将复制的对象放置在目标位置
                        copiedObject.transform.position = sourcePosition;
                        copiedObject.transform.localScale *= 0.3f;
                        copiedObject.SetActive(true);
                        // 将复制的对象放置在目标位置的父级下
                        copiedObject.transform.parent = gameObject.transform.parent; 
                        flowersNum += 1;
                        if (textMeshPro != null)
                        {
                            // 修改 TextMeshPro 的文本内容
                            textMeshPro.text = $"x {maxFlowers - flowersNum}"; // 将 "新的文本内容" 替换为您想要显示的文本
                        }
                        if (flowersNum >= maxFlowers)
                        {
                            // 关闭种植模式 关闭地面碰撞器 关闭计分板 显示house按钮
                            isGrassMode = false;
                            if (gameObject.TryGetComponent(out MeshCollider meshCollider))
                            {
                                Scoreboard.SetActive(false);
                                meshCollider.enabled = false;
                                houseBtn.SetActive(true);
                            }
                        }
                        if (flowersNum <= maxFlowers)
                        {
                            audioSource.volume = 0.25f;
                            audioSource.Play();
                        }
                    }
                }
            }
        }
    }
}
