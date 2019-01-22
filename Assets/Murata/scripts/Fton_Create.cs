using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UniRx;
using UniRx.Triggers;

//布団生成スクリプト
public class Fton_Create : MonoBehaviour {

    //布団オブジェクト
    [SerializeField]
    private GameObject m_Futon;

    //布団オブジェクトの間隔サイズ
    [SerializeField]
    private float m_FutonSizeX, m_FutonSizeZ;

    //設置開始地点
    [SerializeField]
    private Vector3 m_InstallationPosition;

    //横に設置する最大個数
    [SerializeField]
    private int m_NumberInstalled;

    //盤面に設置する最大個数
    [SerializeField]
    private int m_MaximumNumber = 50;

    //現在設置してある個数
    [SerializeField]
    private int count = 0;

    //最大数
    private int MAX_count = 264;

    //設置座標リスト
    private List<Coordinate> m_CoordinateList = new List<Coordinate>();

    //設置している座標
    private List<Coordinate> m_InstallationCoordinates = new List<Coordinate>();

    //再設置判定
    [SerializeField]
    private BoolReactiveProperty m_Reinstall = new BoolReactiveProperty(false);

    public int kansi;
    private void Start()
    {
        //座標一Listの初期設定
        for (int i = 0; i < MAX_count; i++)
        {
            Random r = new Random();
            //設置できる座標の位置の計算
            var x = i % m_NumberInstalled * m_FutonSizeX+m_InstallationPosition.x;
            var z = i / m_NumberInstalled * m_FutonSizeZ+m_InstallationPosition.z;
            //クラスを作成し、Listに保存
            var coordinate = new Coordinate(x, z);
            m_CoordinateList.Add(coordinate);
        }
        //布団の設置開始
        while (count <= m_MaximumNumber)
        {
            //被っているものを除いてListに保存 
            List<Coordinate> list = new List<Coordinate>();
            foreach (Coordinate cor in m_CoordinateList)
            {
                if (!m_InstallationCoordinates.Any(c => c.x == cor.x && c.z == cor.z))
                    if (!list.Any(c => c.x == cor.x && c.z == cor.z))
                        list.Add(cor);
            }

            //どこに設置するかランダムで決める
            // var number = Random.Range(0, list.Count);
            var number = Random.Range(0, 264);
            //Debug.Log("ナンバー" + number);
            //Debug.Log("リスト"+list.Count);
            var coordinate = m_CoordinateList[number];
            //設置を行う座標を取得
            var pos = new Vector3(coordinate.x, 0, coordinate.z);

            //設置を行い、設置している場所のListに加え、設置数を増やす
            Instantiate(m_Futon, pos, Quaternion.identity);
            m_InstallationCoordinates.Add(coordinate);
           // Debug.Log(pos);
            count += 1;
          //  Debug.Log("初期現在の数" + count);
        }
        //Debug.Log(count);
        //再設置処理
        m_Reinstall.Where(c => c)
            .Subscribe(c =>
            {
                Observable.Timer(System.TimeSpan.FromSeconds(0.1f))
                .Subscribe(_ =>
                {
                    while (count <= m_MaximumNumber)
                    {
                        //被っているものを除いてListに保存 
                        List<Coordinate> list = new List<Coordinate>();
                        foreach (Coordinate cor in m_CoordinateList)
                        {
                            if (!m_InstallationCoordinates.Any(n => n.x == cor.x && n.z == cor.z))
                                if (!list.Any(n => n.x == cor.x && n.z == cor.z))
                                    list.Add(cor);
                        }

                        //どこに設置するかランダムで決める
                        // var number = Random.Range(0, list.Count);
                        var number = Random.Range(0, MAX_count);
                        //Debug.Log("ナンバー" + number);
                        //Debug.Log("リスト" + list.Count);
                        var coordinate = m_CoordinateList[number];
                        //設置を行う座標を取得
                        var pos = new Vector3(coordinate.x, 0, coordinate.z);

                        //設置を行い、設置している場所のListに加え、設置数を増やす
                        Instantiate(m_Futon, pos, Quaternion.identity);
                        m_InstallationCoordinates.Add(coordinate);
                       // Debug.Log(pos);
                        count += 1;
                       // Debug.Log("蘇った現在の数" + count);
                        // Debug.Log(count);
                        m_Reinstall.Value = count >= m_MaximumNumber ? false : true;
                    }
                }).AddTo(this);
            }).AddTo(this);
    }
    //布団の破壊処理
    public void DuplicateFuton(float x, float z)
    {
        //設置されていた場所のListを削除
        var coordinate = m_InstallationCoordinates.FirstOrDefault(c => c.x == x && c.z == z);
        if (coordinate != null)
            m_InstallationCoordinates.Remove(coordinate);
        //設置されている個数を減らし再設置開始
        count -= 1;
        if (!m_Reinstall.Value)
            m_Reinstall.Value = true;
        //Debug.Log("破壊された現在の数"+count);
    }
    /// 座標クラス
    public class Coordinate
    {
        public readonly float x;
        public readonly float z;

        public Coordinate(float x, float z)
        {
            this.x = x;
            this.z = z;
        }
    }
}