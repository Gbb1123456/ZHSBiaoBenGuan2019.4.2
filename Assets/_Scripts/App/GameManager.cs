using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using ZXKFramework;

public class GameManager : MonoSingleton<GameManager>
{
    GameModel gameModel;

    int id;
    bool isa = false;

    [SerializeField]
    public List<GameObject> allLookModel;

    [SerializeField]
    public PlayerMovement playerMove;

    [SerializeField]
    public LookWithMouse playerRot;

    // Start is called before the first frame update
    void Start()
    {
        gameModel = MVC.GetModel<GameModel>();

        //GameObject go = transform.FindFirst("ClickGame");

        //for (int i = 0; i < go.transform.childCount; i++)
        //{
        //    SetMouseClickCallBack(go.transform.GetChild(i).name, ShowJieShaoWnd);
        //}
    }

    // Update is called once per frame
    //void Update()
    //{

    //    if (Input.GetKeyDown(KeyCode.A))
    //    {
    //        isa = true;
    //    }

    //    if (isa)
    //    {
    //        id++;
    //        MainData main = gameModel.excel.GetMainDataid(id);
    //        Sprite sp = Resources.Load<Sprite>(main.SpritePath);
    //        if (string.IsNullOrEmpty(main.TopTxt) || string.IsNullOrEmpty(main.Txt) || sp == null)
    //        {
    //            Debug.LogError("上面三个判断有空，无法赋值，检查表中名字为：" + id);
    //        }
    //        else
    //        {
    //            Game.Instance.uiManager.ShowUI<JieShaoWnd>(null, main.TopTxt, sp, main.Txt);
    //        }

    //        isa = false;
    //    }

    //}

    public void SetMouseClickCallBack(string name, Action<GameObject> callBack)
    {
        GameObject go = transform.FindFirst(name);
        if (go.TryGetComponent(out IClick click))
        {
            click.SetCallBack(callBack);
        }
    }

    /// <summary>
    /// 显示介绍界面
    /// </summary>
    /// <param name="go"></param>
    public void ShowJieShaoWnd(GameObject go)
    {
        MainData main = gameModel.excel.GetMainDataName(go.name);
        if (!main.Name.Equals("进门展台") && !main.Name.Equals("针阔混叶林区") && !main.Name.Equals("稀树草原区") && !main.Name.Equals("湿地区") && !main.Name.Equals("牡丹江流域区1") && !main.Name.Equals("珍惜濒危区") &&
            !main.Name.Equals("牡丹江流域区2") && !main.Name.Equals("生命支撑区") && !main.Name.Equals("农业区") && !main.Name.Equals("啮齿动物区") && !main.Name.Equals("动物多样性区") && !main.Name.Equals("北药区") &&
             !main.Name.Equals("植物标本区") && !main.Name.Equals("昆虫世界区") && !main.Name.Equals("海底世界区") && !main.Name.Equals("食用菌区"))
        {
            Sprite sp = Resources.Load<Sprite>(main.SpritePath);

            if (string.IsNullOrEmpty(main.TopTxt) || string.IsNullOrEmpty(main.Txt) || sp == null)
            {
                Debug.Log("上面三个判断有空，无法赋值，检查表中名字为：" + go.name);
            }
            else
            {
                Debug.LogError(main.TopTxt + ":" + main.id + main.Txt);
                Game.Instance.uiManager.ShowUI<JieShaoWnd>(null, main.TopTxt, sp, main.Txt);
            }
        }
        else
        {
            //有鳞目，游蛇科。又称黑松花，分布于黑龙江、吉林、辽宁、河北、山东、湖南、湖北、浙江、西伯利亚、朝鲜、日本等地，栖息于平原、山区的林边、草丛、耕地。
            Game.Instance.sound.PlayBGM(main.SoundPath, false);
        }

    }


    public void ShowGameModel(GameObject go)
    {
        playerMove.enabled = false;
        playerRot.enabled = false;
        for (int i = 0; i < allLookModel.Count; i++)
        {
            allLookModel[i].SetActive(false);
        }
        transform.FindFirst("Look_Canvas").SetActive(true);

        transform.FindFirst("Look_Canvas").FindFirst<Text>("biaoBenName_Txt").text = go.name;

        GameObject g = transform.FindFirst("Model").FindFirst(go.name);
        g.transform.localScale = Vector3.one;
        g.SetActive(true);
        gameModel.lookModel = g;
    }
}
