using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TEST : MonoBehaviour
{
    public GameObject prefab;

    void Start()
    {
        GameObject[,] stageMap = new GameObject[23, 17];
        // 配置するプレハブの読み込み 
        GameObject prefab = (GameObject) Resources.Load("Fbx/ofutolun");
        // 配置元のオブジェクト指定 
        // GameObject stageObject = GameObject.FindWithTag("Stage");
        //// タイル配置
        //for (int i = 0; i < 23; i++)
        //{
        //    for (int j = 0; j < 17; j++)
        //    {


        //        Vector3 tile_pos = new Vector3(
        //        0 + prefab.transform.localScale.x * i,
        //        0,
        //        0 + prefab.transform.localScale.z * j

        //        );

        //        if (prefab != null)
        //        {
        //            // プレハブの複製 
        //            GameObject instant_object = Instantiate(prefab, tile_pos, Quaternion.identity) as GameObject;
        //            // 生成元の下に複製したプレハブをくっつける 
        //        //    instant_object.transform.parent = stageObject.transform;

        //        }
        //    }
        //}
        Debug.Log(prefab.name);
    }
   
}
