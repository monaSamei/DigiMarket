using App.Domain.Core.BaseData;
using App.Domain.Core.BaseData.Entities;
using App.Domain.Core.Shop.Entities;
using App.Domain.Core.Customer.Entities;
using App.Domain.Core.Seller.Entities;
using ShopEntities = App.Domain.Core.Shop.Entities;


namespace App.Domain.Core.Seller.Entities;

public partial class Seller
{
    public int Id { get; set; }


    #region foreign key
    public Guid UserId { get; set; }
    public int? AddressId { get; set; }
    #endregion


    public string? Medal { get; set; }


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
    public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();
    public virtual ICollection<Bid> Bids { get; set; } = new List<Bid>();
    public virtual Address? Address { get; set; }
    public virtual ICollection<Factor> Factors { get; set; } = new List<Factor>();
    public virtual ICollection<ShopEntities.Shop> Shops { get; set; } = new List<ShopEntities.Shop>();
    public virtual AppUser User { get; set; }
    #endregion
}
