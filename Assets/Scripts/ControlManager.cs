using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlManager : MonoBehaviour
{

    private float horizontalKey = 0.0f;
    private float create_Timer = 1.0f;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
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



        //左右移動

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            horizontalKey = -0.5f;
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            horizontalKey = 0.5f;
        }

        if (horizontalKey != 0.0f)
        {
            transform.Translate(horizontalKey, 0, 0, Space.World);
            horizontalKey = 0.0f;
        }


        //下移動
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            transform.Translate(0, -0.5f, 0, Space.World);
        }

        //右回転
        if (Input.GetKeyDown(KeyCode.Space))
        {
            transform.Rotate(0, 0, -90.0f);
        }


        /////////////////////////////////////////////////////////
        ///
        ///         入力処理E
        /// 
        /////////////////////////////////////////////////////////
    }
}
