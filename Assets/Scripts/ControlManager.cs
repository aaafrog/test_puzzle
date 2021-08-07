using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlManager : MonoBehaviour
{
    private GameObject downObjectDelete;

    private float horizontalKey = 0.0f;
    private float create_Timer = 1.0f;
    private bool left_Contact = false; // 
    private bool right_Contact = false; // 

    private bool buttonEnabled = true;
    private WaitForSeconds waitOneSecond = new WaitForSeconds(0.5f);

    // Start is called before the first frame update
    void Start()
    {
        downObjectDelete = GameObject.Find("DownObjectDelete");
    }

    // Update is called once per frame
    void Update()
    {

        if (downObjectDelete.GetComponent<DownObjectDelete>().go_Delete == false)
        {

            /////////////////////////////////////////////////////////
            ///
            ///         時間落下S
            /// 
            /////////////////////////////////////////////////////////

            create_Timer -= Time.deltaTime; // 生成までカウントダウン


            if (create_Timer <= 0.0f)
            {
                transform.Translate(0, -0.5f, 0, Space.World);
                create_Timer = 1.0f;
            }

            /////////////////////////////////////////////////////////
            ///
            ///         時間落下S
            /// 
            /////////////////////////////////////////////////////////




            /////////////////////////////////////////////////////////
            ///
            ///         入力処理S
            /// 
            /////////////////////////////////////////////////////////



            // 制限中は動作させない
            if (buttonEnabled == false)
            {
                //Debug.Log("buttonEnabled : " + buttonEnabled);
                return;
            }

            // 制限されていない場合
            else
            {
                //Debug.Log("buttonEnabled : " + buttonEnabled);
                //左右移動

                if (Input.GetKeyDown(KeyCode.LeftArrow))
                {
                    if (left_Contact == false)
                    {
                        horizontalKey = -0.5f;
                        buttonEnabled = false;  // ボタンを制限する
                    }
                }
                if (Input.GetKeyDown(KeyCode.RightArrow))
                {
                    if (right_Contact == false)
                    {
                        horizontalKey = 0.5f;
                        buttonEnabled = false;  // ボタンを制限する
                    }
                }

                if (horizontalKey != 0.0f)
                {
                    transform.Translate(horizontalKey, 0, 0, Space.World);
                    horizontalKey = 0.0f;
                    buttonEnabled = false;  // ボタンを制限する
                }


                //下移動
                if (Input.GetKeyDown(KeyCode.DownArrow))
                {
                    transform.Translate(0, -0.5f, 0, Space.World);
                    buttonEnabled = false;  // ボタンを制限する
                }

                //右回転
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    transform.Rotate(0, 0, -90.0f);
                    buttonEnabled = false;  // ボタンを制限する
                }




                // 一定時間経過後に解除
                StartCoroutine(EnableButton());
            }





            /////////////////////////////////////////////////////////
            ///
            ///         入力処理E
            /// 
            /////////////////////////////////////////////////////////
        }


    }





    // ボタンの制限を解除するコルーチン
    private IEnumerator EnableButton()
    {
        // 1秒後に解除         
        yield return waitOneSecond;
        buttonEnabled = true;
    }




    // 衝突判定
    void OnTriggerEnter2D(Collider2D col)
    {

        // DownObjectとの衝突判定
        if (col.gameObject.name == "WallLeft")
        {
            left_Contact = true;
        }

        // DownObjectとの衝突判定
        if (col.gameObject.name == "WallRight")
        {
            right_Contact = true;
        }

    }

    // 衝突判定
    void OnTriggerExit2D(Collider2D col)
    {

        // DownObjectとの衝突判定
        if (col.gameObject.name == "WallLeft")
        {
            left_Contact = false;
        }

        // DownObjectとの衝突判定
        if (col.gameObject.name == "WallRight")
        {
            right_Contact = false;
        }

    }

}
