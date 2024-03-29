using UnityEngine;

public class GameOvering : MonoBehaviour
{
    public GameObject GameOverBtn;
    public GameObject PinkCloud;
    public GameObject LowPoly;
    public GameObject RestartBtn;
    private readonly float targetScale = 0.8f; // 目标缩放比例
    public float scaleDuration = 2f; // 缩放持续时间
    public float rotateSpeed = 24f; // 自转速度，一周360度需要15秒
    public bool isEnding = false; // 是否正在缩小
    private Vector3 originalScale; // 初始大小
    private float currentScaleTime = 0f; // 当前已经缩放的时间
    void Start()
    {
        originalScale = transform.localScale; // 保存初始大小
    }
    public void ShowGame()
    {
        // 关闭按钮 关闭云彩碰撞器
        GameOverBtn.SetActive(false);
        RestartBtn.SetActive(true);
        
        if (PinkCloud.TryGetComponent(out MeshCollider meshCollider))
        {
            meshCollider.enabled = false;
        }
        // 开启展示 播放音频 慢慢缩小0.9倍 然后15秒自转一周
        //TODO 播放音频
        if(LowPoly.TryGetComponent(out GameOvering gameO))
        {
            gameO.isEnding = true;
        }
    }
    void Update()
    {
        if (isEnding)
        {
            if (currentScaleTime < scaleDuration)
            {
                currentScaleTime += Time.deltaTime;
                float t = currentScaleTime / scaleDuration;
                transform.localScale = originalScale * Mathf.Lerp(1f, targetScale, t); // 使用插值函数实现缩放效果
            }
            else
            {
                // 自转
                transform.Rotate(Vector3.up, rotateSpeed * Time.deltaTime);
            }
        }
    }
}
