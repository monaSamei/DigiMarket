using App.Domain.Core.Seller.Entities;
using App.Domain.Core.Shop.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Customer.Dtos
{
    public class SuggestionDto
    {
        public int Id { get; set; }

        #region foreign key
        public int? ProductId { get; set; }
        public int? AcceptedSellerId { get; set; }
        public int? BidId { get; set; }
        public int? ScoreByCustomerId { get; set; }
        public int? CustomerId { get; set; }
        #endregion

        public bool? SuggestStatus { get; set; }
        public DateTime? SuggestRegDate { get; set; }
        public string? Description { get; set; }


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
        public string? Bid { get; set; } = null!;
        public string? Customer { get; set; }
        public string? Product { get; set; }
        #endregion
    }
}
