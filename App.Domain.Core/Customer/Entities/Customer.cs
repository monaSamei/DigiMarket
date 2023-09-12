using App.Domain.Core.BaseData;
using App.Domain.Core.Seller.Entities;
using App.Domain.Core.Shop.Entities;

namespace App.Domain.Core.Customer.Entities;

public partial class Customer
{
    public int Id { get; set; }

    #region foreign key
    public Guid UserId { get; set; }
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
    public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();

    public virtual ICollection<Factor> Factors { get; set; } = new List<Factor>();
    public virtual AppUser User { get; set; }
    #endregion
}
