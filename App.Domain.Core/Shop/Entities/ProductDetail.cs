using System;
using System.Collections.Generic;
using App.Domain.Core.Seller.Entities;

namespace App.Domain.Core.Shop.Entities;

public partial class ProductDetail
{
    public int Id { get; set; }

    public int? ProductId { get; set; }
    public string? Title { get; set; }
    public string? Description { get; set; }

    #region monitoring data
    public DateTime? CreatedAt { get; set; }
    public int? CreatedBy { get; set; }
    public DateTime? LastModifiedAt { get; set; }
    public int? LastModifiedBy { get; set; }
    public bool IsDeleted { get; set; }
    public DateTime? DeletedAt { get; set; }
    public int? DeletedBy { get; set; }
    #endregion
    public virtual Product? Product { get; set; }
}
