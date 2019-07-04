using System.Collections;
using UnityEngine;

public class ScreenShotTest : MonoBehaviour
{
    public Camera renderCamera;
    public GameObject uiCanvas;

    private void Start() { }

    private void Update()
    {
        //TODO测试
        if (Input.GetKeyUp(KeyCode.Q))
        {
            Debug.Log("自带截图1");
            uiCanvas.SetActive(false);
            ScreenTool.Instance.ScreenShotFile(GetFilePath());
        }
        if (Input.GetKeyUp(KeyCode.W))
        {
            Debug.Log("自带截图2");
            uiCanvas.SetActive(false);
            StartCoroutine(ScreenTool.Instance.ScreenShotTex(GetFilePath(), Callback));
        }
        if (Input.GetKeyUp(KeyCode.E))
        {
            Debug.Log("普通截图");
            uiCanvas.SetActive(false);
            StartCoroutine(ScreenTool.Instance.ScreenCapture(new Rect(0, 0, 1920, 1080), GetFilePath(), Callback));
        }
        if (Input.GetKeyUp(KeyCode.R))
        {
            Debug.Log("相机截图");
            ScreenTool.Instance.CameraCapture(renderCamera, new Rect(0, 0, 1920, 1080), GetFilePath());
        }
    }
    /// <summary>
    /// 获取文件完整路径
    /// </summary>
    /// <returns></returns>
    public string GetFilePath()
    {
        return Application.dataPath + "/截图" + Random.Range(0, 10000) + ".png";
    }
    public void Callback()
    {
        uiCanvas.SetActive(true);
    }
}