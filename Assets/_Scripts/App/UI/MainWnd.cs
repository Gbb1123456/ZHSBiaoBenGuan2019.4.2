﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
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
            if (gameModel.seleceModel.Equals(SeleceModel.zhengchang))
            {
                GameManager.Instance.playerMove.transform.position = GameManager.Instance.startPos;
                GameManager.Instance.playerRot.transform.rotation = GameManager.Instance.startRot;                
            }
            if (GameManager.Instance.isCloseModelAndUI)
            {
                GuanChaWanBi.Instance.CloseModelAndUI();
            }
            Game.Instance.sound.StopBGM();
            //Application.Quit();
        });
    }



}
