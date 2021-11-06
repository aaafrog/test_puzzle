using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.Linq;
using System.Globalization;

public class ConnectCheckManager : MonoBehaviour
{
    public bool go_Check = false;

    private GameObject scoreManager;

    private GameObject[] targetBlocks;

    private GameObject[] connect_Obj_ary;
    private BlockManager.COLOR_TYPE[] connect_Color_ary;
    private BlockManager.COLOR_TYPE check_Connect_before;

    private float start_Pos_x = -2.0f;
    private float start_Pos_y = -3.0f;
    private float end_Pos_x = 2.0f;
    private float end_Pos_y = 3.5f;
    private int max_x = 9;
    private int max_y = 12;
    private int connect_Count = 0;
    private int DELETE_COUNT = 2;
    //private float check_Pos_x;
    //private float check_Pos_y;

    private bool checkd_x = false;


    private float check_Rows_Columns_Pos;
    private float start_Cell_Pos;
    private float now_Obj_Rows_Columns_Pos;
    private float now_Obj_Cell_Pos;
    private float check_Cell_Pos;
    private int max_Rows_Columns;
    private int max_Cells;

    // Start is called before the first frame update
    void Start()
    {
        scoreManager = GameObject.Find("Score");
        connect_Obj_ary = new GameObject[max_x];
        connect_Color_ary = new BlockManager.COLOR_TYPE[max_x];
    }



    // Update is called once per frame
    void Update() 
    {

        if (go_Check == true)
        {

            Check_Block();

            go_Check = false;
        }


    }// Update


    void Check_Block() {


        targetBlocks = GameObject.FindGameObjectsWithTag("Block");


        ////////////////////////////////////////////////////////////////


        // 行と列を1回ずつ調べるためのループ
        for (int k = 0; k < 2; k++)
        {
            // 行が未チェックのときは行を、チェック済みのときは列をチェックするための値を代入
            if (checkd_x == false)
            {
                max_Rows_Columns = max_y;
                max_Cells = max_x;
                check_Rows_Columns_Pos = start_Pos_y;
                start_Cell_Pos = start_Pos_x;
            }
            else
            {
                max_Rows_Columns = max_x;
                max_Cells = max_y;
                check_Rows_Columns_Pos = start_Pos_x;
                start_Cell_Pos = start_Pos_y;
            }
            //Debug.Log("checkd_x = " + checkd_x + " max_Rows_Columns : " + max_Rows_Columns + " check_Rows_Columns_Pos : " + check_Rows_Columns_Pos + " start_Cell_Pos : " + start_Cell_Pos);


            // 行列を最大数まで調べるためのループ
            for (int j = 0; j < max_Rows_Columns; j++)
            {
                // gameObjに代入されたGameObjectを、左から順に配列に追加
                foreach (GameObject gameObj in targetBlocks)
                {
                    // 行が未チェックのときは行を、チェック済みのときは列をチェックするための値を代入
                    if (checkd_x == false)
                    {
                        now_Obj_Rows_Columns_Pos = gameObj.GetComponent<BlockManager>().block_pos_y;
                        now_Obj_Cell_Pos = gameObj.GetComponent<BlockManager>().block_pos_x;
                    }
                    else
                    {
                        now_Obj_Rows_Columns_Pos = gameObj.GetComponent<BlockManager>().block_pos_x;
                        now_Obj_Cell_Pos = gameObj.GetComponent<BlockManager>().block_pos_y;
                    }

                    // マスの開始位置
                    check_Cell_Pos = start_Cell_Pos;

                    //Debug.Log("gameObj" + list_No + " : " + gameObj);

                    // カウントアップの度に位置情報を変え、gameObjが所定の位置にあったとき、配列のi番目に追加
                    for (int i = 0; i <= connect_Color_ary.Length; i++)
                    {
                        // 行列とマスが指定の値と一致した場合、配列に追加
                        if (check_Cell_Pos == now_Obj_Cell_Pos && check_Rows_Columns_Pos == now_Obj_Rows_Columns_Pos)
                        {
                            connect_Color_ary[i] = gameObj.GetComponent<BlockManager>().Color;
                            connect_Obj_ary[i] = gameObj;
                            //Debug.Log("connect_List" + i + " : " + connect_Color_ary[i]);
                        }
                        check_Cell_Pos = check_Cell_Pos + 0.5f; // マスを1マス分移動
                    }

                } // foreach (GameObject gameObj in targetBlocks)


                //////// 配列確認Debug ////////
                //int n = 0;
                //foreach (var ar_val in connect_Color_ary)
                //{
                //    Debug.Log("check_Pos_y" + check_Pos_y + "Value" + n + " : " + ar_val);
                //    n++;
                //}
                //////// 配列確認Debug ////////

                Delete_Block();

                // 位置が一致したブロック情報を格納した配列に、最大マス数の新規配列を代入し、リセット
                connect_Color_ary = new BlockManager.COLOR_TYPE[max_Cells];
                connect_Obj_ary = new GameObject[max_Cells];

                //Debug.Log("connect_Color_ary" + j + " = " + connect_Color_ary.Length);

                check_Rows_Columns_Pos = check_Rows_Columns_Pos + 0.5f; // 行列を1マス分移動

            } // for (int j = 0; j < max_Rows_Columns; j++)


            // 行がチェック済みになったら、列チェックをオン、終了したらオフ
            if (checkd_x == false)
            {
                checkd_x = true;
            }
            else
            {
                checkd_x = false;
            }
            //Debug.Log("last_checkd_x" + k + " = " + checkd_x);
        }


        ////////////////////////////////////////////////////////////////






        //check_Pos_y = start_Pos_y; // ★★★★★★★　xとyを逆転させる　行列の開始位置

        //for (int j = 0; j < max_y; j++)
        //{
        //    // gameObjに代入されたGameObjectを、左から順に配列に追加
        //    foreach (GameObject gameObj in targetBlocks)
        //    {
        //        check_Pos_x = start_Pos_x; // ★★★★★★★　xとyを逆転させる　マスの開始位置

        //        //Debug.Log("gameObj" + list_No + " : " + gameObj);

        //        // カウントアップの度に位置情報を変え、gameObjが所定の位置にあったとき、配列のi番目に追加
        //        for (int i = 0; i <= connect_Color_ary.Length; i++)
        //        {
        //            // gameObjの行列とマスが指定位置と一致したとき、配列に追加 // ★★★★★★★
        //            if (check_Pos_x == gameObj.GetComponent<BlockManager>().block_pos_x && check_Pos_y == gameObj.GetComponent<BlockManager>().block_pos_y) // ★★★★★★★　xとyを逆転させる
        //            {
        //                connect_Color_ary[i] = gameObj.GetComponent<BlockManager>().Color;
        //                connect_Obj_ary[i] = gameObj;
        //                //Debug.Log("connect_List" + i + " : " + connect_Color_ary[i]);

        //            }
        //            check_Pos_x = check_Pos_x + 0.5f; // check_Pos_xを右へ1マス分移動 // ★★★★★★★　xとyを逆転させる
        //        }

        //    } // foreach (GameObject gameObj in targetBlocks)

        //    //////// 配列確認Debug ////////
        //    //int n = 0;
        //    //foreach (var ar_val in connect_Color_ary)
        //    //{
        //    //    Debug.Log("check_Pos_y" + check_Pos_y + "Value" + n + " : " + ar_val); // ★★★★★★★
        //    //    n++;
        //    //}
        //    //////// 配列確認Debug ////////

        //    Delete_Block();

        //    connect_Color_ary = new BlockManager.COLOR_TYPE[11];
        //    connect_Obj_ary = new GameObject[11];

        //    //check_Pos_x = start_Pos_x; // ★★★★★★★
        //    check_Pos_y = check_Pos_y + 0.5f; // check_Pos_xを右へ1マス分移動 // ★★★★★★★
        //                                      //Debug.Log("check_Pos_y" + j + " : " + check_Pos_y); // ★★★★★★★
        //}




    }

