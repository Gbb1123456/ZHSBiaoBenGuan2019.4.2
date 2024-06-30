using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using ZXKFramework;

public class DaoLanManager : MonoBehaviour
{

    PlayableDirector timeLine;
    Coroutine cor;

    GameModel gameModel;

    public void OnEnable()
    {
        gameModel = MVC.GetModel<GameModel>();

        gameModel.jieShaoID = false;
        gameModel.modelID = false;

        //Play14();
        timeLine = transform.FindFirst<PlayableDirector>("1");
        GameManager.Instance.playerMove.enabled = false;
        GameManager.Instance.playerRot.enabled = false;
        Game.Instance.uiManager.ShowUI<MaskWnd>();//显示遮罩UI
        timeLine.Play();//使用动画控制镜头移动

        //控制镜头移动完毕之后的逻辑
        cor = Game.Instance.IEnumeratorManager.Run((float)timeLine.duration, () =>
          {
              Game.Instance.uiManager.CloseUI<MaskWnd>();
              PlayTwo();
          });
    }

    /// <summary>
    /// 播放第二个动画
    /// </summary>
    public void PlayTwo()
    {
        gameModel.jieShaoID = false;
        gameModel.modelID = false;
        gameModel.daoLanModelCallBack = null;
        gameModel.daoLanJieShaoCallBack = null;
        timeLine = transform.FindFirst<PlayableDirector>("2");
        Game.Instance.uiManager.ShowUI<MaskWnd>();//显示遮罩UI
        timeLine.Play();
        cor = Game.Instance.IEnumeratorManager.Run((float)timeLine.duration, () =>
        {
            gameModel.daoLanJieShaoCallBack = () =>
            {
                if (gameModel.jieShaoID && !gameModel.modelID)
                {
                    GameManager.Instance.transform.FindFirst("模型查看").FindFirst<Animator>("东北虎").Play("变色");
                }
                if (gameModel.jieShaoID && gameModel.modelID)
                {
                    PlayThree();
                }
            };

            gameModel.daoLanModelCallBack = () =>
            {
                if (!gameModel.jieShaoID && gameModel.modelID)
                {
                    GameManager.Instance.transform.FindFirst("森林动物").FindFirst<Animator>("东北虎").Play("变色");
                }
                if (gameModel.jieShaoID && gameModel.modelID)
                {
                    PlayThree();
                }
            };
            Game.Instance.uiManager.CloseUI<MaskWnd>();//显示遮罩UI
            GameManager.Instance.transform.FindFirst("森林动物").FindFirst<Animator>("东北虎").Play("变色");

            //JieShaoWnd
        });
    }

    public void PlayThree()
    {
        gameModel.jieShaoID = false;
        gameModel.modelID = false;
        gameModel.daoLanModelCallBack = null;
        gameModel.daoLanJieShaoCallBack = null;
        timeLine = transform.FindFirst<PlayableDirector>("3");
        Game.Instance.uiManager.ShowUI<MaskWnd>();//显示遮罩UI
        timeLine.Play();
        cor = Game.Instance.IEnumeratorManager.Run((float)timeLine.duration, () =>
        {
            gameModel.daoLanJieShaoCallBack = () =>
            {
                if (gameModel.jieShaoID)
                {
                    Play4();
                }
            };
            Game.Instance.uiManager.CloseUI<MaskWnd>();//显示遮罩UI
            GameManager.Instance.transform.FindFirst("稀树草原动物").FindFirst<Animator>("豪猪").Play("变色");
        });
    }

