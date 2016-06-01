using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IMS.Common.Enums
{
    /// <summary>
    /// HMS defined importance of a status message.
    /// </summary>
    public enum ErrorLevel
    {
        /// <summary>Information: Notification information, not an error.</summary>
        Information,
        /// <summary>Minor error: Low-signifance error, possibly not user-noticable.</summary>
        Minor,
        /// <summary>Warning: Possibly noticable error, worth investigating.</summary>
        Warning,
        /// <summary>Moderate error: Significant error, but not necessarily causing full user-functionality error.</summary>
        Moderate,
        /// <summary>Critical error: User-functionality failure.</summary>
        Critical,
        /// <summary>Fatal error: Application failure.</summary>
        Fatal
    }
}
