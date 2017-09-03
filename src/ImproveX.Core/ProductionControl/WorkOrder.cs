using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Domain.Entities.Auditing;

namespace ImproveX.ProductionControl
{
    public partial class WorkOrder : FullAuditedEntity<Guid>
    {
        public const int MaxNameLength = 128;


        [StringLength(MaxNameLength)]
        public string Name { get; set; }
    }

    public partial class WorkOrder
    {
        /// <summary>
        /// 所有生产任务
        /// </summary>
        public virtual ICollection<ProductTask> ProductTasks { get; set; }
    }
}
