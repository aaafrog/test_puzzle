using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallContactManager : MonoBehaviour
{
    private GameObject downObjectDelete;


    // Use this for initialization
    void Start()
    {
        downObjectDelete = GameObject.Find("DownObjectDelete");
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    // BottomWall衝突判定
    void OnTriggerEnter2D(Collider2D col)
    {
        downObjectDelete.GetComponent<DownObjectDelete>().go_Delete = true;
        downObjectDelete.GetComponent<DownObjectDelete>().Delete();
    }


    //void GetChildren(GameObject obj)
    //{

    //    //Transform children = obj.GetComponentInChildren<Transform>();
    //    ////子要素がいなければ終了
    //    //if (children.childCount == 0)
    //    //{
    //    //    return;
    //    //}
    //    //foreach (Transform ob in children)
    //    //{
    //    //    //ここに何かしらの処理
    //    //    //例　ボーンについてる武器を取得する
    //    //    //if (ob.name == "Right Hand")
    //    //    //  {
    //    //    //      rightHandWeapon = ob.transform.GetChild(0).gameObject;
    //    //    //   }
    //    //    GetChildren(ob.gameObject);

    //    //}
    //}

}
