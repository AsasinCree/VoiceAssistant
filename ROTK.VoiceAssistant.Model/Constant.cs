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

        public const string FillToActivityActivityIntent = "FillToActivity";

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

        public const string FocusContentActivityIntent = "FocusContentActivity";

        public const string FocusSubjectActivityIntent = "FocusSubjectActivity";

        public const string FocusAddressActivityIntent = "FocusToActivity";

        public const string OpenMessageActivity = "OpenMessageActivity";

        public const string OpenIncidentActivity = "OpenIncidentActivity";

        public const string BackToHomeActivity = "BackToHomeActivity";

        #endregion

        #region Entity

        public const string Entity = "Entity";

        public const string NameEntity = "Name";

        public const string GeographyEntity = "builtin.geography";

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
