using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZXKFramework;

public class GameModel : Model
{
    public override string Name => "gameModel";

    public ExcelData excel;

    public GameObject lookModel;

    public bool jieShaoID;
    public bool modelID;

    public SeleceModel seleceModel;

    public Action daoLanJieShaoCallBack;

    public Action daoLanModelCallBack;
    public void Init()
    {
        excel = new ExcelData();
        excel.Init();
    }
}
