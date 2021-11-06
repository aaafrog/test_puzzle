using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DownObjectDelete : MonoBehaviour
{
    public bool go_Delete = false;

    private GameObject objectDownObject;
    private GameObject connectCheckManager;
    private GameObject blockManager;
    private GameObject coordinateCalculationManager;
    private GameObject createManager;
    private GameObject[] ChildObject;
    private GameObject objectCanvas;

    private int childCount;


    // Start is called before the first frame update
    void Start()
    {
        objectCanvas = GameObject.Find("Canvas");
        connectCheckManager = GameObject.Find("ConnectCheckManager");
        coordinateCalculationManager = GameObject.Find("CoordinateCalculationManager");

    }




    ////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /////
    /////        落下中のブロックが接地した時の処理。
    /////        coordinateCalculationManagerのBlock_Landing()から呼び出す
    /////        DownObject(Clone)を破棄し、子ObjectをCanvasに移動
    /////        coordinateCalculationManagerを有効にし、位置情報を再入力後、連結チェック処理を有効にする
    /////
    ////////////////////////////////////////////////////////////////////////////////////////////////////////////

    public void Delete()
    {
        objectDownObject = GameObject.Find("DownObject(Clone)");
        createManager = GameObject.Find("CreateManager");
        blockManager = GameObject.Find("BlockManager");


        //Debug.Log("Delete");
        //Debug.Log("go_Delete : " + go_Delete);


        // DownObjectとの衝突判定
        // go_DeleteはcoordinateCalculationManagerのBlock_Landing()でtrueに変更
        if (go_Delete == true)
        {
            go_Delete = false;
            //Debug.Log("objectDownObject : " + objectDownObject);
            //GetChildren(objectDownObject.gameObject);
            //objectDownObject.gameObject.transform.parent = null;
            //objectDownObject.transform.DetachChildren();


            ChildObject = new GameObject[objectDownObject.transform.childCount]; // 落下中ブロックの各ブロックのGameObjectを配列に格納
            childCount = objectDownObject.transform.childCount; // 落下中ブロックのブロック数
            //Debug.Log("ChildObject:" + ChildObject);
            //Debug.Log("childCount1:" + childCount);

            for (int i = childCount - 1; i > -1; i--)
            {
                if (i >= 0)
                {
                    //Debug.Log(i);
                    ChildObject[i] = objectDownObject.transform.GetChild(i).gameObject; // 落下中ブロックの各ブロックのGameObjectを配列に格納
                    //Debug.Log(ChildObject[i].name);
                    ChildObject[i].transform.parent = objectCanvas.transform;
                }

                if (i == 0)
                {
                    //Debug.Log("Destroy" + i);
                    //Destroy(objectDownObject); // DownObject(Clone)オブジェクトを削除
                    //Debug.Log("objectDownObject[DownObjectDelete] : " + objectDownObject);

                    //if (objectDownObject == null)
                    //{
                    //    Debug.Log("objectDownObject == null");
                    //    if (createManager.GetComponent<CreateManager>().cpl_Create == false)
                    //    {
                    //        Debug.Log("Create_Blocks[DownObjectDelete]");
                    //        //createManager.GetComponent<CreateManager>().go_Create = false;
                    //        createManager.GetComponent<CreateManager>().Create_Blocks();
                    //    }
                    //}
                    StartCoroutine("Go_Create");

                }

            } // for

            // 落下ブロックの処理終了後に、ブロックの連結をチェックする
            connectCheckManager.GetComponent<ConnectCheckManager>().go_Check = true;



            coordinateCalculationManager.GetComponent<CoordinateCalculationManager>().landing = false;

        } // if
    }


    private IEnumerator Go_Create()
    {
        yield return StartCoroutine("DestroyObj"); // DownObject(Clone)オブジェクトの削除を待つ

        //Debug.Log("Go_Create");

        if (objectDownObject == null)
        {
            //Debug.Log("objectDownObject == null");
            if (createManager.GetComponent<CreateManager>().cpl_Create == false)
            {
                //Debug.Log("Create_Blocks[DownObjectDelete]");
                //createManager.GetComponent<CreateManager>().go_Create = false;
                createManager.GetComponent<CreateManager>().Create_Blocks();
            }
        }

    }

    private IEnumerator DestroyObj()
    {
        //Debug.Log("DestroyObj");
        Destroy(objectDownObject); // DownObject(Clone)オブジェクトを削除
        yield return new WaitForSeconds(0);

    }


}
