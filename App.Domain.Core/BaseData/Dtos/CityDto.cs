using App.Domain.Core.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.BaseData.Dtos
{
    public class CityDto
    {
        public int Id { get; set; }
        public string? CityName { get; set; }

        public int? ProvinceId { get; set; }

        #region monitoring data
        public DateTime? CreatedAt { get; set; }

        public int? CreatedBy { get; set; }

        public DateTime? LastModifiedAt { get; set; }

        public int? LastModifiedBy { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedAt { get; set; }
        #endregion

        #region navigation property
        public int? DeletedBy { get; set; }
        public string? Province { get; set; }
        #endregion
    }
}
