﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Ats.Core.Database.Abstraction.Interface;

namespace Ats.Core.Database.Abstraction
{
    public class DbEntityIdBase
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
    }

    public class DbEntityFullBase : DbEntityIdBase, IDbEntity
    {
        public DateTimeOffset CreatedOn { get; set; }

        public Guid? CreatorId { get; set; }

        public DateTimeOffset? UpdatedOn { get; set; }

        public Guid? UpdaterId { get; set; }
    }
}
