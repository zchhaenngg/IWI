using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Domain.Entities.Auditing;

namespace ImproveX.ProductionControl.Basic
{
    public partial class Factory : FullAuditedEntity<Guid>
    {
        public const int MaxNameLength = 128;


        [StringLength(MaxNameLength)]
        public string Name { get; set; }
    }

    public partial class Factory
    {
        /// <summary>
        /// 工厂所有车间
        /// </summary>
        public virtual ICollection<Workshop> Workshops { get; set; }
    }
}
