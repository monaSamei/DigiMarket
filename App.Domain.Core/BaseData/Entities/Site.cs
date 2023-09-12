using System;
using System.Collections.Generic;
using App.Domain.Core.BaseData.Entities;

namespace App.Domain.Core.BaseData.Entities;

public partial class Site
{
    public int Id { get; set; }

    public int? Comission { get; set; }

    #region monitoring data
    public DateTime? CreatedAt { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? LastModifiedAt { get; set; }

    public int? LastModifiedBy { get; set; }

    public bool IsDeleted { get; set; }

    public DateTime? DeletedAt { get; set; }

    public int? DeletedBy { get; set; }
    #endregion
}
