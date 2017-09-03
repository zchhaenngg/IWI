using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Domain.Entities.Auditing;

namespace ImproveX.ProductionControl.Basic
{
    /// <summary>
    /// 车间和工厂产品
    /// </summary>
    public partial class WorkshopProduct : FullAuditedEntity<Guid>
    {
        public const int MaxNameLength = 128;


        [StringLength(MaxNameLength)]
        public string Name { get; set; }
    }

    public partial class WorkshopProduct
    {
        public virtual Product Product { get; set; }
        public virtual Guid ProductId { get; set; }

        public virtual Workshop Workshop { get; set; }
        public virtual Guid WorkshopId { get; set; }
    }
}