    public void Play4()
    {
        gameModel.jieShaoID = false;
        gameModel.modelID = false;
        gameModel.daoLanModelCallBack = null;
        gameModel.daoLanJieShaoCallBack = null;
        timeLine = transform.FindFirst<PlayableDirector>("4");
        Game.Instance.uiManager.ShowUI<MaskWnd>();//显示遮罩UI
        timeLine.Play();
        cor = Game.Instance.IEnumeratorManager.Run((float)timeLine.duration, () =>
        {
            gameModel.daoLanJieShaoCallBack = () =>
            {
                if (gameModel.jieShaoID && !gameModel.modelID)
                {
                    GameManager.Instance.transform.FindFirst("模型查看").FindFirst<Animator>("丹顶鹤").Play("变色");
                }
                if (gameModel.jieShaoID && gameModel.modelID)
                {
                    Play5();
                }
            };

            gameModel.daoLanModelCallBack = () =>
            {
                if (!gameModel.jieShaoID && gameModel.modelID)
                {
                    GameManager.Instance.transform.FindFirst("湿地动物").FindFirst<Animator>("丹顶鹤").Play("变色");
                }
                if (gameModel.jieShaoID && gameModel.modelID)
                {
                    Play5();
                }
            };
            Game.Instance.uiManager.CloseUI<MaskWnd>();//显示遮罩UI
            GameManager.Instance.transform.FindFirst("湿地动物").FindFirst<Animator>("丹顶鹤").Play("变色");
        });
    }

    public void Play5()
    {
        gameModel.jieShaoID = false;
        gameModel.modelID = false;
        gameModel.daoLanModelCallBack = null;
        gameModel.daoLanJieShaoCallBack = null;
        timeLine = transform.FindFirst<PlayableDirector>("5");
        Game.Instance.uiManager.ShowUI<MaskWnd>();//显示遮罩UI
        timeLine.Play();
        cor = Game.Instance.IEnumeratorManager.Run((float)timeLine.duration, () =>
        {

            gameModel.daoLanModelCallBack = () =>
            {
                if (gameModel.modelID)
                {
                    Play6();
                }
            };

            //gameModel.daoLanJieShaoCallBack = () =>
            //{
            //    if (gameModel.jieShaoID && !gameModel.modelID)
            //    {
            //        GameManager.Instance.transform.FindFirst("模型查看").FindFirst<Animator>("鳙鱼").Play("变色");
            //    }
            //    if (gameModel.jieShaoID && gameModel.modelID)
            //    {
            //        Play6();
            //    }
            //};

            //gameModel.daoLanModelCallBack = () =>
            //{
            //    if (!gameModel.jieShaoID && gameModel.modelID)
            //    {
            //        GameManager.Instance.transform.FindFirst("牡丹江流域野生动物").FindFirst<Animator>("中华鳖").Play("变色");
            //    }
            //    if (gameModel.jieShaoID && gameModel.modelID)
            //    {
            //        Play6();
            //    }
            //};
            Game.Instance.uiManager.CloseUI<MaskWnd>();//显示遮罩UI
            //GameManager.Instance.transform.FindFirst("牡丹江流域野生动物").FindFirst<Animator>("中华鳖").Play("变色");
            GameManager.Instance.transform.FindFirst("模型查看").FindFirst<Animator>("鳙鱼").Play("变色");
        });
    }

    public void Play6()
    {
        gameModel.jieShaoID = false;
        gameModel.modelID = false;
        gameModel.daoLanModelCallBack = null;
        gameModel.daoLanJieShaoCallBack = null;
        timeLine = transform.FindFirst<PlayableDirector>("6");
        Game.Instance.uiManager.ShowUI<MaskWnd>();//显示遮罩UI
        timeLine.Play();
        cor = Game.Instance.IEnumeratorManager.Run((float)timeLine.duration, () =>
        {
            gameModel.daoLanJieShaoCallBack = () =>
            {
                if (gameModel.jieShaoID && !gameModel.modelID)
                {
                    GameManager.Instance.transform.FindFirst("模型查看").FindFirst<Animator>("棕黑锦蛇").Play("变色");
                }
                if (gameModel.jieShaoID && gameModel.modelID)
                {
                    Play7();
                }
            };

            gameModel.daoLanModelCallBack = () =>
            {
                if (!gameModel.jieShaoID && gameModel.modelID)
                {
                    GameManager.Instance.transform.FindFirst("牡丹江流域野生动物").FindFirst<Animator>("棕黑锦蛇").Play("变色");
                }
                if (gameModel.jieShaoID && gameModel.modelID)
                {
                    Play7();
                }
            };
            Game.Instance.uiManager.CloseUI<MaskWnd>();//显示遮罩UI
            GameManager.Instance.transform.FindFirst("牡丹江流域野生动物").FindFirst<Animator>("棕黑锦蛇").Play("变色");
        });
    }

