using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System;

public class bl_BoxNews : MonoBehaviour {

    [Header("Global")]
    public bool Download = true;
    public string TextsURL = "";
    public List<string> Texts = new List<string>();

    [Header("Settings")]
    public TransType m_Type = TransType.TypeWriter;
    [Range(0.001f, 1.0f)]
    public float RaterLetter = 0.02f;
    [Range(0.01f, 5.0f)]
    public float FadeSpeed = 1.5371f;
    public float WaitForNext = 5f;
    [Header("References")]
    public Text mText = null;


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
            string t = w.text;
            Texts = ParseSymbol(t);
            isDone = true;
            if (Texts.Count > 1)
            {
                if (m_Type == TransType.TypeWriter)
                {
                    StartCoroutine(TypeWritterIE(Texts[CurrentText]));
                }
                else
                {
                    StartCoroutine(FadeText());
                }
            }
            else
            {
                mText.text = Texts[0];
            }
        }
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="str"></param>
    /// <returns></returns>
    IEnumerator TypeWritterIE(string str)
    {
        foreach (char letter in str.ToCharArray())
        {
            if (mText != null)
            {
                mText.text += letter;
            }
            yield return null;
            yield return new WaitForSeconds(RaterLetter);
        }
        StartCoroutine(WaitNext());
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
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    IEnumerator WaitNext()
    {
        CurrentText = (CurrentText + 1) % Texts.Count;
        yield return new WaitForSeconds(WaitForNext);
        mText.text = string.Empty;
        StartCoroutine(TypeWritterIE(Texts[CurrentText]));
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="str"></param>
    /// <returns></returns>
    public List<string> ParseSymbol(string str)
    {
        string[] separator = new string[] { "[box]" };
        string[] t = str.Split(separator, StringSplitOptions.RemoveEmptyEntries);
        List<string> texts = new List<string>();

        foreach (string _t in t)
        {
            texts.Add(_t);
        }

        texts.RemoveAt(0);
        return texts;
    }

    [System.Serializable]
    public enum TransType
    {
        TypeWriter,
        Fade,
    }
}