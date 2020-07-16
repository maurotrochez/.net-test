using System;
using System.Collections.Generic;
using System.Text;

namespace Models.DTOs
{
    public class ApiResponse
    {
        public ApiResponse()
        {
            this.Success = true;
            ErrorList = new List<string>();
            WarningList = new List<string>();
        }

        public object Content { get; set; }
        public List<string> ErrorList { get; set; }
        public List<string> WarningList { get; set; }
        public bool Success { get; set; }
    }
}
