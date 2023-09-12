using App.Domain.Core.Seller.Entities;
using CustomerEntities=App.Domain.Core.Customer.Entities;
using SellerEntities=App.Domain.Core.Seller.Entities;

namespace App.Domain.Core.Shop.Entities;

public partial class Factor
{
    public int Id { get; set; }
    public int? TotalPrice { get; set; }
    public bool? IsAccepted { get; set; }


    #region foreign key
    public int? SellerId { get; set; }
    public int? CustomerId { get; set; }
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
    public virtual ICollection<Bid> Bids { get; set; } = new List<Bid>();
    public virtual CustomerEntities.Customer? Customer { get; set; }
    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
    public virtual SellerEntities.Seller? Seller { get; set; }
    #endregion
}
