using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class URLParameterDetector : MonoBehaviour
{
    [SerializeField] private string _defaultURL;

    private string _uri;
    private string _urlString;
    private Dictionary<string, string> _urlParameterData;

    private void Awake()
    {
        GetURLParameter();
    }

    private void GetURLParameter()
    {
#if UNITY_WEBGL && !UNITY_EDITOR
        _uri = Application.absoluteURL;
#else
        _uri = _defaultURL;
#endif
        _urlParameterData = new Dictionary<string, string>();
        if (Uri.IsWellFormedUriString(_defaultURL, UriKind.Absolute))
        {
            Uri uri = new(_uri);
            _urlString = uri.GetComponents(UriComponents.Query, UriFormat.SafeUnescaped);

            _urlParameterData = _urlString
                .Split('&')
                .Select(x => x.Split('='))
                .Where(x => x.Length == 2)
                .ToDictionary(x => x[0], x => x[1]);
        }
    }

    public string GetURLParameterValue(string parameter)
    {
        string parameterValue = "";

        foreach (KeyValuePair<string, string> query in _urlParameterData)
        {
            if (query.Key == parameter)
            {
                parameterValue = query.Value;
            }
        }

        return parameterValue;
    }
}
