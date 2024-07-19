using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.UI;

public class TextSymbolWrap : MonoBehaviour
{
    // Start is called before the first frame update
    public Text textCom;
    private string origStr;
    private string replaceStr;
    private string finalReplaceStr;

    /// 标记不换行的空格（换行空格Unicode编码为/u0020，不换行的/u00A0）
	public static readonly string Non_breaking_space = "\u00A0";

    /// 用于匹配标点符号，为了不破坏富文本标签，所以只匹配指定的符号
    private readonly string strPunctuation = @"[，。?？！!…、]";

    /// 用于存储text组件中的内容
    private System.Text.StringBuilder TempText = null;

    /// 用于存储text生成器中的内容
    private IList<UILineInfo> TextLine;

    private int screenWidth = 0;
    private int screenHeight = 0;
    //在替换后的文本最后面添加一个看不到的字符，以用于辨别当前输入的文本是不是原始文本
    private string endString = "　";

    private bool isReplacing = false;

    void Start()
    {

    }
    private void OnEnable()
    {
        isReplacing = false;
        CheckTextComponent();
        CheckScreenSizeChange();
        ReplaceTextFun();
    }
    // Update is called once per frame
    void Update()
    {
        if (CheckScreenSizeChange() == true)
        {
            if (textCom != null && string.IsNullOrEmpty(origStr) == false)
            {
                if (textCom != null)
                {
                    textCom.text = origStr;
                }
                replaceStr = "";
                finalReplaceStr = "";
            }
        }
        CheckReplaceText();
    }

    private bool CheckScreenSizeChange()
    {
        if (Screen.width != screenWidth || Screen.height != screenHeight)
        {
            screenWidth = Screen.width;
            screenHeight = Screen.height;
            return true;
        }
        else
        {
            return false;
        }
    }

    private void CheckTextComponent()
    {
        if (textCom != null)
        {
            return;
        }
        textCom = this.gameObject.GetComponent<Text>();
    }

    private void CheckReplaceText()
    {
        if (textCom == null)
        {
            return;
        }
        if (CheckTextIsChange() == false)
        {
            return;
        }
        ReplaceTextFun();
    }

    private void ReplaceTextFun()
    {
        if (isReplacing == true)
        {
            return;
        }

        replaceStr = "";
        finalReplaceStr = "";
        StartCoroutine("ClearUpPunctuationMode", textCom);
    }

    private bool CheckTextIsChange()
    {
        if (textCom == null)
        {
            return false;
        }
        string txt = textCom.text;
        if (string.Equals(txt, finalReplaceStr) == true)
        {
            return false;
        }
        return true;
    }

    IEnumerator ClearUpPunctuationMode(Text _component)
    {
        isReplacing = true;
        //不能立刻就进行计算，要等起码渲染完上一帧才计算，所以延迟了60毫秒
        yield return new WaitForSeconds(0.06f);

        if (string.IsNullOrEmpty(_component.text))
        {
            isReplacing = false;
        }
        else
        {
            //清除上一次添加的换行符号
            //_component.text = _component.text.Replace(" ", string.Empty);
            string tempTxt = _component.text;
            bool isOrigStr = false;
            if (tempTxt[tempTxt.Length - 1].ToString() != endString)
            {
                //如果结尾没有空白字符，就认为是原始的字符串，记录下来用于分辨率改变时再次计算
                origStr = tempTxt;
                isOrigStr = true;
            }
            TextLine = _component.cachedTextGenerator.lines;
            //需要改变的字符序号
            int ChangeIndex = -1;
            TempText = new System.Text.StringBuilder(_component.text);
            for (int i = 1; i < TextLine.Count; i++)
            {
                //首位是否有标点
                UILineInfo lineInfo = TextLine[i];
                int startCharIdx = lineInfo.startCharIdx;
                if (TempText.Length <= startCharIdx)
                {
                    continue;
                }
                bool IsPunctuation = Regex.IsMatch(TempText[startCharIdx].ToString(), strPunctuation);
                //因为将换行空格都改成不换行空格后需要另外判断下如果首字符是不换行空格那么还是需要调整换行字符的下标
                if (TempText[TextLine[i].startCharIdx].ToString() == Non_breaking_space)
                {
                    IsPunctuation = true;
                }

                //没有标点就跳过本次循环
                if (!IsPunctuation)
                {
                    continue;
                }
                else
                {
                    //有标点时保存当前下标
                    ChangeIndex = TextLine[i].startCharIdx;
                    //下面这个循环是为了判断当已经提前一个字符后当前这个的首字符还是标点时做的继续提前字符的处理
                    while (IsPunctuation)
                    {
                        ChangeIndex = ChangeIndex - 1;
                        if (ChangeIndex < 0) break;

                        IsPunctuation = Regex.IsMatch(TempText[ChangeIndex].ToString(), strPunctuation);
                        //因为将换行空格都改成不换行空格后需要另外判断下如果首字符是不换行空格那么还是需要调整换行字符的下标
                        if (TempText[ChangeIndex].ToString() == Non_breaking_space)
                        {
                            IsPunctuation = true;
                        }

                    }
                    if (ChangeIndex < 0) continue;

                    if (TempText[ChangeIndex - 1] != '\n')
                        TempText.Insert(ChangeIndex, "\n");
                }

            }

            replaceStr = TempText.ToString();
            if (string.Equals(tempTxt, replaceStr) == false)
            {
                //如果计算出来的最后结果和text组件当前的字符串不一致，证明有改动，改动后还需要继续判断
                //因为有可能在插入换行后，其他的地方会出现问题
                if (isOrigStr)
                {
                    replaceStr += endString;
                }
                _component.text = replaceStr;

            }
            else
            {
                //计算后的结果和当前text组件的字符串一致，证明当前text组件的字符串已经没有问题
                //记录下来，用于判断当前的字符串是否有改变
                finalReplaceStr = replaceStr;
            }
            isReplacing = false;
        }
    }
}
