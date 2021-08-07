using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockManager : MonoBehaviour
{
	// ブロック色.
	public enum COLOR_TYPE
	{
		NONE,
		YELLOW,
		ORANGE,
		GREEN,
		BLUE,
		RED,
	};
	public COLOR_TYPE Color;

	public float block_pox_x;
	public float block_pox_y;

	public bool pos_Chack = false;

	// Start is called before the first frame update
	void Start()
	{
        block_pox_x = this.transform.position.x;
        block_pox_y = this.transform.position.y;
    }

	// Update is called once per frame
	void Update()
	{


	}


}
