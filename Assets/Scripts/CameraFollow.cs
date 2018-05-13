using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {
    public float xMargin = 1f; //角色能够在摄像机不跟随的情况下水平移动的距离
    public float yMargin = 1f; //角色能够在摄像机不跟随的情况下竖直移动的距离
    public float xSmooth = 8f; //摄像机水平移动的平滑程度
    public float ySmooth = 8f; //摄像机竖直移动的平滑程度

    public Vector2 maxXAndY; //摄像机水平坐标限制
    public Vector2 minXAndY; //摄像机竖直坐标限制

    private Transform player; //获取角色

	// Use this for initialization
	void Awake () {
        player = GameObject.FindGameObjectWithTag("Player").transform;
       
	}

    // Update is called once per frame
  
    bool CheckXMargin()
    {
        return Mathf.Abs(transform.position.x - player.position.x) > xMargin;
    }
    bool CheckYMargin()
    {
        return Mathf.Abs(transform.position.y - player.position.y) > xMargin;
    }
    private void LateUpdate()
    {
        TrackPlayer();
    }

    void TrackPlayer()
    {
        //当前摄像机坐标
        float targetX = transform.position.x;
        float targetY = transform.position.y;

        //当玩家超过移动范围
        if (CheckXMargin())
            targetX = Mathf.Lerp(transform.position.x, player.position.x, xSmooth * Time.deltaTime);
        if (CheckYMargin())
            targetY = Mathf.Lerp(transform.position.y, player.position.y, ySmooth * Time.deltaTime);

       targetX = Mathf.Clamp(targetX, minXAndY.x, maxXAndY.x);
        targetY = Mathf.Clamp(targetY, minXAndY.y, maxXAndY.y);
      
        transform.position = new Vector3(targetX, targetY, transform.position.z);
    }
}
