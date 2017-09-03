using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Domain.Entities.Auditing;
using ImproveX.ProductionControl.Basic;

namespace ImproveX.ProductionControl
{
    public partial class ProcedureTask : FullAuditedEntity<Guid>
    {
        public virtual DateTime? StartTime { get; set; }
        public virtual DateTime? FinishTime { get; set; }
    }

    public partial class ProcedureTask
    {
        /// <summary>
        /// 任务所属工序
        /// </summary>
        public virtual Procedure Procedure { get; set; }
        public virtual Guid ProcedureId { get; set; }
        /// <summary>
        /// 任务所属产品任务
        /// </summary>
        public virtual ProductTask ProductTask { get; set; }
        public virtual Guid ProductTaskId { get; set; }
        /// <summary>
        /// 下一步工序任务
        /// </summary>
        public virtual ProcedureTask NextProcedureTask { get; set; }
        public virtual Guid? NextProcedureTaskId { get; set; }

        public virtual ProcedureStatus ProcedureStatus { get; set; }
        public virtual Guid ProcedureStatusId { get; set; }
    }
}
