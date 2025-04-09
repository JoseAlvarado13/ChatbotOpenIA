using EntitiesInterfaces.Base;
using Settings.Commons;

namespace Entities.Base
{
    /// <summary>
    /// AM-001
    /// Author:  José Andrés Alvarado Matamoros
    /// 
    /// DTO for encapsulating exception details.
    /// </summary>
    public class ExceptionDTO: IExceptionDTO
    {
        public ExceptionDTO() 
        {
            this.InternalErrorMessage = new BaseAPISettingsCfg().Get(BaseAPISettingsType.InternalErrorMessage);
            this.CurrentDate = DateTime.Now;
            this.IsEnable = true;
            this.HostName = new BaseAPISettingsCfg().Get(BaseAPISettingsType.HostName);
        }

        /// <summary>
        /// AM-001
        /// Author:  José Andrés Alvarado Matamoros
        /// The HTTP method or operation being performed when the exception occurred.
        /// </summary>
        public string Method { get; set; }

        /// <summary>
        /// AM-001
        /// Author:  José Andrés Alvarado Matamoros
        /// The name of the class where the exception occurred.
        /// </summary>
        public string Class { get; set; }

        /// <summary>
        /// AM-001
        /// Author:  José Andrés Alvarado Matamoros
        /// 
        /// Any additional data relevant to the exception.
        /// </summary>
        public object Data { get; set; }

        /// <summary>
        /// AM-001
        /// Author:  José Andrés Alvarado Matamoros
        /// 
        /// The exception object containing the error details.
        /// </summary>
        public string Error { get; set; }
        /// <summary>
        /// AM-001
        /// Author:  José Andrés Alvarado Matamoros
        /// 
        /// The exception object containing the InternalErrorMessage details.
        /// </summary>
        public string InternalErrorMessage { get; set; }
        /// <summary>
        /// AM-001
        /// Author:  José Andrés Alvarado Matamoros
        /// 
        /// The exception object containing the CurrentDate details.
        /// </summary>
        public DateTime CurrentDate { get; set; }
        /// <summary>
        /// AM-001
        /// Author:  José Andrés Alvarado Matamoros
        /// 
        /// The exception object containing the IsEnable details.
        /// </summary>
        public bool IsEnable { get; set; }
        /// <summary>
        /// AM-001
        /// Author:  José Andrés Alvarado Matamoros
        /// 
        /// The exception object containing the HostName details.
        /// </summary>
        public string HostName { get ; set ; }
    }
}
