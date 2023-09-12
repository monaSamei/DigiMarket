using App.Domain.Core.Seller.Entities;
using SellerEntities = App.Domain.Core.Seller.Entities;
using ShopEntities = App.Domain.Core.Shop.Entities;

namespace App.Domain.Core.Customer.Entities;

public partial class Comment
{
    public int Id { get; set; }
    public string Description { get; set; }

    #region foreign key
    public int? SellerId { get; set; }

    public int? CustomerId { get; set; }
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
    public virtual SellerEntities.Seller? Seller { get; set; }

    public virtual Customer? Customer { get; set; }
    public virtual ShopEntities.Product? Product { get; set; }
    #endregion
}