    void Delete_Block()
    {

        List<int> delete_Blocks = new List<int>();
        var uniqueList = delete_Blocks.Distinct();


        for (int i = 0; i < connect_Color_ary.Length; i++)
        {
            if (i == 0)
            {
                delete_Blocks.Add(0);
                connect_Count = 0;
            }
            else
            {

                check_Connect_before = connect_Color_ary[i - 1];

                // iが右端の1マス手前のときは、next_Colorに右隣の色を渡し、右端のときはNONEを渡す
                BlockManager.COLOR_TYPE next_Color;
                if (i < connect_Color_ary.Length - 1)
                {
                    next_Color = connect_Color_ary[i + 1];
                }
                else
                {
                    next_Color = BlockManager.COLOR_TYPE.NONE;
                }


                //Debug.Log("connect_Color_ary" + i + " : " + connect_Color_ary[i] + " next_Color" + next_Color);



                // 前の色がNONEじゃない
                if (check_Connect_before != BlockManager.COLOR_TYPE.NONE)
                {
                    //Debug.Log("i = " + i);
                    //Debug.Log("check_Connect_before" + (i - 1) + " : " + check_Connect_before + " connect_Color_ary" + i + " : " + connect_Color_ary[i] + " next_Color" + (i + 1) + " : " + next_Color);

                    // 前の色が今の色が一致していたら、連続一致回数をカウントし、DELETE_COUNT回以上連続したときにObjectを削除する
                    if (check_Connect_before == connect_Color_ary[i])
                    {
                        //Debug.Log("一致 check_Connect_before" + i + " : " + check_Connect_before + " connect_Color_ary" + i + " : " + connect_Color_ary[i]);

                        // リストdelete_Blocksにi-1とiの数値を追加
                        delete_Blocks.Add(i);
                        delete_Blocks.Add(i - 1);

                        // uniqueListにconnect_Listの値を重複なしで追加
                        uniqueList = delete_Blocks.Distinct();
                        //Debug.Log(string.Join(",", uniqueList));

                        connect_Count++;
                        //Debug.Log("connect_Count : " + connect_Count);

                        // DELETE_COUNT回以上連続し、かつ、次の色と違うときにObjectを削除する                
                        if (connect_Count >= DELETE_COUNT && connect_Color_ary[i] != next_Color)
                        {
                            //Debug.Log("connect_Count > 2 : " + connect_Count);
                            foreach (int delObj in uniqueList)
                            {
                                Destroy(connect_Obj_ary[delObj]);
                            }
                            scoreManager.GetComponent<ScoreManager>().ScoreCalculation(connect_Count);
                        }
                    }
                    else
                    {
                        connect_Count = 0;
                        delete_Blocks.Clear();
                        uniqueList = null;
                    } // if (check_Connect_before == connect_Color_ary[i])

                } // if (check_Connect_before != BlockManager.COLOR_TYPE.NONE)





            } // if (i == 0)

        } // for (int i = 0; i < connect_Color_ary.Length; i++)

        uniqueList = null;
        //Debug.Log("uniqueList = " + uniqueList);
        delete_Blocks.Clear();


    }

}
