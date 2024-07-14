using UnityEngine;
using UnityEngine.UI;

public class DeepLinkHandler : MonoBehaviour
{
    public Text deepLinkText;
    public GameObject openOnDeeplink;
    private void Start()
    {
        deepLinkText.text = "App opened without deep link";
        openOnDeeplink.SetActive(false);
        // 訂閱 deepLinkActivated 事件
        Application.deepLinkActivated += OnDeepLinkActivated;


        // 如果應用程序是通過 deep link 打開的，當前 URL 可以在啟動時獲取
        if (!string.IsNullOrEmpty(Application.absoluteURL))
        {
            OnDeepLinkActivated(Application.absoluteURL);
        }
    }

    private void OnDeepLinkActivated(string url)
    {
        // 處理 deep link URL
        Debug.Log("App opened with deep link: " + url);
        deepLinkText.text = "App opened with deep link: " + url;
        openOnDeeplink.SetActive(true);
        
        // 在這裡解析 URL 並執行相應的邏輯
        // 例如，提取參數並根據參數執行不同的操作
    }

    private void OnDestroy()
    {
        // 取消訂閱 deepLinkActivated 事件
        Application.deepLinkActivated -= OnDeepLinkActivated;
    }
}
