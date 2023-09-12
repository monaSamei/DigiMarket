using App.Domain.Core.BaseData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Customer.Dtos
{
    public class AddressDto
    {
        public int Id { get; set; }

        public string? Title { get; set; }

        public string? RegionTitle { get; set; }

        public string? FullAddress { get; set; }

        public bool? IsMainAddress { get; set; }

        #region foreign key
        public Guid? UserId { get; set; }
        public int ? CustomerId { get; set; }
        public int? CityId { get; set; }
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
        public string Customer { get; set; }
        public string User { get; set; }
        public string? City { get; set; }
        #endregion
    }
}
