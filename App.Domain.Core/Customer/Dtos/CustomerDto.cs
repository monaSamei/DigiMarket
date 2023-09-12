using App.Domain.Core.BaseData;
using App.Domain.Core.Customer.Entities;
using App.Domain.Core.Seller.Entities;
using App.Domain.Core.Shop.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Customer.Dtos
{
    public class CustomerDto
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
          public string  User { get; set; }
        #endregion
    }
}
