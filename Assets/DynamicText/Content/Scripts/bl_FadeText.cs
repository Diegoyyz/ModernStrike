using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System;

public class bl_FadeText : MonoBehaviour {

    [Header("Global")]
    public bool Download = true;
    public string TextsURL = "";
    public List<string> Texts = new List<string>();
    [Header("Settings")]
    [Range(0.01f,5f)]
    public float FadeSpeed = 1.567f;
    public float WaitForNext = 5f;
    [Header("References")]
    [SerializeField]private Text mText = null;

    protected bool isOut = false;
    protected bool isDone = false;
    protected int CurrentText = 0;

    /// <summary>
    /// 
    /// </summary>
    void Awake()
    {
        if (Download)
        {
            StartCoroutine(GetTexts());
        }
        else
        {
            isDone = true;
            if (mText != null)
            {
                mText.text = Texts[CurrentText];
            }
            StartCoroutine(FadeText());
        }

    }
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    IEnumerator GetTexts()
    {
        WWW w = new WWW(TextsURL);
        yield return w;

        if (w.error != null)
        {
            Debug.LogError(w.error);
        }
        else
        {
            string[] separator = new string[] { "\n", "\r\n" };
            string t = w.text;
            string[] tsplit = t.Split(separator, StringSplitOptions.RemoveEmptyEntries);

            foreach (string str in tsplit)
            {
                Texts.Add(str);
            }
            RemoveCodes(Texts);
        }
    }

    /// <summary>
    /// Remove codes ([box])
    /// </summary>
    /// <param name="tl"></param>
    /// <returns></returns>
    private void RemoveCodes(List<string> tl)
    {
        List<string> t = new List<string>();
        t = tl;
        for (int ii = 0; ii < t.Count; ii++)
        {
            if (t[ii].Contains("[box]"))
            {
                t.RemoveAt(ii);
            }
        }
        Check(t);
    }
    /// <summary>
    /// Fix odd number from the list
    /// </summary>
    /// <param name="list"></param>
    void Check(List<string> list)
    {
        int num = 0;
        for (int ii = 0; ii < list.Count; ii++)
        {
            if (list[ii].Contains("[box]"))
            {
                num++;
            }
        }
        if (num > 0)
        {
            RemoveCodes(list);
            return;
        }
        //If pass test
        Texts = list;
        isDone = true;
        if (mText != null)
        {
            mText.text = Texts[CurrentText];
        }
        StartCoroutine(FadeText());
    }
 /// <summary>
 /// 
 /// </summary>
 /// <returns></returns>
    IEnumerator FadeText()
    {
        Color alpha = mText.color;
        if (isOut)
        {
            
            while (alpha.a < 1)
            {
                alpha.a += Time.deltaTime * FadeSpeed;
                mText.color = alpha;
                yield return null;
            }
            StartCoroutine(WaitNext(WaitForNext));
        }
        else
        {
            while (alpha.a > 0)
            {
                alpha.a -= Time.deltaTime * FadeSpeed;
                mText.color = alpha;
                yield return null;
            }
            StartCoroutine(WaitNext(0.75f));
        }
        if (isOut)
        {
            CurrentText = (CurrentText + 1) % Texts.Count;
            mText.text = Texts[CurrentText];
        }
        
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="t"></param>
    /// <returns></returns>
    IEnumerator WaitNext(float t)
    {
        isOut = !isOut;
        yield return new WaitForSeconds(t);
        StartCoroutine(FadeText());
    }
}