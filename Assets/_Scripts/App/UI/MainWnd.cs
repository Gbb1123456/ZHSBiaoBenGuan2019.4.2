using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using WisdomTree.Common.Function;
using ZXKFramework;

public class MainWnd : UIBase
{
    public override string GroupName => "MainWnd";

    public override string Name => "MainWnd";

    Button exit_Btn;
    Button maxScreen_Btn;
    Button help_Btn;
    Button tiJiao_Btn;
    GameModel gameModel;

    public override void Init(IUIManager uictrl)
    {
        base.Init(uictrl);
        gameModel = MVC.GetModel<GameModel>();

        exit_Btn = transform.FindFirst<Button>("exit_Btn");

        maxScreen_Btn = transform.FindFirst<Button>("maxScreen_Btn");

        help_Btn = transform.FindFirst<Button>("help_Btn");

        tiJiao_Btn = transform.FindFirst<Button>("tiJiao_Btn");

        help_Btn.onClick.AddListener(() =>
        {
            Game.Instance.uiManager.ShowUI<HelpWnd>();
        });
        tiJiao_Btn.AddListener(() =>
        {
            Game.Instance.uiManager.ShowUI<ResultWnd>();
        });
        exit_Btn.onClick.AddListener(() =>
        {
            GameManager.Instance.transform.FindFirst<DaoLanManager>("DaoLanManager").enabled = false;
            Game.Instance.uiManager.CloseGroup();
            Game.Instance.uiManager.ShowUI<SeleceWnd>();
            Game.Instance.uiManager.ShowUI<MainWnd>();
            //if (gameModel.seleceModel.Equals(SeleceModel.zhengchang))
            //{
            GameManager.Instance.playerMove.transform.position = GameManager.Instance.startPos;
            GameManager.Instance.playerMove.transform.rotation = GameManager.Instance.startRot;
            GameManager.Instance.playerRot.transform.localRotation = new Quaternion(0, 0, 0, 0);
            //}
            if (GameManager.Instance.isCloseModelAndUI)
            {
                GuanChaWanBi.Instance.CloseModelAndUI();
            }
            if (GameManager.Instance.cor!=null)
            {
                Game.Instance.IEnumeratorManager.Stop(GameManager.Instance.cor);
            }
            GameManager.Instance.audioGame.SetActive(false);
            Game.Instance.sound.StopBGM();
            //Application.Quit();
            Result();
        });

    }
    private void Result()
    {
        double zhi = 0;
        zhi = StartGame.Objstring.Count * 12.5f;
        Debug.Log(zhi);
        Communication.Log = true;
        //Communication.UploadReport(zhi, "实验总结内容", url => Communication.OpenWebReport(url),
        //    new WisdomTree.Common.Function.Model("浏览结果", new Content("浏览结果：", StringTxt())));

        WisdomTree.Common.Function.Communication.UploadReport(zhi, "实验总结内容", url => Communication.OpenWebReport(url),
             new WisdomTree.Common.Function.Model("浏览结果", new Content("浏览结果：", StringTxt())));
    }
    private string StringTxt()
    {
        string txt = "";
        for (int i = 0; i < StartGame.Objstring.Count; i++)
        {
            txt += StartGame.Objstring[i] + "已浏览\n";
        }
        return txt;
    }



}
