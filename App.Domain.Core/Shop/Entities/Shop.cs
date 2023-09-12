using SellerEntities = App.Domain.Core.Seller.Entities;
namespace App.Domain.Core.Shop.Entities;

public partial class Shop
{
    public int Id { get; set; }

    #region foreign key
    public int SellerId { get; set; }
    #endregion

    public string? ShopTitle { get; set; }
    public string? ShopDescription { get; set; }

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
    public virtual SellerEntities.Seller Seller { get; set; } = null!;
    #endregion
}
