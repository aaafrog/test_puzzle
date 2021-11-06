using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderControl : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }





    private IEnumerator Go_Create()
    {
        yield return StartCoroutine("DestroyObj"); // DownObject(Clone)オブジェクトの削除を待つ

        Debug.Log("Go_Create");



    }

    private IEnumerator DestroyObj()
    {
        Debug.Log("DestroyObj");
        yield return new WaitForSeconds(0);

    }

}
