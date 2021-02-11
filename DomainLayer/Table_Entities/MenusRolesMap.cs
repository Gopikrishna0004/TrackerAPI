using System;
using System.Collections.Generic;

namespace DomainLayer.Table_Entities
{
    public partial class MenusRolesMap
    {
        public int MenuRoleId { get; set; }
        public int MenuId { get; set; }
        public string RoleId { get; set; }
        public string RoleName { get; set; }
        public DateTime RoleMappedOn { get; set; }
        public string RoleMappedBy { get; set; }
        public DateTime? RoleMapUpdatedOn { get; set; }
        public string RoleMapUpdatedBy { get; set; }

        public virtual MenusList Menu { get; set; }
    }
}
