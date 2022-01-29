using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ScreenShotTest : MonoBehaviour
{
    public Camera renderCamera;
    public GameObject uiCanvas;

    public RawImage showImage;

    /// <summary>
    /// 获取文件完整路径
    /// </summary>
    /// <returns></returns>
    private string GetFilePath()
    {
        return Application.dataPath + "/截图" + Random.Range(0, 10000) + ".png";
    }
    
    /// <summary>
    /// 显示UI
    /// </summary>
    private void Callback()
    {
        uiCanvas.SetActive(true);
    }

    /// <summary>
    /// 自带截图
    /// </summary>
    public void TakeScreenshots1()
    {
        Debug.Log("自带截图1");
        uiCanvas.SetActive(false);
        ScreenTool.Instance.ScreenShotFile(GetFilePath(),Callback);
    }
    
    /// <summary>
    /// 自带截图
    /// </summary>
    public void TakeScreenshots2()
    {
        Debug.Log("自带截图2");
        uiCanvas.SetActive(false);
        StartCoroutine(ScreenTool.Instance.ScreenShotTex(GetFilePath(), Callback));
    }

    /// <summary>
    /// 普通截图
    /// </summary>
    public void OrdinaryScreenshots()
    {
        Debug.Log("普通截图");
        uiCanvas.SetActive(false);
        StartCoroutine(ScreenTool.Instance.ScreenCapture(new Rect(0, 0, 1920, 1080), GetFilePath(), Callback));
    }
    
    /// <summary>
    /// 相机截图
    /// </summary>
    public void CameraCapture()
    {
        Debug.Log("相机截图");
        showImage.texture = ScreenTool.Instance.CameraCapture(renderCamera, new Rect(0, 0, 1920, 1080), GetFilePath());
    }
    
}