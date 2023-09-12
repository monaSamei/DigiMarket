using App.Domain.Core.Seller.Entities;
using App.Domain.Core.Shop.Entities;
namespace App.Domain.Core.Customer.Entities;

public partial class Suggestion
{
    public int Id { get; set; }

    #region foreign key
    public int? ProductId { get; set; }
    public int? BidId { get; set; }
    public int? CustomerId { get; set; }
    public int? AcceptedSellerId { get; set; }

    public int? ScoreByCustomerId { get; set; }
    #endregion

    public bool? SuggestStatus { get; set; }

    public DateTime? SuggestRegDate { get; set; }
  
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

    #region navigation property
    public virtual Bid Bid { get; set; } = null!;

    public virtual Product? Product { get; set; }
    public virtual Customer Customer { get; set; }
}
    #endregion