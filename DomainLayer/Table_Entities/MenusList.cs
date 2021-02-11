using System;
using System.Collections.Generic;

namespace DomainLayer.Table_Entities
{
    public partial class MenusList
    {
        public MenusList()
        {
            MenusRolesMap = new HashSet<MenusRolesMap>();
        }

        public int MenuId { get; set; }
        public string MenuName { get; set; }
        public string MenuDescription { get; set; }
        public string MenuController { get; set; }
        public string MenuPath { get; set; }
        public string MenuUrl { get; set; }
        public bool? MenuStatus { get; set; }
        public DateTime MenuCreatedOn { get; set; }
        public string MenuCreatedBy { get; set; }
        public DateTime? MenuUpdaetdOn { get; set; }
        public string MenuUpdatedBy { get; set; }

        public virtual ICollection<MenusRolesMap> MenusRolesMap { get; set; }
    }
}
