using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

/// <summary>  
/// 使用鼠标（像QQ截图一样）自由截取Unity程序中的任意地方 and 获取本地文件夹下的所有图片  
/// </summary> 
public class ScreenShot : MonoBehaviour {

    string localPath;
    WWW www;
    Rect rect;
    float time;
    Vector2 pos1;
    Vector2 pos2;
    // 用来显示存放截图的  
    public Material image;
    // 用来显示从文件夹中获取的  
    public Material image1;
    // Use this for initialization  
    void Start()
    {

    }

    // Update is called once per frame  
    void Update()
    {
        //点击鼠标左键，记录第一个位置    
        if (Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1))
        {
            pos1 = Input.mousePosition;
            Debug.Log(pos1);
        }
        //放开左键记录第二个位置    
        if (Input.GetMouseButtonUp(0) || Input.GetMouseButtonUp(1))
        {
            pos2 = Input.mousePosition;
            Debug.Log(pos2);

            if (pos1.x != pos2.x || pos1.y != pos2.y && (Mathf.Abs((int)(pos1.y - pos2.y)) <= Screen.height || Mathf.Abs((int)(pos1.x - pos2.x)) <= Screen.width))
                StartCoroutine(GetCapture());
        }
    }

    void OnGUI()
    {
        if (rect != null)
        {
            GUI.Button(new Rect(0, 200, 250, 50), rect.ToString());
        }
    }

    IEnumerator GetCapture()
    {
        yield return new WaitForEndOfFrame();

        // 屏幕左下角为 0,0 坐标，取 pos1 和 pos2 的小值确定左下角坐标（共 4 种情况）  
        rect = new Rect(pos1.x < pos2.x ? Mathf.Abs((int)pos1.x) : Mathf.Abs((int)pos2.x), pos1.y < pos2.y ? Mathf.Abs((int)pos1.y) : Mathf.Abs((int)pos2.y),
            Mathf.Abs((int)(pos1.x - pos2.x)), Mathf.Abs((int)(pos1.y - pos2.y))); // 取两点各自 x 、y 插值的绝对值做长和宽  

        //int width = Screen.width;  
        //int height = Screen.height;  全屏  

        // 根据鼠标截图的范围来制作贴图  
        Texture2D tex = new Texture2D(Mathf.Abs((int)(pos1.x - pos2.x)), Mathf.Abs((int)(pos1.y - pos2.y)), TextureFormat.RGB24, false);

        tex.ReadPixels(rect, 0, 0, true);

        byte[] imagebytes = tex.EncodeToPNG();// 将Texture2D转化为png图  

        tex.Compress(false);//对屏幕缓存进行压缩  

        image.mainTexture = tex;//对屏幕缓存进行显示（缩略图）  

        // 以上是截图显示  
        // 下面是存储图片并且加载  

        #region// ---------------------------------笨方法获取本地文件夹路径 ------------------------------------  
        //string strpath = Application.dataPath; // 获取到的是 Asets 文件夹的路径  
        //string[] spath = strpath.Split(new char[] { '/' });  
        string path = "";
        //for(int i = 0; i < spath.Length - 1; i++)  
        //{  
        //  path += spath[i] + "/";  
        //}  
        //print("path" + path + "     length      " + spath.Length);  
        #endregion


        #region -----------直接获取本地文件路径！-----------------------  
        path = System.Environment.CurrentDirectory + @"\";
        print("这是什么？直接获取本地文件路径！靠谱------" + System.Environment.CurrentDirectory + "-------靠谱！");
        #endregion


        // ------------------------------------创建文件夹(和 Asets 目录同级)-------------------------------------------  
        Directory.CreateDirectory(path + "YouCreat");
        // +++++++++++++++++++++++++++++++++++ 存储成 png 图在 Asets 同级的文件夹 YouCreat 里 ++++++++++++++++++++++++++++++++++++  
        File.WriteAllBytes(path + "YouCreat/screencapture.png", imagebytes);


        // -----------------------------WWW 加载 本地图片 ------------------------------------------  
        localPath = "file://" + path + @"YouCreat\screencapture.png";
        www = new WWW(localPath);
        yield return www;
        // 显示它  
        image1.mainTexture = www.texture;
        if (www.error != null)
        {
            Debug.Log(www.error);
        }

        // -----------------------------获取文件夹下子文件名(这里指和 Asets 同级的文件)-----------------------------------  
        DirectoryInfo dir = new DirectoryInfo(path + @"YouCreat\");
        FileInfo[] files = dir.GetFiles(); //获取所有文件信息  
        string til = string.Format("{0} 该目录下的所有文件： ", path + @"YouCreat\");
        print(til);
        foreach (FileInfo file in files)
        {
            print(file.Name);
        }
    }
}