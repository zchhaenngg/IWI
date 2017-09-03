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
    /// 工厂产品
    /// </summary>
    public partial class Product : FullAuditedEntity<Guid>
    {
        public const int MaxNameLength = 128;


        [StringLength(MaxNameLength)]
        public string Name { get; set; }
    }

    public partial class Product
    {
        /// <summary>
        /// 本产品需要的所有生产工序
        /// </summary>
        public virtual ICollection<Procedure> Procedures { get; set; }

        /// <summary>
        /// 能生产本产品的所有车间
        /// </summary>
        public virtual ICollection<WorkshopProduct> WorkshopProducts { get; set; }

        /// <summary>
        /// 所有生产本产品的生产任务
        /// </summary>
        public virtual ICollection<ProductTask> ProductTasks { get; set; }
    }
}
