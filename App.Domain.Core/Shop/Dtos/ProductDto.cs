using App.Domain.Core.Customer.Entities;
using App.Domain.Core.Shop.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Shop.Dtos
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public int? Price { get; set; }
        public bool? IsActive { get; set; }
        public int? ProductCount { get; set; }
        public bool? IsBid { get; set; }

        #region foreign key
        public int? CategoryId { get; set; }
        public int? PictureId { get; set; }
        public int FactorId { get; set; }
        public int? ShopId { get; set; }
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

        public string? Category { get; set; }
        public string? Shop { get; set; }
        #endregion
    }
}

