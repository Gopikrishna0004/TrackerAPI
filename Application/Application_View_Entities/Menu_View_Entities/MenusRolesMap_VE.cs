using DomainLayer.Table_Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationLayer.Application_View_Entities.Menu_View_Entities
{
	public class MenusRolesMap_VE
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
