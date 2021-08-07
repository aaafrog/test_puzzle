using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockContactManager : MonoBehaviour
{
    private GameObject downObjectDelete;

    // Use this for initialization
    void Start()
    {
        downObjectDelete = GameObject.Find("DownObjectDelete");
    }

    // Update is called once per frame
    void Update()    {

        //Rayの作成　　　　　　　↓Rayを飛ばす原点　　　↓Rayを飛ばす方向
        Ray2D ray = new Ray2D(transform.position, transform.up);


        //Rayの飛ばせる距離
        float distance = 0.5f;

        //Rayの方向
        Vector3 direction = new Vector3(0.0f, 0.5f, 0.0f);

        //Rayを当てるlayerMaskを指定
        int layerMask = 1 << 8;

        //Rayの可視化    ↓Rayの原点　　　　↓Rayの方向　　　　↓Rayの色
        Debug.DrawRay(ray.origin, direction, Color.green);

        //Rayが当たったオブジェクトの情報を入れる箱
        RaycastHit2D hit = Physics2D.Raycast(ray.origin, direction, distance, layerMask);


        if (hit.collider)
        {
            downObjectDelete.GetComponent<DownObjectDelete>().go_Delete = true;
            downObjectDelete.GetComponent<DownObjectDelete>().Delete();
            //Debug.Log(hit.collider.gameObject.name);
        }
    }



}
