using System;
using System.Collections.Generic;
using UnityEngine;

namespace VTFServer
{
    public class ServerConnection : MonoBehaviour
    {
        [SerializeField] private string _serverURL;  

		void Update()
        {

        }
    }

    [Serializable]
    class RequestField
    {
        public string[] Fields;
        public string[] GroupFields;
        public string GroupField;
    }

    [Serializable]
    class SenderField
    {
        public List<object> Fields;
    }
}