    public void Play7()
    {
        gameModel.jieShaoID = false;
        gameModel.modelID = false;
        gameModel.daoLanModelCallBack = null;
        gameModel.daoLanJieShaoCallBack = null;
        timeLine = transform.FindFirst<PlayableDirector>("7");
        Game.Instance.uiManager.ShowUI<MaskWnd>();//显示遮罩UI
        timeLine.Play();
        cor = Game.Instance.IEnumeratorManager.Run((float)timeLine.duration, () =>
        {
            gameModel.daoLanJieShaoCallBack = () =>
            {
                if (gameModel.jieShaoID && !gameModel.modelID)
                {
                    GameManager.Instance.transform.FindFirst("模型查看").FindFirst<Animator>("金雕").Play("变色");
                }
                if (gameModel.jieShaoID && gameModel.modelID)
                {
                    Play8();
                }
            };

            gameModel.daoLanModelCallBack = () =>
            {
                if (!gameModel.jieShaoID && gameModel.modelID)
                {
                    GameManager.Instance.transform.FindFirst("牡丹江流域野生动物").FindFirst<Animator>("金雕").Play("变色");
                }
                if (gameModel.jieShaoID && gameModel.modelID)
                {
                    Play8();
                }
            };
            Game.Instance.uiManager.CloseUI<MaskWnd>();//显示遮罩UI
            GameManager.Instance.transform.FindFirst("牡丹江流域野生动物").FindFirst<Animator>("金雕").Play("变色");
        });
    }

    public void Play8()
    {
        gameModel.jieShaoID = false;
        gameModel.modelID = false;
        gameModel.daoLanModelCallBack = null;
        gameModel.daoLanJieShaoCallBack = null;
        timeLine = transform.FindFirst<PlayableDirector>("8");
        Game.Instance.uiManager.ShowUI<MaskWnd>();//显示遮罩UI
        timeLine.Play();
        cor = Game.Instance.IEnumeratorManager.Run((float)timeLine.duration, () =>
        {
            gameModel.daoLanJieShaoCallBack = () =>
            {
                if (gameModel.jieShaoID && !gameModel.modelID)
                {
                    GameManager.Instance.transform.FindFirst("模型查看").FindFirst<Animator>("黑熊").Play("变色");
                }
                if (gameModel.jieShaoID && gameModel.modelID)
                {
                    Play9();
                }
            };

            gameModel.daoLanModelCallBack = () =>
            {
                if (!gameModel.jieShaoID && gameModel.modelID)
                {
                    GameManager.Instance.transform.FindFirst("牡丹江流域野生动物").FindFirst<Animator>("亚洲黑熊").Play("变色");
                }
                if (gameModel.jieShaoID && gameModel.modelID)
                {
                    Play9();
                }
            };
            Game.Instance.uiManager.CloseUI<MaskWnd>();//显示遮罩UI
            GameManager.Instance.transform.FindFirst("牡丹江流域野生动物").FindFirst<Animator>("亚洲黑熊").Play("变色");
        });
    }


    public void Play9()
    {
        gameModel.jieShaoID = false;
        gameModel.modelID = false;
        gameModel.daoLanModelCallBack = null;
        gameModel.daoLanJieShaoCallBack = null;
        timeLine = transform.FindFirst<PlayableDirector>("9");
        Game.Instance.uiManager.ShowUI<MaskWnd>();//显示遮罩UI
        timeLine.Play();
        cor = Game.Instance.IEnumeratorManager.Run((float)timeLine.duration, () =>
        {
            Game.Instance.uiManager.CloseUI<MaskWnd>();//显示遮罩UI
            Play10();
        });
    }

