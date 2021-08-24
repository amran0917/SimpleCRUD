using System;  
using System.Collections.Generic;  
using System.Linq;  
using System.Web;  
using System.ComponentModel.DataAnnotations;  
using System.Web.Mvc; 

public class Registration
{
	public int ID{get;set;}
	
   [Required(ErrorMessage = "Please Enter Name")]  
	public string name {get;set;}
	
	[Required(ErrorMessage = "Please Enter email")]  
    [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}")]
	public string Email {get;set;}
	
	[Required(ErrorMessage = "Please Enter password")]
    [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{8,15}$")]
	public string Password {get;set;}
	
	[Required(ErrorMessage = "Please Enter confirmPassword")]  
	[System.ComponentModel.DataAnnotations.Compare("Password")]
	public string ConfirmPassword {get;set}

}