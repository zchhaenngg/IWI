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
    /// 正常、质量、缺料、其他
    /// </summary>
    public class ProcedureStatus : FullAuditedEntity<Guid>
    {
        public const int MaxNameLength = 128;
        
        [StringLength(MaxNameLength)]
        public string Name { get; set; }
    }
}
