using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.ServiceModel.Web;
using Shoppe.Model;
namespace Shoppe.Web.Test.Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IData" in both code and config file together.
    [ServiceContract]
    public interface IData
    {
        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Json)]
        IEnumerable<MasterItem> GetAllMasterItems();

        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Json)]
        IEnumerable<MUs> GetAllMUs();

    }
}
