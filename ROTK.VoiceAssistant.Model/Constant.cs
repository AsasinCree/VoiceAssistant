using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ROTK.VoiceAssistant.Model
{
    public class Constant
    {
        #region Intent

        public const string NoneIntent = "None";

        public const string OpenScreenActivityIntent = "OpenScreenActivity";

        public const string SendMessageActivityIntent = "SendMessageActivity";

        public const string FillMessageFieldActivityIntent = "FillMessageFieldActivity";

        #endregion

        #region Entity

        public const string OperationTypeEntity = "OperationType";

        public const string FieldTypeEntity = "FieldType";

        #endregion

        #region ScreenName
        public const string MessageScreenName = "message";

        public const string IncidentScreenName = "incident";

        public const string QueryScreenName = "query";

        public const string BoloScreenName = "bolo";
        #endregion

        #region Url
        public const string MessageScreenUrl = "\\MessagingView";

        public const string IncidentScreenUrl = "\\IncidentView";

        public const string QueryScreenUrl = "\\QueryView";

        public const string BoloScreenUrl = "\\BoloView";

        #endregion
    }
}
