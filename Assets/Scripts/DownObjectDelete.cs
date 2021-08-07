using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DownObjectDelete : MonoBehaviour
{
    public bool go_Delete = false;

    private GameObject objectDownObject;
    private GameObject connectCheckManager;
    private GameObject blockManager;
    private GameObject createManager;
    private GameObject[] ChildObject;
    private GameObject objectCanvas;
    private int childCount;


    // Start is called before the first frame update
    void Start()
    {
        objectCanvas = GameObject.Find("Canvas");
        connectCheckManager = GameObject.Find("ConnectCheckManager");
    }

    // Update is called once per frame
    public void Delete()
    {
        //DeleteTargetObj という名前のオブジェクトを取得
        objectDownObject = GameObject.Find("DownObject(Clone)");
        createManager = GameObject.Find("CreateManager");
        blockManager = GameObject.Find("BlockManager");

        //Debug.Log("衝突");


        // DownObjectとの衝突判定
        if (go_Delete == true)
        {
            //Debug.Log("DownObject衝突");


            //GetChildren(objectDownObject.gameObject);

            //objectDownObject.gameObject.transform.parent = null;
            //objectDownObject.transform.DetachChildren();


            ChildObject = new GameObject[objectDownObject.transform.childCount];
            childCount = objectDownObject.transform.childCount;
            //Debug.Log("ChildObject:" + ChildObject);
            //Debug.Log("childCount1:" + childCount);

            for (int i = childCount - 1; i > -1; i--)
            {
                ChildObject[i] = objectDownObject.transform.GetChild(i).gameObject;
                //Debug.Log(ChildObject[i].name);
                ChildObject[i].transform.parent = objectCanvas.transform;

                //Debug.Log(i);

                if (i == 0)
                {
                    // 指定したオブジェクトを削除
                    Destroy(objectDownObject);
                    go_Delete = false;

                    if (createManager.GetComponent<CreateManager>().create_DownObject_Flag == true)
                    {


                        // タグが同じオブジェクトを全て取得する
                        GameObject[] targetBox = GameObject.FindGameObjectsWithTag("Block");

                        foreach (GameObject gameObj in targetBox)
                        {
                            gameObj.GetComponent<BlockContactManager>().enabled = true;
                            gameObj.GetComponent<BlockManager>().block_pox_x = Mathf.RoundToInt(gameObj.transform.position.x * 10.0f) / 10.0f;
                            gameObj.GetComponent<BlockManager>().block_pox_y = Mathf.RoundToInt(gameObj.transform.position.y * 10.0f) / 10.0f;
                        }


                        //string[] boxTagArray = { "Block", "Green", "Blue", "Orange", "Red", "Yellow" };

                        //foreach (string boxTag in boxTagArray)
                        //{

                        //    // タグが同じオブジェクトを全て取得する
                        //    GameObject[] targetBox = GameObject.FindGameObjectsWithTag(boxTag);

                        //    foreach (GameObject gameObj in targetBox)
                        //    {
                        //        gameObj.GetComponent<BlockContactManager>().enabled = true;
                        //    }

                        //}
                    }



                }
            }
            connectCheckManager.GetComponent<ConnectCheckManager>().go_Check = true;
        }
    }




}
