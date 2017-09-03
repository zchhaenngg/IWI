using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Domain.Entities.Auditing;
using ImproveX.ProductionControl.Basic;

namespace ImproveX.ProductionControl
{
    public partial class ProductTask : FullAuditedEntity<Guid>
    {
        
    }

    public partial class ProductTask
    {
        /// <summary>
        /// 任务所属产品
        /// </summary>
        public virtual Product Product { get; set; }
        public virtual Guid ProductId { get; set; }

        public virtual ICollection<ProcedureTask> ProcedureTasks { get; set; }
    }
}
