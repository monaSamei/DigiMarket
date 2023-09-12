using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Customer.Dtos
{
    public class CommentDto
    {
        public int Id { get; set; }
        public string Description { get; set; }

        #region foreign key
        public int? SellerId { get; set; }

        public int? CustomerId { get; set; }
        public int? ProductId { get; set; }
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
        public string? Seller { get; set; }

        public string? Customer { get; set; }
        public string? Product { get; set; }
        #endregion
    }
}
