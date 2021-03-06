﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ApplicationLayer.Application_View_Entities.Login_View_Entities
{
	public class Login_VE
	{
		[Required(ErrorMessage = "User Name is required")]
		public string Username { get; set; }

		[Required(ErrorMessage = "Password is required")]
		public string Password { get; set; }
	}
}
