public class User  
{  
         
		[Required]
        public int UserId { get; set; }  
		[Required]
        public string UserName { get; set; }  
        public Nullable<decimal> UserSalary		{ get; set; }  
        public string UserCity { get; set; }  
}  