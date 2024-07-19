using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using ZXKFramework;

public class JieShaoWnd : UIBase
{
    public override string GroupName => "JieShaoWnd";

    public override string Name => "JieShaoWnd";

    Text topTxt;
    Image tuPian_Img;
    Text txt;
    Button exit_Btn;
    GameModel gameModel;

    public override void Init(IUIManager uictrl)
    {
        base.Init(uictrl);
        gameModel = MVC.GetModel<GameModel>();
        topTxt = transform.FindFirst<Text>("topTxt");
        tuPian_Img = transform.FindFirst<Image>("tuPian_Img");
        txt = transform.FindFirst<Text>("txt");
        exit_Btn = transform.FindFirst<Button>("exit_Btn");

        exit_Btn.onClick.AddListener(() =>
        {
            GameManager.Instance.transform.FindFirst("PlayerControllerFPS").GetComponent<FirstPersonController>().enabled = true;
            Game.Instance.uiManager.CloseUI<JieShaoWnd>();
            //Game.Instance.sound.StopBGM();
        });
    }

    public override void ShowData(params object[] obj)
    {
        base.ShowData(obj);

        topTxt.text = obj[0].ToString();
        tuPian_Img.sprite = obj[1] as Sprite;
        txt.text = "<color=#FFFFFF00>首缩</color>" + obj[2].ToString();
    }

    public override void Show()
    {
        base.Show();
    }

    public override void Hide()
    {
        base.Hide();


    }

    private void OnDisable()
    {
        if (gameModel.seleceModel.Equals(SeleceModel.daolan))
        {
            gameModel.jieShaoID = true;
            gameModel.daoLanJieShaoCallBack?.Invoke();
        }
    }
}
