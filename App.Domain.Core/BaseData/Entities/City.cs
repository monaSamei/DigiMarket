using App.Domain.Core.Customer;
using App.Domain.Core.Customer.Entities;
namespace App.Domain.Core.BaseData.Entities;

public partial class City
{
    public int Id { get; set; }

    public string? CityName { get; set; }

    #region foreign key
    public int? ProvinceId { get; set; }
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
    public virtual ICollection<Address> Adresses { get; set; } = new List<Address>();

    public virtual Province? Province { get; set; }
    #endregion
}
