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

        public const string FocusOnLocationActivityIntent = "FocusOnLocationActivity";

        public const string FocusOnCityActivityIntent = "FocusOnCityActivity";

        public const string FocusOnBuildingActivityIntent = "FocusOnBuildingActivity";

        public const string FocusOnIncidentTypeActivityIntent = "FocusOnIncidentTypeActivity";

        public const string FocusOnLicensePlateActivityIntent = "FocusOnLicensePlateActivity";

        public const string FocusOnStateActivityIntent = "FocusOnStateActivity";

        public const string FocusOnPlateTypeActivityIntent = "FocusOnPlateTypeActivity";

        public const string FocusOnPlateYearActivityIntent = "FocusOnPlateYearActivity";

        public const string CreateIncidentActivityIntent = "CreateIncidentActivity";

        public const string FillIncidentFieldActivityIntent = "FillIncidentFieldActivity";

        public const string FillCityActivityIntent = "FillCityActivity";

        public const string FillIncidentTypeActivityIntent = "FillIncidentTypeActivity";

        public const string FillPlateTypeActivityIntent = "FillPlateTypeActivity";

        public const string FillStateActivityIntent = "FillStateActivity";

        #endregion

        #region Entity

        public const string Entity = "Entity";

        public const string OperationTypeEntity = "OperationType";

        public const string FieldTypeEntity = "FieldType";

        public const string IncidentTypeEntity = "IncidentType";

        public const string PlateTypeEntity = "PlateType";

        public const string StateEntity = "State";

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
