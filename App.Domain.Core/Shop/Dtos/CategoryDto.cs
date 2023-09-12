﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Shop.Dtos
{
    public class CategoryDto
    {
        public int Id { get; set; }
        public int? ParentId { get; set; }
        public string? Title { get; set; }

        #region monitoring data
        public DateTime? CreatedAt { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? LastModifiedAt { get; set; }
        public int? LastModifiedBy { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletedAt { get; set; }
        public int? DeletedBy { get; set; }
        #endregion

    }
}
