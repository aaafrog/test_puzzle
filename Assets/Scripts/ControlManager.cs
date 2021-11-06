using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlManager : MonoBehaviour
{
    // 他スクリプト格納用
    private GameObject downObject;
    private GameObject downObjectDelete;
    private GameObject coordinateCalculationManager;

    //private float horizontalKey = 0.0f;
    private float create_Timer = 1.0f; // 落下秒数指定


    //private bool buttonEnabled = true; // 
    //private WaitForSeconds waitOneSecond = new WaitForSeconds(0.5f);

    // ボタン入力フラグ
    private bool go_Left = false; // 
    private bool go_Down = false; // 
    private bool go_Right = false; // 
    private bool go_Rotate = false; // 
    private bool onButton = false; // 

    // 回転数計算
    public int rotate_Count = 0; // 

    // Start is called before the first frame update
    void Start()
    {
        downObjectDelete = GameObject.Find("DownObjectDelete");
        coordinateCalculationManager = GameObject.Find("CoordinateCalculationManager");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        downObject = GameObject.Find("DownObject(Clone)");

        /////////////////////////////////////////////////////////
        ///
        ///         時間落下S　接地のとき止める
        /// 
        /////////////////////////////////////////////////////////


        if (downObjectDelete.GetComponent<DownObjectDelete>().go_Delete == false)
        {
            create_Timer -= Time.deltaTime; // 生成までカウントダウン

            if (create_Timer <= 0.0f)
            {
                downObject.transform.Translate(0, -0.5f, 0, Space.World);
                create_Timer = 1.0f;
            }
        }


        /////////////////////////////////////////////////////////
        ///
        ///         時間落下S
        /// 
        /////////////////////////////////////////////////////////


        StartCoroutine(Wait_MoveProcessing());


    } // FixedUpdate









    private IEnumerator Wait_MoveProcessing()
    {
        yield return StartCoroutine("MoveProcessing"); // MoveProcessingの終了を待つ

        onButton = false;
        //Debug.Log("Go_Create");


    }

    private IEnumerator MoveProcessing()
    {
        //Debug.Log("MoveProcessing");


        /////////////////////////////////////////////////////////
        ///
        ///         入力処理S
        /// 
        /////////////////////////////////////////////////////////



        //左右移動

        if (onButton == true)
        {

            if (Input.GetKeyDown(KeyCode.LeftArrow) || go_Left == true)
            {

                if (downObject.GetComponent<DownObjectManager>().left_Contact == false && coordinateCalculationManager.GetComponent<CoordinateCalculationManager>().left_Contact == false)
                {
                    downObject.transform.Translate(-0.5f, 0, 0, Space.World);
                    //buttonEnabled = false;  // ボタンを制限する
                    go_Left = false;

                }
            }






            if (Input.GetKeyDown(KeyCode.RightArrow) || go_Right == true)
            {
                if (downObject.GetComponent<DownObjectManager>().right_Contact == false && coordinateCalculationManager.GetComponent<CoordinateCalculationManager>().right_Contact == false)
                {
                    downObject.transform.Translate(0.5f, 0, 0, Space.World);
                    //buttonEnabled = false;  // ボタンを制限する
                    go_Right = false;

                }
            }




            //下移動
            if (Input.GetKeyDown(KeyCode.DownArrow) || go_Down == true)
            {
                downObject.transform.Translate(0, -0.5f, 0, Space.World);
                //buttonEnabled = false;  // ボタンを制限する
                go_Down = false;
            }

            //反時計回り回転
            if (Input.GetKeyDown(KeyCode.Space) || go_Rotate == true)
            {

                Debug.Log("left_Contact : " + downObject.GetComponent<DownObjectManager>().left_Contact);
                Debug.Log("right_Contact : " + downObject.GetComponent<DownObjectManager>().right_Contact);


                if (coordinateCalculationManager.GetComponent<CoordinateCalculationManager>().rotate_Imp == false)
                {
                    if (downObject.GetComponent<DownObjectManager>().left_Contact == true && rotate_Count == 0)
                    {
                        downObject.transform.Translate(0.5f, 0, 0, Space.World);

                    }
                    else if (downObject.GetComponent<DownObjectManager>().right_Contact == true && rotate_Count == 2)
                    {
                        downObject.transform.Translate(-0.5f, 0, 0, Space.World);

                    }

                    downObject.transform.Rotate(0, 0, -90.0f);
                    //buttonEnabled = false;  // ボタンを制限する                  


                }


                if (rotate_Count < 3)
                {
                    rotate_Count++;
                }
                else
                {
                    rotate_Count = 0;
                }
                Debug.Log("rotate_Count : " + rotate_Count);


                go_Rotate = false;


            }

            //Debug.Log("onButton : " + onButton);
            //onButton = false;

            //Debug.Log("onButton : " + onButton);

        }








        /////////////////////////////////////////////////////////
        ///
        ///         入力処理E
        /// 
        /////////////////////////////////////////////////////////


        yield return new WaitForSeconds(1f);

    }












    /////////////////////////////////////////////////////////
    ///
    ///         ボタン入力S
    /// 
    /////////////////////////////////////////////////////////

    public void OnLeftButton() // 左
    {
        if (onButton == false)
        {
            go_Left = true;
            onButton = true;
        }
    }

   
    public void OnDownButton() // 下
    {
        if (onButton == false)
        {
            if (downObjectDelete.GetComponent<DownObjectDelete>().go_Delete == false)
            {
                go_Down = true;
                onButton = true;
            }
        }
    }

   
    public void OnRightButton() // 右
    {
        if (onButton == false)
        {
            go_Right = true;
            onButton = true;
        }
    }

   
    public void OnRotateButton() // 回転
    {
        if (onButton == false)
        {
            go_Rotate = true;
            onButton = true;
        }
    }

    /////////////////////////////////////////////////////////
    ///
    ///         ボタン入力E
    /// 
    /////////////////////////////////////////////////////////





}