    public void Play10()
    {
        gameModel.jieShaoID = false;
        gameModel.modelID = false;
        gameModel.daoLanModelCallBack = null;
        gameModel.daoLanJieShaoCallBack = null;
        timeLine = transform.FindFirst<PlayableDirector>("10");
        Game.Instance.uiManager.ShowUI<MaskWnd>();//显示遮罩UI
        timeLine.Play();
        cor = Game.Instance.IEnumeratorManager.Run((float)timeLine.duration, () =>
        {
            Game.Instance.uiManager.CloseUI<MaskWnd>();//显示遮罩UI
            Play11();
        });
    }

    public void Play11()
    {
        gameModel.jieShaoID = false;
        gameModel.modelID = false;
        gameModel.daoLanModelCallBack = null;
        gameModel.daoLanJieShaoCallBack = null;
        timeLine = transform.FindFirst<PlayableDirector>("11");
        Game.Instance.uiManager.ShowUI<MaskWnd>();//显示遮罩UI
        timeLine.Play();
        cor = Game.Instance.IEnumeratorManager.Run((float)timeLine.duration, () =>
        {
            Game.Instance.uiManager.CloseUI<MaskWnd>();//显示遮罩UI
            Play12();
        });
    }

    public void Play12()
    {
        gameModel.jieShaoID = false;
        gameModel.modelID = false;
        gameModel.daoLanModelCallBack = null;
        gameModel.daoLanJieShaoCallBack = null;
        timeLine = transform.FindFirst<PlayableDirector>("12");
        Game.Instance.uiManager.ShowUI<MaskWnd>();//显示遮罩UI
        timeLine.Play();
        cor = Game.Instance.IEnumeratorManager.Run((float)timeLine.duration, () =>
        {
            gameModel.daoLanJieShaoCallBack = () =>
            {
                if (gameModel.jieShaoID)
                {
                    Play13();
                }
            };
            Game.Instance.uiManager.CloseUI<MaskWnd>();//显示遮罩UI
            GameManager.Instance.transform.FindFirst("牡丹江流域植物资源").FindFirst<Animator>("蒙古栎").Play("变色");
        });
    }

    public void Play13()
    {
        gameModel.jieShaoID = false;
        gameModel.modelID = false;
        gameModel.daoLanModelCallBack = null;
        gameModel.daoLanJieShaoCallBack = null;
        timeLine = transform.FindFirst<PlayableDirector>("13");
        Game.Instance.uiManager.ShowUI<MaskWnd>();//显示遮罩UI
        timeLine.Play();
        cor = Game.Instance.IEnumeratorManager.Run((float)timeLine.duration, () =>
        {
            gameModel.daoLanJieShaoCallBack = () =>
            {
                if (gameModel.jieShaoID && !gameModel.modelID)
                {
                    GameManager.Instance.transform.FindFirst("模型查看").FindFirst<Animator>("三尾凤蝶").Play("变色");
                }
                if (gameModel.jieShaoID && gameModel.modelID)
                {
                    Play14();
                }
            };

            gameModel.daoLanModelCallBack = () =>
            {
                if (!gameModel.jieShaoID && gameModel.modelID)
                {
                    GameManager.Instance.transform.FindFirst("昆虫世界").FindFirst<Animator>("三尾凤蝶").Play("变色");
                }
                if (gameModel.jieShaoID && gameModel.modelID)
                {
                    Play14();
                }
            };
            Game.Instance.uiManager.CloseUI<MaskWnd>();//显示遮罩UI
            GameManager.Instance.transform.FindFirst("昆虫世界").FindFirst<Animator>("三尾凤蝶").Play("变色");
        });
    }

