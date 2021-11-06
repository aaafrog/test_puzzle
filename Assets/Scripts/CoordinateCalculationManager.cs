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

    public bool left_Contact = false; // �Œ�u���b�N�������ɗא�
    public bool right_Contact = false; // �Œ�u���b�N���E���ɗא�
    public bool rotate_Imp = false; // ��]�s��
    public bool landing = false; // �u���b�N�ɐڒn


    // �������u���b�N�|�W�V����
    private float DO_Block_pos_x_0;
    private float DO_Block_pos_y_0;
    private float DO_Block_pos_x_1;
    private float DO_Block_pos_y_1;

    // �ݒu�ς݃u���b�N�|�W�V����
    List<float> p_Block_pos_x = new List<float>();
    List<float> p_Block_pos_y = new List<float>();

    // ��r��|�W�V����
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
    /////        �z�u�ς݃u���b�N�̈ʒu���擾�p�@CreateManager�ŗ����u���b�N�����O�ɌĂяo��
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
    /////        �z�u�ς݃u���b�N�̈ʒu�����N���A�@CreateManager�ŗ����u���b�N�����O�ɌĂяo��
    /////
    ////////////////////////////////////////////////////////////////////////////////////////////////////////////
    public void Clear_Block_Pos()
    {
        p_Block_pos_x.Clear();
        p_Block_pos_y.Clear();

    }


    ////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /////
    /////        �z�u�ς݃u���b�N�̈ʒu���Ɨ����u���b�N�̈ʒu���̍����v�Z
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

        // �ړ��u���b�N�̃|�W�V��������A�ݒu�u���b�N�̃|�W�V�����������āA��r��ϐ��֊i�[
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
    /////        �z�u�ς݃u���b�N�̈ʒu���Ɨ����A�u���b�N�̈ʒu���̍����v�Z
    /////        ���l�����Ԃ𔻒f����
    /////
    ////////////////////////////////////////////////////////////////////////////////////////////////////////////
    void Block_Contact_Check()
    {
        //Debug.Log("Block_Contact_Check()");

        left_Contact_Count = 0;
        right_Contact_Count = 0;

        // WallBottom�ɐڐG���Ă��邩
        if (DO_Block_pos_y_0 == -2 || DO_Block_pos_y_1 == -2)
        {
            //Debug.Log("WallBottom");
            Block_Landing();
        }
        else if(landing == false)
        {
            //Debug.Log("not_WallBottom");



            // �e�u���b�N�Ƃ̈ʒu�̍�����A����̐��������肷��
            for (int i = 0; i < p_Block_pos_x.Count; i++) // �ݒu�ς݃u���b�N�񐔃��[�v
            {
                // �אڂƉ�]�֎~�̔���
                if (comparison_pos_y_0[i] == 0 || comparison_pos_y_1[i] == 0) // 0��1�������ɕ��񂾂Ƃ�
                {
                    //Debug.Log("0��1������");
                    // �Œ�u���b�N���E���ɗאڂ��Ă�����אڃJ�E���^�[���J�E���g�A�b�v���A�E�אڃt���O�𗧂Ă�
                    if (comparison_pos_x_0[i] == -0.5 || comparison_pos_x_1[i] == -0.5)
                    {
                        right_Contact_Count++;
                        right_Contact = true;
                        //Debug.Log("�Œ�u���b�N���E���ɗא�");
                    }
                    // �Œ�u���b�N�������ɗאڂ��Ă�����אڃJ�E���^�[���J�E���g�A�b�v���A���אڃt���O�𗧂Ă�
                    if (comparison_pos_x_0[i] == 0.5 || comparison_pos_x_1[i] == 0.5)
                    {
                        left_Contact_Count++;
                        left_Contact = true;
                        //Debug.Log("left_Contact = " + left_Contact);
                    }
                    // �����u���b�N0�A1���㉺�ɕ��сA���A���ɗאڂ��Ă���ꍇ�A��]�����Ȃ�
                    if (rotate_Count == 0 && left_Contact == true)
                    {
                        //Debug.Log("rotate_Count  = " + rotate_Count);
                        rotate_Imp = true;
                    }
                    // �����u���b�N0�A1������ɕ��сA���A�E�ɗאڂ��Ă���ꍇ�A��]�����Ȃ�
                    if (rotate_Count == 2 && right_Contact == true)
                    {
                        rotate_Imp = true;
                    }

                    //Debug.Log("rotate_Imp = " + rotate_Imp);
                }

                // �Œ�u���b�N���㑤�ɗאڂ��Ă������]�����Ȃ�
                if ((rotate_Count == 1 || rotate_Count == 3) && (comparison_pos_y_0[i] == -0.5 || comparison_pos_y_1[i] == -0.5))
                {
                    rotate_Imp = true;
                }


                // �ڐG�`�F�b�N��A�t���O��߂�
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


                // �u���b�N�ɐڒn�����ꍇ�A�t���O�𗧂āA�ڒn������
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
    /////        �����u���b�N���ڒn�����ꍇ�̏���
    /////
    ////////////////////////////////////////////////////////////////////////////////////////////////////////////
    void Block_Landing()
    {
        //Debug.Log("Block_Landing");
        //landing = false;
        controlManager.GetComponent<ControlManager>().enabled = false; // �ڒn��ControlManager��SideWallContactManager�ϐ��擾�ŃG���[���o�邽�ߖ�����
        downObjectDelete.GetComponent<DownObjectDelete>().go_Delete = true;
        downObjectDelete.GetComponent<DownObjectDelete>().Delete(); // �����u���b�N�̘A��������

        //Debug.Log(hit.collider.gameObject.name);
    }


}