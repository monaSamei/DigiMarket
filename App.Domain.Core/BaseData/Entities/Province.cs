using System;
using System.Collections.Generic;
using App.Domain.Core.BaseData.Entities;

namespace App.Domain.Core.Customer;

public partial class Province
{
    public int Id { get; set; }

    public string? ProvinceName { get; set; }
    #region monitoring data
    public DateTime? CreatedAt { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? LastModifiedAt { get; set; }

    public int? LastModifiedBy { get; set; }

    public bool IsDeleted { get; set; }

    public DateTime? DeletedAt { get; set; }

    public int? DeletedBy { get; set; }
    #endregion

    #region navigation property
    public virtual ICollection<City> Cities { get; set; } = new List<City>();
    #endregion
}
