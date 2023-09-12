using App.Domain.Core.Customer.Entities;
using App.Domain.Core.Shop.Entities;
using CustomerEntities = App.Domain.Core.Customer.Entities;
using SellerEntities = App.Domain.Core.Seller.Entities;

namespace App.Domain.Core.Seller.Entities;

public partial class Bid
{
    public int Id { get; set; }


    #region foreign key
    public int? SellerId { get; set; }
    public int? CustomerId { get; set; }
    public int? FactorId { get; set; }
    #endregion

    public int? SellerSugestedPrice { get; set; }
    public string? SellerComment { get; set; }
    public DateTime? StartAt { get; set; }
    public DateTime? EndAt { get; set; }
    public int? IsAccept { get; set; }


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
    public virtual CustomerEntities.Customer? Customer { get; set; }
    public virtual ICollection<Suggestion> Suggestions { get; set; } = new List<Suggestion>();
    public virtual Factor? Factor { get; set; }
    public virtual SellerEntities.Seller? Seller { get; set; }
    #endregion 
}
