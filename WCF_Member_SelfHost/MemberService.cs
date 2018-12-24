using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using General;



namespace WCF_Member_SelfHost
{
    class MemberService: IMemberService
    {
        MemberDataContext db = new MemberDataContext();

        public bool Delete(int id)
        {
            db.Members.Remove(db.Members.Find(id));
            db.SaveChanges();
            return true;
        }

        public IEnumerable<Member> GetAllMember()
        {
            return db.Members;
        }

        public Member GetMemberByID(int id)
        {
            Member m = (from mem in db.Members where mem.ID == id select mem).Single();
            return m; 
        }

        public IEnumerable<Member> GetMemberByName(string name)
        {
            return db.Members.Where(item =>item.Name.Trim().ToLower().Contains(name.Trim().ToLower())).ToList();            
        }

        public bool Insert(Member newMember)
        {
            db.Members.Add(newMember);
            db.SaveChanges();
            return true;
        }

        public bool Update(Member editMember)
        {
            var mem = db.Members.Find(editMember.ID);
            mem.Name = editMember.Name;
            mem.Email = editMember.Email;
            mem.Password = editMember.Password;
            mem.Gender = editMember.Gender;
            db.SaveChanges();
            return true;
        }
    }
}
