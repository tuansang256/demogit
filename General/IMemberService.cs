using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCF_Member_SelfHost;
using System.ServiceModel;
using General;

namespace WCF_Member_SelfHost
{
    [ServiceContract]
    public interface  IMemberService
    {
        [OperationContract]
        IEnumerable<Member> GetAllMember();

        [OperationContract]
        Member GetMemberByID(int id);

        [OperationContract]
        IEnumerable<Member> GetMemberByName(string name);

        [OperationContract]
        bool Insert(Member newMember);

        [OperationContract]
        bool Update(Member editMember);

        [OperationContract]
        bool Delete(int id);
    }
}
