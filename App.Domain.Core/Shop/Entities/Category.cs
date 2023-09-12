﻿namespace App.Domain.Core.Shop.Entities;

public partial class Category
{
    public int Id { get; set; }
    public int? ParentId { get; set; }
    public string? Title { get; set; }

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
    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
    #endregion
}
