using App.Domain.Core.BaseData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Seller.Dtos
{
    public class SellerDto
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
        public string User { get; set; }
        public string? Address { get; set; }
        #endregion
    }
}
