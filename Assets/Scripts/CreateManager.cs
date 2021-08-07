using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateManager : MonoBehaviour
{

   

    public GameObject[] blockPrefabArray; // オブジェクトを格納する配列変数
    public bool create_DownObject_Flag = false; // DownObjectが作成されているか


    private GameObject objectCanvas; // Canvasオブジェクト格納用
    private GameObject objectDownObject; // Blockをまとめ、コントロール可能にする親オブジェクト格納用

    private bool set_Flag = false; // BlockがDownObjectにセットされているか
    //private bool DownObject_Flag = false;



    // Start is called before the first frame update
    void Start()
    {


        objectCanvas = GameObject.Find("Canvas");
        Create_Blocks();

        //objectDownObject = GameObject.Find("DownObject(Clone)");
        //Instantiate(blockPrefabArray[0], pos, rot, objectCanvas.transform); // オブジェクトを生成
    }

    // Update is called once per frame
    void Update()
    {

        //Debug.Log(objectDownObject);

        if (create_DownObject_Flag == true)
        {
            if (objectDownObject == null)
            {
                create_DownObject_Flag = false;
            }
        }
        
        Create_Blocks();

    }

    // Block生成S
    void Create_Blocks()
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


        if (create_DownObject_Flag == false)
        {
            //DownObject_Flag = true;


            Instantiate(blockPrefabArray[0], pos, rot, objectCanvas.transform); // オブジェクトを生成
            objectDownObject = GameObject.Find("DownObject(Clone)");


            create_DownObject_Flag = true;
            //Debug.Log(objectDownObject);


            if (create_DownObject_Flag == true)
            {
                int number = UnityEngine.Random.Range(1, 6);
                int number2 = UnityEngine.Random.Range(1, 6);

                Instantiate(blockPrefabArray[number], pos, rot, objectDownObject.transform); // オブジェクトを生成
                Instantiate(blockPrefabArray[number2], pos2, rot, objectDownObject.transform); // オブジェクトを生成
                set_Flag = true;
            }

            if (set_Flag == true)
            {
                objectDownObject.GetComponent<ControlManager>().enabled = true;
                set_Flag = false;
                
            }
        }




    }
}
