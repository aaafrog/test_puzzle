using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.Linq;
using System.Globalization;

public class ConnectCheckManager : MonoBehaviour
{
    public bool go_Check = false;

    private GameObject[] targetBlocks;

    private GameObject[] connect_Obj_ary = new GameObject[11];
    private BlockManager.COLOR_TYPE[] connect_Color_ary = new BlockManager.COLOR_TYPE[11];
    private BlockManager.COLOR_TYPE check_Connect_before;

    private float start_Pos_x = -2.5f;
    private float start_Pos_y = -3.0f;
    private float end_Pos_x = 2.5f;
    private float end_Pos_y = 3.5f;
    private float check_Pos_x;
    private float check_Pos_y;
    private int max_x = 11;
    private int max_y = 14;
    private int connect_Count = 0;
    private int DELETE_COUNT = 2;





    // Start is called before the first frame update
    void Start()
    {

    }



    // Update is called once per frame
    void Update() 
    {

        if (go_Check == true)
        {

            targetBlocks = GameObject.FindGameObjectsWithTag("Block");

            check_Pos_y = start_Pos_y;

            for (int j = 0; j < max_y; j++)
            {
                // gameObjに代入されたGameObjectを、左から順に配列に追加
                foreach (GameObject gameObj in targetBlocks)
                {
                    check_Pos_x = start_Pos_x;

                    //Debug.Log("gameObj" + list_No + " : " + gameObj);

                    // カウントアップの度に位置情報を変え、gameObjが所定の位置にあったとき、配列のi番目に追加
                    for (int i = 0; i <= connect_Color_ary.Length; i++)
                    {
                        // check_Pos_x・check_Pos_yと位置が一致したとき、配列に追加
                        if (check_Pos_x == gameObj.GetComponent<BlockManager>().block_pox_x && check_Pos_y == gameObj.GetComponent<BlockManager>().block_pox_y)
                        {
                            connect_Color_ary[i] = gameObj.GetComponent<BlockManager>().Color;
                            connect_Obj_ary[i] = gameObj;
                            //Debug.Log("connect_List" + i + " : " + connect_Color_ary[i]);

                        }
                        check_Pos_x = check_Pos_x + 0.5f; // check_Pos_xを右へ1マス分移動
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

                connect_Color_ary = new BlockManager.COLOR_TYPE[11];
                connect_Obj_ary = new GameObject[11];
                
                check_Pos_x = start_Pos_x;
                check_Pos_y = check_Pos_y + 0.5f; // check_Pos_xを右へ1マス分移動
                //Debug.Log("check_Pos_y" + j + " : " + check_Pos_y);
            }





            go_Check = false;
        }


    }// Update


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
                    Debug.Log("i = " + i);
                    Debug.Log("check_Connect_before" + (i - 1) + " : " + check_Connect_before + " connect_Color_ary" + i + " : " + connect_Color_ary[i] + " next_Color" + (i + 1) + " : " + next_Color);
                    // 前の色が今の色が一致していたら、連続一致回数をカウントし、DELETE_COUNT回以上連続したときにObjectを削除する
                    if (check_Connect_before == connect_Color_ary[i])
                    {
                        //Debug.Log("一致 check_Connect_before" + i + " : " + check_Connect_before + " connect_Color_ary" + i + " : " + connect_Color_ary[i]);

                        // リストdelete_Blocksにi-1とiの数値を追加
                        delete_Blocks.Add(i);
                        delete_Blocks.Add(i - 1);

                        // uniqueListにconnect_Listの値を重複なしで追加
                        uniqueList = delete_Blocks.Distinct();

                        Debug.Log(string.Join(",", uniqueList));

                        connect_Count++;
                        Debug.Log("connect_Count : " + connect_Count);

                        // DELETE_COUNT回以上連続し、かつ、次の色と違うときにObjectを削除する                
                        if (connect_Count >= DELETE_COUNT && connect_Color_ary[i] != next_Color)
                        {
                            //Debug.Log("connect_Count > 2 : " + connect_Count);
                            foreach (int delObj in uniqueList)
                            {
                                Destroy(connect_Obj_ary[delObj]);
                            }

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
