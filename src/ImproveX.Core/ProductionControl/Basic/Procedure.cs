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
    /// 车间产品的工序
    /// </summary>
    public partial class Procedure : FullAuditedEntity<Guid>
    {
        public const int MaxNameLength = 128;


        [StringLength(MaxNameLength)]
        public string Name { get; set; }
    }

    public partial class Procedure
    {
        /// <summary>
        /// 工序所属产品
        /// </summary>
        public virtual Product Product { get; set; }
        public virtual Guid ProductId { get; set; }
        /// <summary>
        /// 下一步工序
        /// </summary>
        public virtual Procedure NextProcedure { get; set; }
        public virtual Guid? NextProcedureId { get; set; }
        /// <summary>
        /// 上一步工序
        /// </summary>
        public virtual Procedure PreviewProcedure { get; set; }
        public virtual Guid? PreviewProcedureId { get; set; }

        public virtual ICollection<ProcedureTask> ProcedureTasks { get; set; }
    }
}
