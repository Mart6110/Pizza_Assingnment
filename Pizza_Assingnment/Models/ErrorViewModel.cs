using System;

namespace Pizza_Assingnment.Models
{
    //public class named ErrorViewModel
    public class ErrorViewModel
    {
        //variables with get and set
        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}
