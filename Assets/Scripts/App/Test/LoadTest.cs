
using System;
using System.Collections;
using App.Utils;
using UnityEngine;
using UnityEngine.Events;

public class LoadTest : MonoBehaviour
{

    private IEnumerator _cache;
    
    private UnityAction<string, UnityAction> _callback;

    private IEnumerator _current;

    private string _str;
    private UnityAction _onComplete;

    private void Awake()
    {
        _cache = Run();
        
        StartCoroutine(_cache);
        _current = GetBundle();
    }

    private void Start()
    {
        SetParameters("1", () =>
        {
            Debug.Log("complete");
        });
        
        SetParameters("2", () =>
        {
            Debug.Log("complete");
        });
        
        SetParameters("3", () =>
        {
            Debug.Log("complete");
        });
        
        SetParameters("4", () =>
        {
            Debug.Log("complete");
        });
    }

    public void SetParameters(string str, UnityAction onComplete)
    {
        _str = str;
        _onComplete = onComplete;
    }

    private IEnumerator GetBundle()
    {
        Debug.Log(_str);
        yield return null;
        yield return null;
        yield return null;
        
        _onComplete?.Invoke();
    }

    private IEnumerator Run()
    {
        while (true)
        {
            if (_current != null && _current.MoveNext())
                yield return _current?.Current;
            else
                yield return null;
        }
        
    } 
}