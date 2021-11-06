using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateManager : MonoBehaviour
{
    // 他スクリプト格納用
    private GameObject controlManager;
    private GameObject coordinateCalculationManager;

    private GameObject objectCanvas; // Canvasオブジェクト格納用
    private GameObject objectDownObject; // Blockをまとめ、コントロール可能にする親オブジェクト格納用

    private bool set_Flag = false; // BlockがDownObjectにセットされているか



    public GameObject[] blockPrefabArray; // Inspector上で紐付けたオブジェクトを格納している配列変数
    public bool create_DownObject_Flag = false; // DownObjectが作成されているか

    public bool cpl_Create = false;// 作成完了フラグ


    // Start is called before the first frame update
    void Start()
    {
        objectCanvas = GameObject.Find("Canvas");
        controlManager = GameObject.Find("ControlManager");
        coordinateCalculationManager = GameObject.Find("CoordinateCalculationManager");

        Create_Blocks();
    }



    // Block生成S
    public void Create_Blocks()
    {

        Vector3 pos = transform.position;
        Vector3 pos2 = transform.position;

        // 生成位置指定
        pos.x = 0.0f;
        pos.y = 7.0f;
        pos.z = 0.0f;
        pos2.x = 0.0f;
        pos2.y = 6.5f;
        pos2.z = 0.0f;

        Quaternion rot = Quaternion.Euler(0, 0, 0); // 角度のQuaternion化


        //Debug.Log("create_DownObject_Flag : " + create_DownObject_Flag);
        if (create_DownObject_Flag == false)
        {
            //DownObject_Flag = true;
            coordinateCalculationManager.GetComponent<CoordinateCalculationManager>().Clear_Block_Pos(); // 設置済みブロックの位置をクリア
            coordinateCalculationManager.GetComponent<CoordinateCalculationManager>().Set_Block_Pos(); // 設置済みブロックの位置をセット
            //Debug.Log("Set_Block_Pos() [CreateManager]");

            Instantiate(blockPrefabArray[0], pos, rot, objectCanvas.transform); // DownObjectを生成
            objectDownObject = GameObject.Find("DownObject(Clone)");


            create_DownObject_Flag = true;
            


            if (create_DownObject_Flag == true)
            {
                //Debug.Log("create_ChildBlocks");
                int number = UnityEngine.Random.Range(1, 6);
                int number2 = UnityEngine.Random.Range(1, 6);

                //Debug.Log("DownObject(Clone) : " + objectDownObject);


                GameObject obj = Instantiate(blockPrefabArray[number], pos, rot, objectDownObject.transform); // ブロックをランダム生成
                GameObject obj2 = Instantiate(blockPrefabArray[number2], pos2, rot, objectDownObject.transform);


                if (obj.gameObject.transform.parent != objectDownObject)
                {
                    //Debug.Log("not_parent");
                    //Debug.Log("objectDownObject.transform : " + objectDownObject.transform);
                    obj.transform.SetParent(objectDownObject.transform);
                }
                if (obj2.gameObject.transform.parent != objectDownObject)
                {
                    //Debug.Log("not_parent");
                    obj2.transform.SetParent(objectDownObject.transform);
                }



                set_Flag = true;
            }

            if (set_Flag == true)
            {
                //Debug.Log("ControlManager_Active");
                controlManager.GetComponent<ControlManager>().enabled = true;
                set_Flag = false;

                cpl_Create = true; // 作成完了フラグ
            }

            create_DownObject_Flag = false;
        }




    }
}
