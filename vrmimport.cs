using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Windows.Forms;
using VRM;

public class vrmimport : MonoBehaviour
{
    IEnumerator LoadVrmCoroutine(string path, Action<GameObject> onLoaded)
    {
        var www = new WWW(path);
        yield return www;
        VRMImporter.LoadVrmAsync(www.bytes, onLoaded);
    }

    void Start()
    {
      
    }

    public void onFileOpen()
    {
        OpenFileDialog ofDialog = new OpenFileDialog();

        // デフォルトのフォルダを指定する
        //ofDialog.InitialDirectory = @"A:";

        //ofDialog.FileName = "A:";
        ofDialog.FileName = "A:\\3Dmodel\\VRM\\AliciaSolid.vrm"; ;

        //csvファイルを開くことを指定する
        ofDialog.Filter = "vrmファイル|*.vrm";

        //ダイアログのタイトルを指定する
        ofDialog.Title = "VRMファイルを開け！！！！！";

        //ダイアログを表示する
        if (ofDialog.ShowDialog() == DialogResult.OK)
        {
            var path = ofDialog.FileName;

            StartCoroutine(LoadVrmCoroutine(path, go =>///VRM読み込む
            {
                go.transform.position = new Vector3(0, 0, 0);///位置指定

                var addAnimation = new AddAnimation();///Animator付ける（別スクリプト参照
                addAnimation.AddAnimationController(go);
            }));

            
        }
        else
        {
            Console.WriteLine("キャンセルされました");
        }

        // オブジェクトを破棄する
        ofDialog.Dispose();

        

        


    }


}
