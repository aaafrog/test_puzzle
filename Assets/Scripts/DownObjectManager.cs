using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DownObjectManager : MonoBehaviour
{

    ////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /////
    /////        �v���n�u��DownObject�ɓ\��t��
    /////        ���g�̈ʒu���A����сA��]��Ԃ��擾��
    /////        �e�u���b�N�̈ʒu����ϐ��Ɋi�[����
    /////
    ////////////////////////////////////////////////////////////////////////////////////////////////////////////




    //private GameObject downObject;
    private GameObject controlManager;
    private GameObject coordinateCalculationManager;
    private GameObject createManager;
    //private GameObject blockContactManager;

    public float DO_Block_pos_x_0;
    public float DO_Block_pos_y_0;
    public float DO_Block_pos_x_1;
    public float DO_Block_pos_y_1;

    public bool left_Contact = false; // 
    public bool right_Contact = false; // 

    private int rotate_Count = 0; // 
    private bool on_Bottom = false; // 

    // Start is called before the first frame update
    void Start()
    {
        //blockContactManager = GameObject.Find("BlockContactManager");
        controlManager = GameObject.Find("ControlManager");
        coordinateCalculationManager = GameObject.Find("CoordinateCalculationManager");
        createManager = GameObject.Find("CreateManager");
        createManager.GetComponent<CreateManager>().cpl_Create = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        DO_Block_Pos_Check();
    }





    ////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /////
    /////        �������̊e�u���b�N�̈ʒu���A����сA��]��Ԃ��擾�E�i�[����B
    /////
    ////////////////////////////////////////////////////////////////////////////////////////////////////////////

    void DO_Block_Pos_Check()
    {
        //downObject = GameObject.Find("DownObject(Clone)");


        rotate_Count = controlManager.GetComponent<ControlManager>().rotate_Count;
        //Debug.Log("rotate_Count = " + rotate_Count);

        DO_Block_pos_x_0 = Mathf.RoundToInt(this.transform.position.x * 10.0f) / 10.0f;
        DO_Block_pos_y_0 = Mathf.RoundToInt(this.transform.position.y * 10.0f) / 10.0f;

        if (rotate_Count == 0) // 0����A1����
        {
            DO_Block_pos_x_1 = DO_Block_pos_x_0;
            DO_Block_pos_y_1 = Mathf.RoundToInt((DO_Block_pos_y_0 - 0.5f) * 10.0f) / 10.0f;
        }
        else if (rotate_Count == 1) // 0���E�A1����
        {
            DO_Block_pos_x_1 = Mathf.RoundToInt((DO_Block_pos_x_0 - 0.5f) * 10.0f) / 10.0f;
            DO_Block_pos_y_1 = DO_Block_pos_y_0;
        }
        else if (rotate_Count == 2) // 0�����A1����
        {
            DO_Block_pos_x_1 = DO_Block_pos_x_0;
            DO_Block_pos_y_1 = Mathf.RoundToInt((DO_Block_pos_y_0 + 0.5f) * 10.0f) / 10.0f;
        }
        else if (rotate_Count == 3) // 0�����A1���E
        {
            DO_Block_pos_x_1 = Mathf.RoundToInt((DO_Block_pos_x_0 + 0.5f) * 10.0f) / 10.0f;
            DO_Block_pos_y_1 = DO_Block_pos_y_0;
        }

        //Debug.Log("DO_Block_pos_x_0 = " + DO_Block_pos_x_0);
        //Debug.Log("DO_Block_pos_y_0 = " + DO_Block_pos_y_0);
        //Debug.Log("DO_Block_pos_x_1 = " + DO_Block_pos_x_1);
        //Debug.Log("DO_Block_pos_y_1 = " + DO_Block_pos_y_1);

    }



    void OnTriggerStay2D(Collider2D col)
    {
        //Debug.Log("OnTriggerEnter2D");
        //blockContactManager.GetComponent<BlockContactManager>().Calculate_Block_Pos(); // �z�u�ς݃u���b�N�̈ʒu���Ɨ����u���b�N�̈ʒu���̍����v�Z
        // �Փ˔���

        if (col.gameObject.tag == "WallBottom" || col.gameObject.tag == "Block")
        {
            coordinateCalculationManager.GetComponent<CoordinateCalculationManager>().Calculate_Block_Pos(); // �z�u�ς݃u���b�N�̈ʒu���Ɨ����u���b�N�̈ʒu���̍����v�Z
        }
        if (col.gameObject.tag == "WallRight")
        {
            right_Contact = true;
        }
        if (col.gameObject.tag == "WallLeft")
        {
            left_Contact = true;
        }

    }

    // �Փ˔���
    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.name == "WallRight")
        {
            right_Contact = false;
        }


        if (col.gameObject.name == "WallLeft")
        {
            left_Contact = false;
        }



    }


}