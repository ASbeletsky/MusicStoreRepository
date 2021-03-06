//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MusicStore.Domain.Entities
{
    using System;
    using System.Collections.Generic;
    
    public partial class User
    {
        public User()
        {
            this.userclaims = new HashSet<UserClaim>();
            this.userlogins = new HashSet<UserLogin>();
            this.roles = new HashSet<Role>();
            this.userphone = new HashSet<UserPhone>();
            this.Address = new HashSet<Address>();
            this.Order = new HashSet<Order>();
        }
    
        public int Id { get; set; }
        public string Email { get; set; }
        public bool EmailConfirmed { get; set; }
        public string PasswordHash { get; set; }
        public string SecurityStamp { get; set; }
        public bool PhoneNumberConfirmed { get; set; }
        public bool TwoFactorEnabled { get; set; }
        public Nullable<System.DateTime> LockoutEndDateUtc { get; set; }
        public bool LockoutEnabled { get; set; }
        public int AccessFailedCount { get; set; }
        public string UserName { get; set; }
    
        public virtual ICollection<UserClaim> userclaims { get; set; }
        public virtual ICollection<UserLogin> userlogins { get; set; }
        public virtual ICollection<Role> roles { get; set; }
        public virtual ICollection<UserPhone> userphone { get; set; }
        public virtual ICollection<Address> Address { get; set; }
        public virtual ICollection<Order> Order { get; set; }
    }
}