    public void Play14()
    {
        gameModel.jieShaoID = false;
        gameModel.modelID = false;
        gameModel.daoLanModelCallBack = null;
        gameModel.daoLanJieShaoCallBack = null;
        timeLine = transform.FindFirst<PlayableDirector>("14");
        GameManager.Instance.playerMove.enabled = false;
        GameManager.Instance.playerRot.enabled = false;
        Game.Instance.uiManager.ShowUI<MaskWnd>();//显示遮罩UI
        timeLine.Play();//使用动画控制镜头移动

        //控制镜头移动完毕之后的逻辑
        //cor = Game.Instance.IEnumeratorManager.Run((float)timeLine.duration, () =>
        //{
        //    Game.Instance.uiManager.CloseUI<MaskWnd>();
        //    Play15();
        //});
        cor = Game.Instance.IEnumeratorManager.Run((float)timeLine.duration, () =>
        {

            gameModel.daoLanModelCallBack = () =>
            {
                if (gameModel.modelID)
                {
                    Play15();
                }
            };

            //gameModel.daoLanJieShaoCallBack = () =>
            //{
            //    if (gameModel.jieShaoID && !gameModel.modelID)
            //    {
            //        GameManager.Instance.transform.FindFirst("模型查看").FindFirst<Animator>("木耳").Play("变色");
            //    }
            //    if (gameModel.jieShaoID && gameModel.modelID)
            //    {
            //        Play15();
            //    }
            //};

            //gameModel.daoLanModelCallBack = () =>
            //{
            //    if (!gameModel.jieShaoID && gameModel.modelID)
            //    {
            //        GameManager.Instance.transform.FindFirst("农作物").FindFirst<Animator>("木耳").Play("变色");
            //    }
            //    if (gameModel.jieShaoID && gameModel.modelID)
            //    {
            //        Play15();
            //    }
            //};
            Game.Instance.uiManager.CloseUI<MaskWnd>();//显示遮罩UI
            //GameManager.Instance.transform.FindFirst("农作物").FindFirst<Animator>("木耳").Play("变色");
            GameManager.Instance.transform.FindFirst("模型查看").FindFirst<Animator>("木耳").Play("变色");
        });
    }

    public void Play15()
    {
        gameModel.jieShaoID = false;
        gameModel.modelID = false;
        gameModel.daoLanModelCallBack = null;
        gameModel.daoLanJieShaoCallBack = null;
        timeLine = transform.FindFirst<PlayableDirector>("15");
        GameManager.Instance.playerMove.enabled = false;
        GameManager.Instance.playerRot.enabled = false;
        Game.Instance.uiManager.ShowUI<MaskWnd>();//显示遮罩UI
        timeLine.Play();//使用动画控制镜头移动

        //控制镜头移动完毕之后的逻辑
        cor = Game.Instance.IEnumeratorManager.Run((float)timeLine.duration, () =>
        {
            Game.Instance.uiManager.CloseUI<MaskWnd>();
            Play16();
        });
    }

    public void Play16()
    {
        gameModel.jieShaoID = false;
        gameModel.modelID = false;
        gameModel.daoLanModelCallBack = null;
        gameModel.daoLanJieShaoCallBack = null;
        timeLine = transform.FindFirst<PlayableDirector>("16");
        Game.Instance.uiManager.ShowUI<MaskWnd>();//显示遮罩UI
        timeLine.Play();


        cor = Game.Instance.IEnumeratorManager.Run((float)timeLine.duration, () =>
        {
            Game.Instance.uiManager.CloseUI<MaskWnd>();
            Play17();
        });

        //cor = Game.Instance.IEnumeratorManager.Run((float)timeLine.duration, () =>
        //{
        //    gameModel.daoLanJieShaoCallBack = () =>
        //    {
        //        if (gameModel.jieShaoID && !gameModel.modelID)
        //        {
        //            GameManager.Instance.transform.FindFirst("模型查看").FindFirst<Animator>("木耳").Play("变色");
        //        }
        //        if (gameModel.jieShaoID && gameModel.modelID)
        //        {
        //            Play17();
        //        }
        //    };

        //    gameModel.daoLanModelCallBack = () =>
        //    {
        //        if (!gameModel.jieShaoID && gameModel.modelID)
        //        {
        //            GameManager.Instance.transform.FindFirst("农作物").FindFirst<Animator>("木耳").Play("变色");
        //        }
        //        if (gameModel.jieShaoID && gameModel.modelID)
        //        {
        //            Play17();
        //        }
        //    };
        //    Game.Instance.uiManager.CloseUI<MaskWnd>();//显示遮罩UI
        //    GameManager.Instance.transform.FindFirst("农作物").FindFirst<Animator>("木耳").Play("变色");
        //});
    }

