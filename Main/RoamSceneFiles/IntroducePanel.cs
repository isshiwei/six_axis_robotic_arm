using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IntroducePanel : MonoBehaviour
{
    public RectTransform introducePanelRect;
    public Text introduceText;

    public void SetIntroduceText(string str)
    {
        if (string.IsNullOrEmpty(str))
        {
            gameObject.SetActive(false);
            return;
        }
        gameObject.SetActive(true);
        introduceText.text = InsertLineBreaks(str);;
        LayoutRebuilder.ForceRebuildLayoutImmediate(introducePanelRect);
    }
    // 设定的最大文本长度
    public int maxCharactersPerLine = 5;
    
    // 在指定的位置插入换行符
    private string InsertLineBreaks(string text)
    {
        string result = "";
        int charCount = 0;
        
        foreach (char c in text)
        {
            if (charCount >= maxCharactersPerLine)
            {
                result += '\n';
                charCount = 0;
            }
            result += c;
            charCount++;
        }

        return result;
    }
}
