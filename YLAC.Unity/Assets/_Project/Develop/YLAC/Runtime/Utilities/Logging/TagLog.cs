using System;
using UnityEngine;
using Debug = UnityEngine.Debug;

namespace CompanyName.UEPT.Runtime.Utilities.Logging
{
    public sealed class TagLog
    {
        private readonly string _tag;
        private readonly string _partTag;

        public TagLog(string tag)
        {
            if (string.IsNullOrEmpty(tag)) {
                _tag = string.Empty;
                _partTag = "[";
            }
            else {
                _tag = '[' + tag + "] ";
                _partTag = '[' + tag + ':';
            }
        }

#if COMPANYNAME_PROD
        [System.Diagnostics.Conditional("DUMMY_UNUSED_DEFINE")]
#endif
        [HideInCallstack]
        public void D(string msg)
        {
            Debug.unityLogger.Log(LogType.Log, _tag, msg);
        }
        
#if COMPANYNAME_PROD
        [System.Diagnostics.Conditional("DUMMY_UNUSED_DEFINE")]
#endif
        [HideInCallstack]
        public void D(string additionalTag, string msg)
        {
            Debug.unityLogger.Log(LogType.Log, GetFullTag(additionalTag), msg);
        }

        [HideInCallstack]
        public void W(string msg)
        {
            Debug.unityLogger.Log(LogType.Warning, _tag, msg);
        }

        [HideInCallstack]
        public void W(string additionalTag, string msg)
        {
            Debug.unityLogger.Log(LogType.Warning, GetFullTag(additionalTag), msg);
        }

        [HideInCallstack]
        public void E(string msg)
        {
            Debug.unityLogger.Log(LogType.Error, _tag, msg);
        }

        [HideInCallstack]
        public void E(string additionalTag, string msg)
        {
            Debug.unityLogger.Log(LogType.Error, GetFullTag(additionalTag), msg);
        }

        [HideInCallstack]
        public void E(Exception e)
        {
            Debug.unityLogger.Log(LogType.Exception, _tag, e.ToString());
        }

        [HideInCallstack]
        public void E(string additionalTag, Exception e)
        {
            Debug.unityLogger.Log(LogType.Exception, GetFullTag(additionalTag), e.ToString());
        }

        [HideInCallstack]
        public void ThrowException(string msg)
        {
            throw new Exception(_tag + msg);
        }

        [HideInCallstack]
        public void ThrowException(string additionalTag, string msg)
        {
            throw new Exception(GetFullTag(additionalTag) + msg);
        }

        private string GetFullTag(string additionalTag) => _partTag + additionalTag + "] ";
    }
}