using Netsoft.AtlantisCMS.Dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Netsoft.AtlantisCMS.DalEfCore
{
    public class OnlineSettingDal : IOnlineSettingDal
    {
        private readonly DbContext db;
        public OnlineSettingDal(DbContext context)
        {
            db = context;
        }
        public DOnlineSettingDto Fetch(int id)
        {
            var res = (from r in db._OnlineSettings
                       where r.PropertyId == id
                       select new DOnlineSettingDto
                       {
                           PropertyId = r.PropertyId,
                           AcceptCustomerSignIn = r.AcceptCustomerSignIn,
                           AcceptPMSSignIn = r.AcceptPMSSignIn,
                           AcceptGoogleSignIn = r.AcceptGoogleSignIn,
                           FacebookLink = r.FacebookLink,
                           InstagramLink = r.InstagramLink,
                           GoogleLink = r.GoogleLink,
                           TwitterLink = r.TwitterLink,
                           AcceptTreatments = r.AcceptTreatments,
                           AcceptPackages = r.AcceptPackages,
                           AcceptMemberships = r.AcceptMemberships,
                           AcceptCosmetics = r.AcceptCosmetics,
                           SendConfirmationEmail = r.SendConfirmationEmail,
                           ConfirmationEmailTemplateId = r.ConfirmationEmailTemplateId,
                           SendInfoEmail = r.SendInfoEmail,
                           SendInfoEmailList = r.SendInfoEmailList,
                           ValidPaymentCreditCard = r.ValidPaymentCreditCard,
                           CreditCardPaymentTypeId = r.CreditCardPaymentTypeId,
                           ValidPaymentPayPal = r.ValidPaymentPayPal,
                           PayPalPaymentTypeId = r.PayPalPaymentTypeId,
                           ValidPaymentPayOnDay = r.ValidPaymentPayOnDay,
                           ValidPaymentViva = r.ValidPaymentViva,
                           VivaPaymentTypeId = r.VivaPaymentTypeId,
                           InvoiceIssue = r.InvoiceIssue,
                           CreditCreate = r.CreditCreate,
                           SendInvoiceEmail = r.SendInvoiceEmail,
                           InvoiceEmailTemplateId = r.InvoiceEmailTemplateId,
                           SendEnquiryEmail = r.SendEnquiryEmail,
                           EnquiryEmailTemplateId = r.EnquiryEmailTemplateId,
                           GoogleAnalyticsGtag1 = r.GoogleAnalyticsGtag1,
                           GoogleAnalyticsGtag2 = r.GoogleAnalyticsGtag2,
                           PaymentMerchantId = r.PaymentMerchantId,
                           PaymentSecretCode = r.PaymentSecretCode,
                           PaymentConfirmUrl = r.PaymentConfirmUrl,
                           PaymentCancelUrl = r.PaymentCancelUrl,
                           PaymentGatewayUrl = r.PaymentGatewayUrl,
                           SendCancellationEmail = r.SendCancellationEmail,
                           CancellationEmailTemplateId = r.CancellationEmailTemplateId,
                           SendCancellationInfoEmail = r.SendCancellationInfoEmail,
                           CancellationInfoEmailList = r.CancellationInfoEmailList,
                           SendRescheduleEmail = r.SendRescheduleEmail,
                           RescheduleEmailTemplateId = r.RescheduleEmailTemplateId,
                           SendRescheduleInfoEmail = r.SendRescheduleInfoEmail,
                           RescheduleInfoEmailList = r.RescheduleInfoEmailList,
                           HTMLPagesStylingId = r.HTMLPagesStylingId
                       }).FirstOrDefault();
            return res;
        }
        public List<DOnlineSettingDto> Fetch()
        {
            var res = from r in db._OnlineSettings
                      select new DOnlineSettingDto
                      {
                          PropertyId = r.PropertyId,
                          AcceptCustomerSignIn = r.AcceptCustomerSignIn,
                          AcceptPMSSignIn = r.AcceptPMSSignIn,
                          AcceptGoogleSignIn = r.AcceptGoogleSignIn,
                          FacebookLink = r.FacebookLink,
                          InstagramLink = r.InstagramLink,
                          GoogleLink = r.GoogleLink,
                          TwitterLink = r.TwitterLink,
                          AcceptTreatments = r.AcceptTreatments,
                          AcceptPackages = r.AcceptPackages,
                          AcceptMemberships = r.AcceptMemberships,
                          AcceptCosmetics = r.AcceptCosmetics,
                          SendConfirmationEmail = r.SendConfirmationEmail,
                          ConfirmationEmailTemplateId = r.ConfirmationEmailTemplateId,
                          SendInfoEmail = r.SendInfoEmail,
                          SendInfoEmailList = r.SendInfoEmailList,
                          ValidPaymentCreditCard = r.ValidPaymentCreditCard,
                          CreditCardPaymentTypeId = r.CreditCardPaymentTypeId,
                          ValidPaymentPayPal = r.ValidPaymentPayPal,
                          PayPalPaymentTypeId = r.PayPalPaymentTypeId,
                          ValidPaymentPayOnDay = r.ValidPaymentPayOnDay,
                          ValidPaymentViva = r.ValidPaymentViva,
                          VivaPaymentTypeId = r.VivaPaymentTypeId,
                          InvoiceIssue = r.InvoiceIssue,
                          CreditCreate = r.CreditCreate,
                          SendInvoiceEmail = r.SendInvoiceEmail,
                          InvoiceEmailTemplateId = r.InvoiceEmailTemplateId,
                          SendEnquiryEmail = r.SendEnquiryEmail,
                          EnquiryEmailTemplateId = r.EnquiryEmailTemplateId,
                          GoogleAnalyticsGtag1 = r.GoogleAnalyticsGtag1,
                          GoogleAnalyticsGtag2 = r.GoogleAnalyticsGtag2,
                          PaymentMerchantId = r.PaymentMerchantId,
                          PaymentSecretCode = r.PaymentSecretCode,
                          PaymentConfirmUrl = r.PaymentConfirmUrl,
                          PaymentCancelUrl = r.PaymentCancelUrl,
                          PaymentGatewayUrl = r.PaymentGatewayUrl,
                          SendCancellationEmail = r.SendCancellationEmail,
                          CancellationEmailTemplateId = r.CancellationEmailTemplateId,
                          SendCancellationInfoEmail = r.SendCancellationInfoEmail,
                          CancellationInfoEmailList = r.CancellationInfoEmailList,
                          SendRescheduleEmail = r.SendRescheduleEmail,
                          RescheduleEmailTemplateId = r.RescheduleEmailTemplateId,
                          SendRescheduleInfoEmail = r.SendRescheduleInfoEmail,
                          RescheduleInfoEmailList = r.RescheduleInfoEmailList,
                          HTMLPagesStylingId = r.HTMLPagesStylingId
                      };
            return res.ToList();
        }
        public void Insert(DOnlineSettingDto dto)
        {
            var newSetting = new OnlineSetting_Entity
            {
                PropertyId = dto.PropertyId,
                AcceptCustomerSignIn = dto.AcceptCustomerSignIn,
                AcceptPMSSignIn = dto.AcceptPMSSignIn,
                AcceptGoogleSignIn = dto.AcceptGoogleSignIn,
                FacebookLink = dto.FacebookLink,
                InstagramLink = dto.InstagramLink,
                GoogleLink = dto.GoogleLink,
                TwitterLink = dto.TwitterLink,
                AcceptTreatments = dto.AcceptTreatments,
                AcceptPackages = dto.AcceptPackages,
                AcceptMemberships = dto.AcceptMemberships,
                AcceptCosmetics = dto.AcceptCosmetics,
                SendConfirmationEmail = dto.SendConfirmationEmail,
                ConfirmationEmailTemplateId = dto.ConfirmationEmailTemplateId,
                SendInfoEmail = dto.SendInfoEmail,
                SendInfoEmailList = dto.SendInfoEmailList,
                ValidPaymentCreditCard = dto.ValidPaymentCreditCard,
                CreditCardPaymentTypeId = dto.CreditCardPaymentTypeId,
                ValidPaymentPayPal = dto.ValidPaymentPayPal,
                PayPalPaymentTypeId = dto.PayPalPaymentTypeId,
                ValidPaymentPayOnDay = dto.ValidPaymentPayOnDay,
                ValidPaymentViva = dto.ValidPaymentViva,
                VivaPaymentTypeId = dto.VivaPaymentTypeId,
                InvoiceIssue = dto.InvoiceIssue,
                CreditCreate = dto.CreditCreate,
                SendInvoiceEmail = dto.SendInvoiceEmail,
                InvoiceEmailTemplateId = dto.InvoiceEmailTemplateId,
                SendEnquiryEmail = dto.SendEnquiryEmail,
                EnquiryEmailTemplateId = dto.EnquiryEmailTemplateId,
                GoogleAnalyticsGtag1 = dto.GoogleAnalyticsGtag1,
                GoogleAnalyticsGtag2 = dto.GoogleAnalyticsGtag2,
                PaymentMerchantId = dto.PaymentMerchantId,
                PaymentSecretCode = dto.PaymentSecretCode,
                PaymentConfirmUrl = dto.PaymentConfirmUrl,
                PaymentCancelUrl = dto.PaymentCancelUrl,
                PaymentGatewayUrl = dto.PaymentGatewayUrl,
                SendCancellationEmail = dto.SendCancellationEmail,
                CancellationEmailTemplateId = dto.CancellationEmailTemplateId,
                SendCancellationInfoEmail = dto.SendCancellationInfoEmail,
                CancellationInfoEmailList = dto.CancellationInfoEmailList,
                SendRescheduleEmail = dto.SendRescheduleEmail,
                RescheduleEmailTemplateId = dto.RescheduleEmailTemplateId,
                SendRescheduleInfoEmail = dto.SendRescheduleInfoEmail,
                RescheduleInfoEmailList = dto.RescheduleInfoEmailList,
                HTMLPagesStylingId = dto.HTMLPagesStylingId
            };
            db._OnlineSettings.Add(newSetting);
            db.SaveChanges();
            dto.PropertyId = newSetting.PropertyId;
        }
        public void Update(DOnlineSettingDto dto)
        {
            var editSetting = (from r in db._OnlineSettings
                               where r.PropertyId == dto.PropertyId
                               select r).FirstOrDefault();
            if (editSetting == null)
            {
                throw new Exception("Not Found");
            }
            editSetting.PropertyId = dto.PropertyId;
            editSetting.AcceptCustomerSignIn = dto.AcceptCustomerSignIn;
            editSetting.AcceptPMSSignIn = dto.AcceptPMSSignIn;
            editSetting.AcceptGoogleSignIn = dto.AcceptGoogleSignIn;
            editSetting.FacebookLink = dto.FacebookLink;
            editSetting.InstagramLink = dto.InstagramLink;
            editSetting.GoogleLink = dto.GoogleLink;
            editSetting.TwitterLink = dto.TwitterLink;
            editSetting.AcceptTreatments = dto.AcceptTreatments;
            editSetting.AcceptPackages = dto.AcceptPackages;
            editSetting.AcceptMemberships = dto.AcceptMemberships;
            editSetting.AcceptCosmetics = dto.AcceptCosmetics;
            editSetting.SendConfirmationEmail = dto.SendConfirmationEmail;
            editSetting.ConfirmationEmailTemplateId = dto.ConfirmationEmailTemplateId;
            editSetting.SendInfoEmail = dto.SendInfoEmail;
            editSetting.SendInfoEmailList = dto.SendInfoEmailList;
            editSetting.ValidPaymentCreditCard = dto.ValidPaymentCreditCard;
            editSetting.CreditCardPaymentTypeId = dto.CreditCardPaymentTypeId;
            editSetting.ValidPaymentPayPal = dto.ValidPaymentPayPal;
            editSetting.PayPalPaymentTypeId = dto.PayPalPaymentTypeId;
            editSetting.ValidPaymentPayOnDay = dto.ValidPaymentPayOnDay;
            editSetting.ValidPaymentViva = dto.ValidPaymentViva;
            editSetting.VivaPaymentTypeId = dto.VivaPaymentTypeId;
            editSetting.InvoiceIssue = dto.InvoiceIssue;
            editSetting.CreditCreate = dto.CreditCreate;
            editSetting.SendInvoiceEmail = dto.SendInvoiceEmail;
            editSetting.InvoiceEmailTemplateId = dto.InvoiceEmailTemplateId;
            editSetting.SendEnquiryEmail = dto.SendEnquiryEmail;
            editSetting.EnquiryEmailTemplateId = dto.EnquiryEmailTemplateId;
            editSetting.GoogleAnalyticsGtag1 = dto.GoogleAnalyticsGtag1;
            editSetting.GoogleAnalyticsGtag2 = dto.GoogleAnalyticsGtag2;
            editSetting.PaymentMerchantId = dto.PaymentMerchantId;
            editSetting.PaymentSecretCode = dto.PaymentSecretCode;
            editSetting.PaymentConfirmUrl = dto.PaymentConfirmUrl;
            editSetting.PaymentCancelUrl = dto.PaymentCancelUrl;
            editSetting.PaymentGatewayUrl = dto.PaymentGatewayUrl;
            editSetting.SendCancellationEmail = dto.SendCancellationEmail;
            editSetting.CancellationEmailTemplateId = dto.CancellationEmailTemplateId;
            editSetting.SendCancellationInfoEmail = dto.SendCancellationInfoEmail;
            editSetting.CancellationInfoEmailList = dto.CancellationInfoEmailList;
            editSetting.SendRescheduleEmail = dto.SendRescheduleEmail;
            editSetting.RescheduleEmailTemplateId = dto.RescheduleEmailTemplateId;
            editSetting.SendRescheduleInfoEmail = dto.SendRescheduleInfoEmail;
            editSetting.RescheduleInfoEmailList = dto.RescheduleInfoEmailList;
            editSetting.HTMLPagesStylingId = dto.HTMLPagesStylingId;
            var res = db.SaveChanges();
        }
        public void Delete(int id)
        {
            var data = (from r in db._OnlineSettings 
                        where r.PropertyId == id 
                        select r).FirstOrDefault();
            if (data != null)
            {
                db._OnlineSettings.Remove(data);
                db.SaveChanges();
            }
        }
    }
}
