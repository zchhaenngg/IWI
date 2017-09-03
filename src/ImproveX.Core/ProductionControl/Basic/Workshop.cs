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
    /// 车间
    /// </summary>
    public partial class Workshop : FullAuditedEntity<Guid>
    {
        public const int MaxNameLength = 128;


        [StringLength(MaxNameLength)]
        public string Name { get; set; }
    }
    public partial class Workshop
    {
        /// <summary>
        /// 车间所属工厂
        /// </summary>
        public virtual Factory Factory { get; set; }
        public virtual Guid FactoryId { get; set; }
        /// <summary>
        /// 本车间能生产的所有产品
        /// </summary>
        public virtual ICollection<WorkshopProduct> WorkshopProducts { get; set; }
    }
}
