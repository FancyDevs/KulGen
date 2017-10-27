using System;
using MvvmCross.Platform.Platform;
using Shire.Core.Log;

namespace Wolf.iOS
{
    public class DebugTrace : IMvxTrace
    {
        public void Trace(MvxTraceLevel level, string tag, Func<string> message)
        {
			if (LogInstance.IsInitialized) {
				this.Log (LogTag.MvxTrace, tag + ":" + level + ":" + message ());
			}
        }

        public void Trace(MvxTraceLevel level, string tag, string message)
        {
			if (LogInstance.IsInitialized) {
				this.Log (LogTag.MvxTrace, tag + ":" + level + ":" + message);
			}
        }

        public void Trace(MvxTraceLevel level, string tag, string message, params object[] args)
        {
            try
            {
				if (LogInstance.IsInitialized) {
					this.Log (LogTag.MvxTrace, tag + ":" + level + ":" + message, args);
				}
            }
            catch (FormatException)
            {
                Trace(MvxTraceLevel.Error, tag, "Exception during trace of {0} {1}", level, message);
            }
        }
    }
}
