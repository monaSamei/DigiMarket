using App.Domain.Core.Customer.Entities;

namespace App.Domain.Core.Shop.Entities;

public partial class Product
{
    public int Id { get; set; }
    public string? Title { get; set; }
    public int? Price { get; set; }
    public bool? IsActive { get; set; }
    public int? ProductCount { get; set; }
    public bool? IsBid { get; set; }

    #region foreign key
    public int? CategoryId { get; set; }
    public int FactorId { get; set; }
    public int? ShopId { get; set; }
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
    public virtual Category? Category { get; set; }
    public virtual ICollection<Suggestion> Suggestions { get; set; } = new List<Suggestion>();
    public virtual Factor? Factor { get; set; }
    public virtual ICollection<Picture> Pictures { get; set; }
    public virtual ICollection<ProductDetail> ProductDetails { get; set; } = new List<ProductDetail>();
    public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();
    public virtual Shop? Shop { get; set; }
    #endregion
}
