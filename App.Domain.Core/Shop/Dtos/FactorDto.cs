using App.Domain.Core.BaseData.Entities;
using App.Domain.Core.Seller.Entities;
using App.Domain.Core.Shop.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Shop.Dtos
{
    public class FactorDto
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
        public string? Customer { get; set; }
        public virtual string? Seller { get; set; }
        #endregion

    }
}
