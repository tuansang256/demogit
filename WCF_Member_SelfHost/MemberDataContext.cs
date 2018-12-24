using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using General;

namespace WCF_Member_SelfHost
{
    class MemberDataContext:DbContext
    {
        public MemberDataContext() : base("cn") { }
        public MemberDataContext(string connect) : base(connect) { }
        public DbSet<Member> Members { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
