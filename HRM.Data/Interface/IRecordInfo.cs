using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HRM.Common
{
    public interface IRecordInfo
    {
        int ID { get; set; }
        string Createdby { get; set; }
        string Modifiedby { get; set; }
        DateTime? Created { get; set; }
        DateTime? Modified { get; set; }
        [UIHint("FileUpload")]
        string Attachments { get; set; }
    }
}
