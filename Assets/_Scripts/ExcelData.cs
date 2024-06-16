
using System.Collections.Generic;
using UnityEngine;
namespace ZXKFramework 
{                                                 
    public class ExcelData
    {
        public List<MainData> allMainData  = null;

        public void Init()
        {  
            allMainData = ExcelDataTools.GetDataList<MainData>();

        }
        
public MainData GetMainData(int id)
{
    for (int i = 0; i < allMainData.Count; i++)
    {
        if (allMainData[i].id == id) 
        {
            return allMainData[i];
        }
    }
    Debug.LogError(id);
    return null;
}

public MainData GetMainDataid(int id)
{
    for (int i = 0; i < allMainData.Count; i++)
    {
        if (allMainData[i].id == id) 
        {
            return allMainData[i];
        }
    }
    Debug.LogError(id);
    return null;
}

public List<int> GetListMainDataid()
{
    List<int> res = new List<int>();
    for (int i = 0; i < allMainData.Count; i++)
    {
        if (!res.Contains(allMainData[i].id)) 
        {
            res.Add(allMainData[i].id);
        }
    }
    return res;
}



public MainData GetMainDataTopTxt(string TopTxt)
{
    for (int i = 0; i < allMainData.Count; i++)
    {
        if (allMainData[i].TopTxt == TopTxt) 
        {
            return allMainData[i];
        }
    }
    Debug.LogError(TopTxt);
    return null;
}

public List<string> GetListMainDataTopTxt()
{
    List<string> res = new List<string>();
    for (int i = 0; i < allMainData.Count; i++)
    {
        if (!res.Contains(allMainData[i].TopTxt)) 
        {
            res.Add(allMainData[i].TopTxt);
        }
    }
    return res;
}



public MainData GetMainDataName(string Name)
{
    for (int i = 0; i < allMainData.Count; i++)
    {
        if (allMainData[i].Name == Name) 
        {
            return allMainData[i];
        }
    }
    Debug.LogError(Name);
    return null;
}

public List<string> GetListMainDataName()
{
    List<string> res = new List<string>();
    for (int i = 0; i < allMainData.Count; i++)
    {
        if (!res.Contains(allMainData[i].Name)) 
        {
            res.Add(allMainData[i].Name);
        }
    }
    return res;
}



public MainData GetMainDataTxt(string Txt)
{
    for (int i = 0; i < allMainData.Count; i++)
    {
        if (allMainData[i].Txt == Txt) 
        {
            return allMainData[i];
        }
    }
    Debug.LogError(Txt);
    return null;
}

public List<string> GetListMainDataTxt()
{
    List<string> res = new List<string>();
    for (int i = 0; i < allMainData.Count; i++)
    {
        if (!res.Contains(allMainData[i].Txt)) 
        {
            res.Add(allMainData[i].Txt);
        }
    }
    return res;
}



public MainData GetMainDataSpritePath(string SpritePath)
{
    for (int i = 0; i < allMainData.Count; i++)
    {
        if (allMainData[i].SpritePath == SpritePath) 
        {
            return allMainData[i];
        }
    }
    Debug.LogError(SpritePath);
    return null;
}

public List<string> GetListMainDataSpritePath()
{
    List<string> res = new List<string>();
    for (int i = 0; i < allMainData.Count; i++)
    {
        if (!res.Contains(allMainData[i].SpritePath)) 
        {
            res.Add(allMainData[i].SpritePath);
        }
    }
    return res;
}



public MainData GetMainDataSoundPath(string SoundPath)
{
    for (int i = 0; i < allMainData.Count; i++)
    {
        if (allMainData[i].SoundPath == SoundPath) 
        {
            return allMainData[i];
        }
    }
    Debug.LogError(SoundPath);
    return null;
}

public List<string> GetListMainDataSoundPath()
{
    List<string> res = new List<string>();
    for (int i = 0; i < allMainData.Count; i++)
    {
        if (!res.Contains(allMainData[i].SoundPath)) 
        {
            res.Add(allMainData[i].SoundPath);
        }
    }
    return res;
}




    }
}