    public void Play17()
    {
        gameModel.jieShaoID = false;
        gameModel.modelID = false;
        gameModel.daoLanModelCallBack = null;
        gameModel.daoLanJieShaoCallBack = null;
        timeLine = transform.FindFirst<PlayableDirector>("17");
        GameManager.Instance.playerMove.enabled = false;
        GameManager.Instance.playerRot.enabled = false;
        Game.Instance.uiManager.ShowUI<MaskWnd>();//显示遮罩UI
        timeLine.Play();//使用动画控制镜头移动

        //控制镜头移动完毕之后的逻辑
        cor = Game.Instance.IEnumeratorManager.Run((float)timeLine.duration, () =>
        {
            Game.Instance.uiManager.CloseUI<MaskWnd>();
            Play17_1();
        });
    }

    public void Play17_1()
    {
        gameModel.jieShaoID = false;
        gameModel.modelID = false;
        gameModel.daoLanModelCallBack = null;
        gameModel.daoLanJieShaoCallBack = null;
        timeLine = transform.FindFirst<PlayableDirector>("17_1");
        Game.Instance.uiManager.ShowUI<MaskWnd>();//显示遮罩UI
        timeLine.Play();
        cor = Game.Instance.IEnumeratorManager.Run((float)timeLine.duration, () =>
        {
            gameModel.daoLanJieShaoCallBack = () =>
            {
                if (gameModel.jieShaoID)
                {
                    Play18();
                }
            };
            Game.Instance.uiManager.CloseUI<MaskWnd>();//显示遮罩UI
            GameManager.Instance.transform.FindFirst("珍稀动物").FindFirst<Animator>("金丝猴").Play("变色");
        });
    }

    public void Play18()
    {
        gameModel.jieShaoID = false;
        gameModel.modelID = false;
        gameModel.daoLanModelCallBack = null;
        gameModel.daoLanJieShaoCallBack = null;
        timeLine = transform.FindFirst<PlayableDirector>("18");
        GameManager.Instance.playerMove.enabled = false;
        GameManager.Instance.playerRot.enabled = false;
        Game.Instance.uiManager.ShowUI<MaskWnd>();//显示遮罩UI
        timeLine.Play();//使用动画控制镜头移动

        //控制镜头移动完毕之后的逻辑
        cor = Game.Instance.IEnumeratorManager.Run((float)timeLine.duration, () =>
        {
            Game.Instance.uiManager.CloseUI<MaskWnd>();
            //Play18();
            Game.Instance.uiManager.ShowUI<SeleceWnd>();
            GameManager.Instance.playerMove.enabled = true;
            GameManager.Instance.playerRot.enabled = true;

            Game.Instance.IEnumeratorManager.Stop(cor);
            GetComponent<DaoLanManager>().enabled = false;
            Game.Instance.uiManager.CloseUI<MapWnd>();
        });
    }

    public void OnDisable()
    {
        gameModel.jieShaoID = false;
        gameModel.modelID = false;
        gameModel.daoLanModelCallBack = null;
        gameModel.daoLanJieShaoCallBack = null;
        if (cor != null)
        {
            timeLine.Stop();
            timeLine = null;
            StopCoroutine(cor);
            cor = null;
        }
    }
}
