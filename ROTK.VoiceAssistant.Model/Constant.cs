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

        public const string FocusContentActivityIntent = "FocusContentActivity";

        public const string FocusSubjectActivityIntent = "FocusSubjectActivity";

        public const string FocusAddressActivityIntent = "FocusToActivity";

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
        public const string MainNavigationViewUrl = "\\MainNavigationView";

        public const string MessageScreenUrl = "\\MessagingView";

        public const string IncidentScreenUrl = "\\IncidentView";

        public const string QueryScreenUrl = "\\QueryView";

        public const string BoloScreenUrl = "\\BoloView";

        #endregion

        #region UrlName
        public const string MainNavigationView = "MainNavigationView";

        public const string MessageScreen = "MessagingView";

        public const string IncidentScreen = "IncidentView";

        public const string QueryScreen = "QueryView";

        public const string BoloScreen = "BoloView";

        #endregion

        #region FieldType

        public const string SubjectField = "subject";

        public const string TitleField = "title";

        public const string ToField = "to";

        public const string AddressField = "address";

        public const string ContentField = "content";

        #endregion
    }
}
