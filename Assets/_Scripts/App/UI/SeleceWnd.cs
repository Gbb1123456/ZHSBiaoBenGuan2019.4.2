using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using ZXKFramework;

public enum SeleceModel
{
    daolan,
    zhengchang,
    Null
}

public class SeleceWnd : UIBase
{
    public override string GroupName => "SeleceWnd";

    public override string Name => "SeleceWnd";

    Button daolan_Btn;
    Button zhengchang_Btn;

    GameModel gameModel;

    public override void Init(IUIManager uictrl)
    {
        base.Init(uictrl);

        gameModel = MVC.GetModel<GameModel>();
        daolan_Btn = transform.FindFirst<Button>("daolan_Btn");
        zhengchang_Btn = transform.FindFirst<Button>("zhengchang_Btn");

        daolan_Btn.onClick.AddListener(() =>
        {
            gameModel.seleceModel = SeleceModel.daolan;
            Game.Instance.uiManager.CloseUI<SeleceWnd>();
            Game.Instance.uiManager.ShowUI<MapWnd>();
            GameManager.Instance.transform.FindFirst<DaoLanManager>("DaoLanManager").enabled = true;
        });

        zhengchang_Btn.onClick.AddListener(() =>
        {
            gameModel.seleceModel = SeleceModel.zhengchang;
            GameManager.Instance.transform.FindFirst<DaoLanManager>("DaoLanManager").enabled = false;
            Game.Instance.uiManager.CloseUI<SeleceWnd>();

            Game.Instance.uiManager.ShowUI<HelpWnd>();
            Game.Instance.uiManager.ShowUI<MainWnd>();
            Game.Instance.uiManager.ShowUI<MapWnd>();
        });
    }
}
