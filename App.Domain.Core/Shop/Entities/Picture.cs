using System;
using System.Collections.Generic;

namespace App.Domain.Core.Shop.Entities;

public partial class Picture
{
    public int Id { get; set; }
    public string? PictureUrl { get; set; }
    public string? PictureTypes { get; set; }

    #region foreign key
    public int? ProductId { get; set; }
    #endregion

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
    public virtual Product? Product { get; set; } 
    #endregion
}
