using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using RefServices;
using System.ServiceModel.Activation;
using System.Globalization;
using System.ServiceModel.Web;

namespace RefServices
{

    //[AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Required)]

    [System.ServiceModel.ServiceBehaviorAttribute(InstanceContextMode = System.ServiceModel.InstanceContextMode.PerCall,
        ConcurrencyMode = System.ServiceModel.ConcurrencyMode.Single)]
    public class RefService : IRefService
    {
        
        public Customer GetCustomer(string id)
        {
            int parsedID = int.Parse(id);
            Customer cust = new Customer();

            switch (parsedID)
            {
                case 1:
                    cust.FirstName = "Nikolai";
                    cust.LastName = "Popov";
                    cust.ID = 1;
                    return cust;

                case 2:
                    cust.FirstName = "Nikolai2";
                    cust.LastName = "Popov2";
                    cust.ID = 2;
                    return cust;
                default: return cust;
            }
        }

        public string WebOperation(string operation)
        {
            return string.Format("You sent this '{0}'.", operation);
        }

        public matchByNameResponse1 matchByName(matchByNameRequest request)
        {
            if (request.matchByName.name == "Nikolai")
            {
                throw new ArgumentOutOfRangeException("This is exception!");
            }
            try
            {
                int res = int.Parse(request.matchByName.name);
            }
            catch (FormatException exp)
            {
                throw new FaultException("Cant't convert string to a number,type of error is : " + exp.GetType().ToString());
            }
            catch (ArgumentNullException exp)
            {
                //throw new FaultException("Cannot request with null argument,can't convert a null value",
                //    FaultCode.CreateReceiverFaultCode(new FaultCode("Parse")));

                TrackedFault tf = new TrackedFault(Guid.NewGuid(), exp.Message, DateTime.Now);
                throw new FaultException<TrackedFault>(tf, exp.Message, FaultCode.CreateReceiverFaultCode(new FaultCode(exp.GetType().ToString())));
            }
            catch (Exception exp)
            {
                List<FaultReasonText> frts = new List<FaultReasonText>();

                frts.Add(new FaultReasonText(exp.Message));
                frts.Add(new FaultReasonText("france", new CultureInfo("fr-FR")));
                frts.Add(new FaultReasonText("bulgarian", new CultureInfo("bg-BG")));

                throw new FaultException(new FaultReason(frts),
                    FaultCode.CreateReceiverFaultCode(new FaultCode("Type of exception is : " +
                        exp.GetType().ToString())));
            }
            matchByNameResponse1 result = new matchByNameResponse1();
            result.matchByNameResponse = new matchByNameResponse();
            result.matchByNameResponse.name = "This is just a response!";
            return result;
        }

        public virtual matchByCodeResponse1 matchByCode(matchByCodeRequest request)
        {
            return new matchByCodeResponse1();
        }

        public virtual getMutationsResponse1 getMutations(getMutationsRequest request)
        {
            return new getMutationsResponse1();
        }

        public virtual getDataXMLResponse1 getDataXML(getDataXMLRequest request)
        {
            return new getDataXMLResponse1();
        }

        public virtual getRisDataXMLResponse1 getRisDataXML(getRisDataXMLRequest request)
        {
            return new getRisDataXMLResponse1();
        }

        public virtual mutateDataXMLResponse1 mutateDataXML(mutateDataXMLRequest request)
        {
            return new mutateDataXMLResponse1();
        }

        public virtual requestMutationXMLResponse1 requestMutationXML(requestMutationXMLRequest request)
        {
            return new requestMutationXMLResponse1();
        }

    }
}
