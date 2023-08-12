using System;
using System.Collections.Generic;
using System.Text;

namespace CompanyName.UEPT.Runtime.Utilities.Logging
{
    public sealed class BuilderLogPool
    {
        private readonly Stack<LogPacker> _buildersPool = new();
        private readonly TagLog _log;
        private readonly int _buildersCount;

        public BuilderLogPool(TagLog log, int buildersCount)
        {
            _log = log;
            _buildersCount = buildersCount;

            for (var i = 0; i < buildersCount; i++)
                _buildersPool.Push(new LogPacker());
        }

        public LogPacker Rent()
        {
            if (_buildersPool.TryPeek(out LogPacker sb)) {
                sb.Clear();
                return sb;
            }

            throw new ArgumentOutOfRangeException(nameof(_buildersCount), "You are trying to Peek more string builder then you define");
        }

        public void ReturnAndLog(LogPacker sb, string additionalTag = null)
        {
            if (_buildersPool.Count + 1 < _buildersCount) {
                throw new ArgumentOutOfRangeException(nameof(_buildersCount),
                    "You are trying to Return more string builder then you define");
            }

            if (string.IsNullOrEmpty(additionalTag))
                _log.D(sb.ToString());
            else
                _log.D(additionalTag, sb.ToString());

            sb.Clear();
            _buildersPool.Push(sb);
        }
    }

    public sealed class LogPacker
    {
        private readonly StringBuilder _sb = new();

#if COMPANYNAME_PROD
        [System.Diagnostics.Conditional("DUMMY_UNUSED_DEFINE")]
#endif
        public void AppendFormat(string format, object arg0)
        {
            _sb.AppendFormat(format, arg0);
        }

#if COMPANYNAME_PROD
        [System.Diagnostics.Conditional("DUMMY_UNUSED_DEFINE")]
#endif
        public void AppendFormat(string format, object arg0, object arg1)
        {
            _sb.AppendFormat(format, arg0, arg1);
        }

#if COMPANYNAME_PROD
        [System.Diagnostics.Conditional("DUMMY_UNUSED_DEFINE")]
#endif
        public void AppendFormat(string format,
            object arg0,
            object arg1,
            object arg2)
        {
            _sb.AppendFormat(format, arg0, arg1, arg2);
        }

#if COMPANYNAME_PROD
        [System.Diagnostics.Conditional("DUMMY_UNUSED_DEFINE")]
#endif
        public void AppendFormat(string format, params object[] args)
        {
            _sb.AppendFormat(format, args);
        }

#if COMPANYNAME_PROD
        [System.Diagnostics.Conditional("DUMMY_UNUSED_DEFINE")]
#endif
        public void AppendLine()
        {
            _sb.AppendLine();
        }

#if COMPANYNAME_PROD
        [System.Diagnostics.Conditional("DUMMY_UNUSED_DEFINE")]
#endif
        public void AppendLine(string value)
        {
            _sb.AppendLine(value);
        }

        public void Clear()
        {
            _sb.Clear();
        }

        public int EnsureCapacity(int capacity) => _sb.EnsureCapacity(capacity);

        public bool Equals(LogPacker sb) => _sb.Equals(sb._sb);

        public override string ToString() => _sb.ToString();

        public int Capacity
        {
            get => _sb.Capacity;
            set => _sb.Capacity = value;
        }
        public char this[int index]
        {
            get => _sb[index];
            set => _sb[index] = value;
        }
        public int Length
        {
            get => _sb.Length;
            set => _sb.Length = value;
        }
        public int MaxCapacity => _sb.MaxCapacity;
    }
}