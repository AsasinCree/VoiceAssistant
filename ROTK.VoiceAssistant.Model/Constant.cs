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
    }
}
