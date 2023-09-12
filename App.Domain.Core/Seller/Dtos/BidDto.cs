using App.Domain.Core.BaseData.Entities;
using App.Domain.Core.Customer.Entities;
using App.Domain.Core.Seller.Entities;
using App.Domain.Core.Shop.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Seller.Dtos
{
    public class BidDto
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
        public string? Customer { get; set; }
        public string? Factor { get; set; }
        public string? Seller { get; set; }
        #endregion

    }
}
