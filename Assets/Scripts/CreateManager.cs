using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateManager : MonoBehaviour
{

   

    public GameObject[] blockPrefabArray; //オブジェクトを格納する配列変数


    private GameObject objectCanvas;
    private GameObject objectDownObject;

    private bool set_Flag = false;
    private bool create_Box_Flag = false;

    private float create_Timer = 1.0f;




    // Start is called before the first frame update
    void Start()
    {
        Vector3 pos = transform.position;

        // 生成位置指定
        pos.x = 0.0f;
        pos.y = 7.0f;
        pos.z = 0.0f;

        Quaternion rot = Quaternion.Euler(0, 0, 0); // 角度のQuaternion化

        objectCanvas = GameObject.Find("Canvas");

        Instantiate(blockPrefabArray[0], pos, rot, objectCanvas.transform); // オブジェクトを生成
    }

    // Update is called once per frame
    void Update()
    {

        Debug.Log(objectDownObject);


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


        /////////////////////////////////////////////////////////
        ///
        ///         block生成S
        /// 
        /////////////////////////////////////////////////////////




        create_Timer -= Time.deltaTime; // 生成までカウントダウン

        if (create_Timer <= 0.0f)
        {
            objectDownObject = GameObject.Find("DownObject(Clone)");

            
            Instantiate(blockPrefabArray[0], pos, rot, objectCanvas.transform); // オブジェクトを生成

            create_Timer = 15.0f;
            Debug.Log("create_Timer = " + create_Timer);
            create_Box_Flag = true;
        }

        if (create_Box_Flag == true)
        {
            int number = UnityEngine.Random.Range(1, 5);
            int number2 = UnityEngine.Random.Range(1, 5);

            Instantiate(blockPrefabArray[number], pos, rot, objectDownObject.transform); // オブジェクトを生成
            Instantiate(blockPrefabArray[number2], pos2, rot, objectDownObject.transform); // オブジェクトを生成
            set_Flag = true;
        }

        if (set_Flag == true)
        {
            objectDownObject.GetComponent<ControlManager>().enabled = true;
            set_Flag = false;
            create_Box_Flag = false;
        }


        /////////////////////////////////////////////////////////
        ///
        ///         block生成S
        /// 
        /////////////////////////////////////////////////////////


    }
}
