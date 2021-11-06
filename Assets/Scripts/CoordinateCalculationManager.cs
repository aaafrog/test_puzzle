using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoordinateCalculationManager : MonoBehaviour
{
    private GameObject downObjectDelete;
    private GameObject controlManager;
    private GameObject downObject;

    private GameObject[] placed_Blocks;


    private int rotate_Count = 0;
    private int left_Contact_Count = 0;
    private int right_Contact_Count = 0;

    public bool left_Contact = false; // 固定ブロックが左側に隣接
    public bool right_Contact = false; // 固定ブロックが右側に隣接
    public bool rotate_Imp = false; // 回転不可
    public bool landing = false; // ブロックに接地


    // 落下中ブロックポジション
    private float DO_Block_pos_x_0;
    private float DO_Block_pos_y_0;
    private float DO_Block_pos_x_1;
    private float DO_Block_pos_y_1;

    // 設置済みブロックポジション
    List<float> p_Block_pos_x = new List<float>();
    List<float> p_Block_pos_y = new List<float>();

    // 比較後ポジション
    List<float> comparison_pos_x_0 = new List<float>();
    List<float> comparison_pos_y_0 = new List<float>();
    List<float> comparison_pos_x_1 = new List<float>();
    List<float> comparison_pos_y_1 = new List<float>();


    // Start is called before the first frame update
    void Start()
    {
        downObjectDelete = GameObject.Find("DownObjectDelete");
        controlManager = GameObject.Find("ControlManager");
    }

    // Update is called once per frame
    void Update()
    {
        
    }




    ////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /////
    /////        配置済みブロックの位置情報取得用　CreateManagerで落下ブロック生成前に呼び出し
    /////
    ////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //public void Set_Block_Pos()
    //{
    //    Debug.Log("Set_Block_Pos");
    //    placed_Blocks = GameObject.FindGameObjectsWithTag("Block");
    //    Debug.Log("placed_Blocks = " + placed_Blocks);

    //    foreach (GameObject gameObj in placed_Blocks)
    //    {
    //        p_Block_pos_x.Add(gameObj.GetComponent<BlockManager>().block_pos_x);
    //        p_Block_pos_y.Add(gameObj.GetComponent<BlockManager>().block_pos_y);

    //    }

    //    //foreach (float pos_x in p_Block_pos_x)
    //    //{
    //    //    Debug.Log("pos_x = " + pos_x);
    //    //}
    //    //foreach (float pos_y in p_Block_pos_y)
    //    //{
    //    //    Debug.Log("pos_y = " + pos_y);
    //    //}
    //}

    public void Set_Block_Pos()
    {
        //Debug.Log("0");
        StartCoroutine("Wait_Set_Block_Pos");
    }

    private IEnumerator Wait_Set_Block_Pos()
    {
        //Debug.Log("1");
        yield return new WaitForSeconds(1);

        //Debug.Log("2");
        placed_Blocks = GameObject.FindGameObjectsWithTag("Block");

        foreach (GameObject gameObj in placed_Blocks)
        {
            p_Block_pos_x.Add(gameObj.GetComponent<BlockManager>().block_pos_x);
            p_Block_pos_y.Add(gameObj.GetComponent<BlockManager>().block_pos_y);

        }

        //foreach (float pos_x in p_Block_pos_x)
        //{
        //    Debug.Log("pos_x = " + pos_x);
        //}
        //foreach (float pos_y in p_Block_pos_y)
        //{
        //    Debug.Log("pos_y = " + pos_y);
        //}

    }

    ////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /////
    /////        配置済みブロックの位置情報をクリア　CreateManagerで落下ブロック生成前に呼び出し
    /////
    ////////////////////////////////////////////////////////////////////////////////////////////////////////////
    public void Clear_Block_Pos()
    {
        p_Block_pos_x.Clear();
        p_Block_pos_y.Clear();

    }


    ////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /////
    /////        配置済みブロックの位置情報と落下ブロックの位置情報の差を計算
    /////
    ////////////////////////////////////////////////////////////////////////////////////////////////////////////
    public void Calculate_Block_Pos()
    {
        //Debug.Log("Calculate_Block_Pos()");
        downObject = GameObject.Find("DownObject(Clone)");

        if (downObject != null)
        {
            //Debug.Log("downObject = " + downObject);

            DO_Block_pos_x_0 = downObject.GetComponent<DownObjectManager>().DO_Block_pos_x_0;
            DO_Block_pos_y_0 = downObject.GetComponent<DownObjectManager>().DO_Block_pos_y_0;
            DO_Block_pos_x_1 = downObject.GetComponent<DownObjectManager>().DO_Block_pos_x_1;
            DO_Block_pos_y_1 = downObject.GetComponent<DownObjectManager>().DO_Block_pos_y_1;


            //Debug.Log("BCM_DO_Block_pos_x_0 = " + DO_Block_pos_x_0);
            //Debug.Log("BCM_DO_Block_pos_y_0 = " + DO_Block_pos_y_0);
            //Debug.Log("BCM_DO_Block_pos_x_1 = " + DO_Block_pos_x_1);
            //Debug.Log("BCM_DO_Block_pos_y_1 = " + DO_Block_pos_y_1);

        }

        // 移動ブロックのポジションから、設置ブロックのポジションを引いて、比較後変数へ格納
        for (int i = 0; i < p_Block_pos_x.Count; i++)
        {
            comparison_pos_x_0.Insert(i, DO_Block_pos_x_0 - p_Block_pos_x[i]);
            comparison_pos_y_0.Insert(i, DO_Block_pos_y_0 - p_Block_pos_y[i]);
            comparison_pos_x_1.Insert(i, DO_Block_pos_x_1 - p_Block_pos_x[i]);
            comparison_pos_y_1.Insert(i, DO_Block_pos_y_1 - p_Block_pos_y[i]);

            //Debug.Log("DO_Block_pos_x_0 = " + DO_Block_pos_x_0 + "  p_Block_pos_x_" + i + " = " + p_Block_pos_x[i] + "  comparison_pos_x_0 = " + comparison_pos_x_0[i]);
            //Debug.Log("DO_Block_pos_y_0 = " + DO_Block_pos_y_0 + "  p_Block_pos_y_" + i + " = " + p_Block_pos_y[i] + "  comparison_pos_y_0 = " + comparison_pos_y_0[i]);
            //Debug.Log("DO_Block_pos_x_1 = " + DO_Block_pos_x_1 + "  p_Block_pos_x_" + i + " = " + p_Block_pos_x[i] + "  comparison_pos_x_1 = " + comparison_pos_x_1[i]);
            //Debug.Log("DO_Block_pos_y_1 = " + DO_Block_pos_y_1 + "  p_Block_pos_y_" + i + " = " + p_Block_pos_y[i] + "  comparison_pos_y_1 = " + comparison_pos_y_1[i]);

            //Debug.Log("comparison_pos_x_0_" + i + " = " + comparison_pos_x_0[i]);
            //Debug.Log("comparison_pos_y_0_" + i + " = " + comparison_pos_y_0[i]);
            //Debug.Log("comparison_pos_x_1_" + i + " = " + comparison_pos_x_1[i]);
            //Debug.Log("comparison_pos_y_1_" + i + " = " + comparison_pos_y_1[i]);

        }

        Block_Contact_Check();
    }



    ////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /////
    /////        配置済みブロックの位置情報と落下、ブロックの位置情報の差を計算
    /////        数値から状態を判断する
    /////
    ////////////////////////////////////////////////////////////////////////////////////////////////////////////
    void Block_Contact_Check()
    {
        //Debug.Log("Block_Contact_Check()");

        left_Contact_Count = 0;
        right_Contact_Count = 0;

        // WallBottomに接触しているか
        if (DO_Block_pos_y_0 == -2 || DO_Block_pos_y_1 == -2)
        {
            //Debug.Log("WallBottom");
            Block_Landing();
        }
        else if(landing == false)
        {
            //Debug.Log("not_WallBottom");



            // 各ブロックとの位置の差から、動作の制限を決定する
            for (int i = 0; i < p_Block_pos_x.Count; i++) // 設置済みブロック回数ループ
            {
                // 隣接と回転禁止の判定
                if (comparison_pos_y_0[i] == 0 || comparison_pos_y_1[i] == 0) // 0か1が水平に並んだとき
                {
                    //Debug.Log("0か1が水平");
                    // 固定ブロックが右側に隣接していたら隣接カウンターをカウントアップし、右隣接フラグを立てる
                    if (comparison_pos_x_0[i] == -0.5 || comparison_pos_x_1[i] == -0.5)
                    {
                        right_Contact_Count++;
                        right_Contact = true;
                        //Debug.Log("固定ブロックが右側に隣接");
                    }
                    // 固定ブロックが左側に隣接していたら隣接カウンターをカウントアップし、左隣接フラグを立てる
                    if (comparison_pos_x_0[i] == 0.5 || comparison_pos_x_1[i] == 0.5)
                    {
                        left_Contact_Count++;
                        left_Contact = true;
                        //Debug.Log("left_Contact = " + left_Contact);
                    }
                    // 落下ブロック0、1が上下に並び、かつ、左に隣接している場合、回転させない
                    if (rotate_Count == 0 && left_Contact == true)
                    {
                        //Debug.Log("rotate_Count  = " + rotate_Count);
                        rotate_Imp = true;
                    }
                    // 落下ブロック0、1が下上に並び、かつ、右に隣接している場合、回転させない
                    if (rotate_Count == 2 && right_Contact == true)
                    {
                        rotate_Imp = true;
                    }

                    //Debug.Log("rotate_Imp = " + rotate_Imp);
                }

                // 固定ブロックが上側に隣接していたら回転させない
                if ((rotate_Count == 1 || rotate_Count == 3) && (comparison_pos_y_0[i] == -0.5 || comparison_pos_y_1[i] == -0.5))
                {
                    rotate_Imp = true;
                }


                // 接触チェック後、フラグを戻す
                if (i == p_Block_pos_x.Count - 1)
                {
                    if (left_Contact_Count == 0)
                    {
                        //Debug.Log("left_Contact_Count2 = " + left_Contact_Count);
                        left_Contact = false;
                    }
                    if (right_Contact_Count == 0)
                    {
                        right_Contact = false;
                    }
                    if (rotate_Count == 0 && left_Contact == false)
                    {
                        rotate_Imp = false;
                    }
                    if (rotate_Count == 2 && right_Contact == false)
                    {
                        rotate_Imp = false;
                    }

                }


                // ブロックに接地した場合、フラグを立て、接地処理へ
                if ((comparison_pos_x_0[i] == 0 || comparison_pos_x_1[i] == 0) && (comparison_pos_y_0[i] == 0.5 || comparison_pos_y_1[i] == 0.5))
                {
                    if (landing == false)
                    {
                        //Debug.Log("Block_Landing");
                        landing = true;
                        Block_Landing();
                    }

                }


                //Debug.Log("left_Contact_Count = " + left_Contact_Count);
                //Debug.Log("i = " + i + " p_Block_pos_x.Count = " + p_Block_pos_x.Count);

            } // for

        } // if


    } // Block_Contact_Check()



    ////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /////
    /////        落下ブロックが接地した場合の処理
    /////
    ////////////////////////////////////////////////////////////////////////////////////////////////////////////
    void Block_Landing()
    {
        //Debug.Log("Block_Landing");
        //landing = false;
        controlManager.GetComponent<ControlManager>().enabled = false; // 接地時ControlManagerのSideWallContactManager変数取得でエラーが出るため無効化
        downObjectDelete.GetComponent<DownObjectDelete>().go_Delete = true;
        downObjectDelete.GetComponent<DownObjectDelete>().Delete(); // 落下ブロックの連結を解除

        //Debug.Log(hit.collider.gameObject.name);
    }


}
