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

	public float block_pos_x;
	public float block_pos_y;


	// Start is called before the first frame update
	void Start()
	{
		block_pos_x = Mathf.RoundToInt(this.transform.position.x * 10.0f) / 10.0f;
		block_pos_y = Mathf.RoundToInt(this.transform.position.y * 10.0f) / 10.0f;
	}

	// Update is called once per frame
	void Update()
	{
		block_pos_x = Mathf.RoundToInt(this.transform.position.x * 10.0f) / 10.0f;
		block_pos_y = Mathf.RoundToInt(this.transform.position.y * 10.0f) / 10.0f;

	}


}
