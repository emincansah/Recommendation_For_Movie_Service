using RFM.Data.Context;
using RFM.Data.Entity.EntityModel;
using RFM.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Dynamic;
using System.Linq.Dynamic.Core;

namespace RFM.Data.Repository
{
    public class EmailRepository
    {
        public static List<EmailActionEntity> GetActionList(string filter)
        {
            try
            {
                using (var db = new DataContext())
                {
                    List<EmailAction> emailAction = db.EmailAction.Where(filter).ToList();
                    return DatatoEntityList(emailAction);

                }
            }
            catch (Exception ex)
            {
                List<EmailActionEntity> emailActionEntities = new List<EmailActionEntity>();
                return emailActionEntities;
            }
        }
        public static bool UpdateAction(int id)
        {
            try
            {
                using (var db = new DataContext())
                {
                    EmailAction emailAction = db.EmailAction.FirstOrDefault(x => x.Id == id);
                    emailAction.status = 10;
                    db.SaveChanges();
                    return true;

                }
            }
            catch (Exception ex)
            {
                
                return false;
            }
        }
        public static List<EmailActionEntity> DatatoEntityList(List<EmailAction> Emailaction)
        {
            List <EmailActionEntity> emailActionEntities = new List < EmailActionEntity >();
            
            foreach (var emailAction in Emailaction)
            {
                EmailActionEntity newemailActionEntity = new EmailActionEntity();
                newemailActionEntity.email = emailAction.email;
                newemailActionEntity.status = emailAction.status;
                newemailActionEntity.moiveId = emailAction.moiveId;
                newemailActionEntity.Id = emailAction.Id;
                emailActionEntities.Add(newemailActionEntity);

            }
            return emailActionEntities;
        }
    }
}
