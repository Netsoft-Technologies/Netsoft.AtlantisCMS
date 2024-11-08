using Csla;
using Netsoft.AtlantisCMS.Dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Netsoft.AtlantisCMS.BusinessLibrary
{
    [Serializable]
    public class COnlineSettingEdit : BusinessBase<COnlineSettingEdit>
    {
        public static readonly PropertyInfo<int> PropIdProperty = RegisterProperty<int>(c => c.PropertyId);
        public int PropertyId
        {
            get { return GetProperty(PropIdProperty); }
            set { SetProperty(PropIdProperty, value); }
        }
        public static readonly PropertyInfo<bool?> AcceptCustomerSignInProperty = RegisterProperty<bool?>(c => c.AcceptCustomerSignIn);
        public bool? AcceptCustomerSignIn
        {
            get { return GetProperty(AcceptCustomerSignInProperty); }
            set { SetProperty(AcceptCustomerSignInProperty, value); }
        }
        public static readonly PropertyInfo<bool?> AcceptPMSSignInProperty = RegisterProperty<bool?>(c => c.AcceptPMSSignIn);
        public bool? AcceptPMSSignIn
        {
            get { return GetProperty(AcceptPMSSignInProperty); }
            set { SetProperty(AcceptPMSSignInProperty, value); }
        }
        public static readonly PropertyInfo<bool?> AcceptGoogleSignInProperty = RegisterProperty<bool?>(c => c.AcceptGoogleSignIn);
        public bool? AcceptGoogleSignIn
        {
            get { return GetProperty(AcceptGoogleSignInProperty); }
            set { SetProperty(AcceptGoogleSignInProperty, value); }
        }
        public static readonly PropertyInfo<string> FaceboolLinkProperty = RegisterProperty<string>(c => c.FacebookLink);
        public string FacebookLink
        {
            get { return GetProperty(FaceboolLinkProperty); }
            set { SetProperty(FaceboolLinkProperty, value); }
        }
        public static readonly PropertyInfo<string> InstagramLinkProperty = RegisterProperty<string>(c => c.InstagramLink);
        public string InstagramLink
        {
            get { return GetProperty(InstagramLinkProperty); }
            set { SetProperty(InstagramLinkProperty, value); }
        }
        public static readonly PropertyInfo<string> GoogleLinkProperty = RegisterProperty<string>(c => c.GoogleLink);
        public string GoogleLink
        {
            get { return GetProperty(GoogleLinkProperty); }
            set { SetProperty(GoogleLinkProperty, value); }
        }
        public static readonly PropertyInfo<string> TwitterLinkProperty = RegisterProperty<string>(c => c.TwitterLink);
        public string TwitterLink
        {
            get { return GetProperty(TwitterLinkProperty); }
            set { SetProperty(TwitterLinkProperty, value); }
        }
        public static readonly PropertyInfo<bool?> AcceptTreatmentsProperty = RegisterProperty<bool?>(c => c.AcceptTreatments);
        public bool? AcceptTreatments
        {
            get { return GetProperty(AcceptTreatmentsProperty); }
            set { SetProperty(AcceptTreatmentsProperty, value); }
        }
        public static readonly PropertyInfo<bool?> AcceptPackagesProperty = RegisterProperty<bool?>(c => c.AcceptPackages);
        public bool? AcceptPackages
        {
            get { return GetProperty(AcceptPackagesProperty); }
            set { SetProperty(AcceptPackagesProperty, value); }
        }
        public static readonly PropertyInfo<bool?> AcceptMembershipsProperty = RegisterProperty<bool?>(c => c.AcceptMemberships);
        public bool? AcceptMemberships
        {
            get { return GetProperty(AcceptMembershipsProperty); }
            set { SetProperty(AcceptMembershipsProperty, value); }
        }
        public static readonly PropertyInfo<bool?> AcceptCosmeticsProperty = RegisterProperty<bool?>(c => c.AcceptCosmetics);
        public bool? AcceptCosmetics
        {
            get { return GetProperty(AcceptCosmeticsProperty); }
            set { SetProperty(AcceptCosmeticsProperty, value); }
        }
        public static readonly PropertyInfo<bool?> SendConfirmationEmailProperty = RegisterProperty<bool?>(c => c.SendConfirmationEmail);
        public bool? SendConfirmationEmail
        {
            get { return GetProperty(SendConfirmationEmailProperty); }
            set { SetProperty(SendConfirmationEmailProperty, value); }
        }
        public static readonly PropertyInfo<int?> ConfirmationEmailTemplateIdProperty = RegisterProperty<int?>(c => c.ConfirmationEmailTemplateId);
        public int? ConfirmationEmailTemplateId
        {
            get { return GetProperty(ConfirmationEmailTemplateIdProperty); }
            set { SetProperty(ConfirmationEmailTemplateIdProperty, value); }
        }
        public static readonly PropertyInfo<bool?> SendInfoEmailProperty = RegisterProperty<bool?>(c => c.SendInfoEmail);
        public bool? SendInfoEmail
        {
            get { return GetProperty(SendInfoEmailProperty); }
            set { SetProperty(SendInfoEmailProperty, value); }
        }
        public static readonly PropertyInfo<string> SendInfoEmailListProperty = RegisterProperty<string>(c => c.SendInfoEmailList);
        public string SendInfoEmailList
        {
            get { return GetProperty(SendInfoEmailListProperty); }
            set { SetProperty(SendInfoEmailListProperty, value); }
        }
        public static readonly PropertyInfo<bool?> ValidPaymentCreditCardProperty = RegisterProperty<bool?>(c => c.ValidPaymentCreditCard);
        public bool? ValidPaymentCreditCard
        {
            get { return GetProperty(ValidPaymentCreditCardProperty); }
            set { SetProperty(ValidPaymentCreditCardProperty, value); }
        }
        public static readonly PropertyInfo<int?> CreditCardPaymentTypeIdProperty = RegisterProperty<int?>(c => c.CreditCardPaymentTypeId);
        public int? CreditCardPaymentTypeId
        {
            get { return GetProperty(CreditCardPaymentTypeIdProperty); }
            set { SetProperty(CreditCardPaymentTypeIdProperty, value); }
        }
        public static readonly PropertyInfo<bool?> ValidPaymentPayPalProperty = RegisterProperty<bool?>(c => c.ValidPaymentPayPal);
        public bool? ValidPaymentPayPal
        {
            get { return GetProperty(ValidPaymentPayPalProperty); }
            set { SetProperty(ValidPaymentPayPalProperty, value); }
        }
        public static readonly PropertyInfo<int?> PayPalPaymentTypeIdProperty = RegisterProperty<int?>(c => c.PayPalPaymentTypeId);
        public int? PayPalPaymentTypeId
        {
            get { return GetProperty(PayPalPaymentTypeIdProperty); }
            set { SetProperty(PayPalPaymentTypeIdProperty, value); }
        }
        public static readonly PropertyInfo<bool?> ValidPaymentPayOnDayProperty = RegisterProperty<bool?>(c => c.ValidPaymentPayOnDay);
        public bool? ValidPaymentPayOnDay
        {
            get { return GetProperty(ValidPaymentPayOnDayProperty); }
            set { SetProperty(ValidPaymentPayOnDayProperty, value); }
        }
        public static readonly PropertyInfo<bool?> ValidPaymentVivaProperty = RegisterProperty<bool?>(c => c.ValidPaymentViva);
        public bool? ValidPaymentViva
        {
            get { return GetProperty(ValidPaymentVivaProperty); }
            set { SetProperty(ValidPaymentVivaProperty, value); }
        }
        public static readonly PropertyInfo<int?> VivaPaymentTypeIdProperty = RegisterProperty<int?>(c => c.VivaPaymentTypeId);
        public int? VivaPaymentTypeId
        {
            get { return GetProperty(VivaPaymentTypeIdProperty); }
            set { SetProperty(VivaPaymentTypeIdProperty, value); }
        }
        public static readonly PropertyInfo<bool?> InvoiceIssueProperty = RegisterProperty<bool?>(c => c.InvoiceIssue);
        public bool? InvoiceIssue
        {
            get { return GetProperty(InvoiceIssueProperty); }
            set { SetProperty(InvoiceIssueProperty, value); }
        }
        public static readonly PropertyInfo<bool?> CreditCreateProperty = RegisterProperty<bool?>(c => c.CreditCreate);
        public bool? CreditCreate
        {
            get { return GetProperty(CreditCreateProperty); }
            set { SetProperty(CreditCreateProperty, value); }
        }
        public static readonly PropertyInfo<bool?> SendInvoiceEmailProperty = RegisterProperty<bool?>(c => c.SendInvoiceEmail);
        public bool? SendInvoiceEmail
        {
            get { return GetProperty(SendInvoiceEmailProperty); }
            set { SetProperty(SendInvoiceEmailProperty, value); }
        }
        public static readonly PropertyInfo<int?> InvoiceEmailtemplateIdProperty = RegisterProperty<int?>(c => c.InvoiceEmailTemplateId);
        public int? InvoiceEmailTemplateId
        {
            get { return GetProperty(InvoiceEmailtemplateIdProperty); }
            set { SetProperty(InvoiceEmailtemplateIdProperty, value); }
        }
        public static readonly PropertyInfo<bool?> SendEnquiryEmailProperty = RegisterProperty<bool?>(c => c.SendEnquiryEmail);
        public bool? SendEnquiryEmail
        {
            get { return GetProperty(SendEnquiryEmailProperty); }
            set { SetProperty(SendEnquiryEmailProperty, value); }
        }
        public static readonly PropertyInfo<int?> EnquiryEmailTemplateIdProperty = RegisterProperty<int?>(c => c.EnquiryEmailTemplateId);
        public int? EnquiryEmailTemplateId
        {
            get { return GetProperty(EnquiryEmailTemplateIdProperty); }
            set { SetProperty(EnquiryEmailTemplateIdProperty, value); }
        }
        public static readonly PropertyInfo<string> GoogleAnalyticsGtag1Property = RegisterProperty<string>(c => c.GoogleAnalyticsGtag1);
        public string GoogleAnalyticsGtag1
        {
            get { return GetProperty(GoogleAnalyticsGtag1Property); }
            set { SetProperty(GoogleAnalyticsGtag1Property, value); }
        }
        public static readonly PropertyInfo<string> GoogleAnalyticsGtag2Property = RegisterProperty<string>(c => c.GoogleAnalyticsGtag2);
        public string GoogleAnalyticsGtag2
        {
            get { return GetProperty(GoogleAnalyticsGtag2Property); }
            set { SetProperty(GoogleAnalyticsGtag2Property, value); }
        }
        public static readonly PropertyInfo<string> PaymentMerchantIdProperty = RegisterProperty<string>(c => c.PaymentMerchantId);
        public string PaymentMerchantId
        {
            get { return GetProperty(PaymentMerchantIdProperty); }
            set { SetProperty(PaymentMerchantIdProperty, value); }
        }
        public static readonly PropertyInfo<string> PaymentSecretCodeProperty = RegisterProperty<string>(c => c.PaymentSecretCode);
        public string PaymentSecretCode
        {
            get { return GetProperty(PaymentSecretCodeProperty); }
            set { SetProperty(PaymentSecretCodeProperty, value); }
        }
        public static readonly PropertyInfo<string> PaymentConfirmUrlProperty = RegisterProperty<string>(c => c.PaymentConfirmUrl);
        public string PaymentConfirmUrl
        {
            get { return GetProperty(PaymentConfirmUrlProperty); }
            set { SetProperty(PaymentConfirmUrlProperty, value); }
        }
        public static readonly PropertyInfo<string> PaymentCancelUrlProperty = RegisterProperty<string>(c => c.PaymentCancelUrl);
        public string PaymentCancelUrl
        {
            get { return GetProperty(PaymentCancelUrlProperty); }
            set { SetProperty(PaymentCancelUrlProperty, value); }
        }
        public static readonly PropertyInfo<string> PaymentGatewayUrlProperty = RegisterProperty<string>(c => c.PaymentGatewayUrl);
        public string PaymentGatewayUrl
        {
            get { return GetProperty(PaymentGatewayUrlProperty); }
            set { SetProperty(PaymentGatewayUrlProperty, value); }
        }
        public static readonly PropertyInfo<bool?> SendCancellationEmailProperty = RegisterProperty<bool?>(c => c.SendCancellationEmail);
        public bool? SendCancellationEmail
        {
            get { return GetProperty(SendCancellationEmailProperty); }
            set { SetProperty(SendCancellationEmailProperty, value); }
        }
        public static readonly PropertyInfo<int?> CancellationEmailTemplateIdProperty = RegisterProperty<int?>(c => c.CancellationEmailTemplateId);
        public int? CancellationEmailTemplateId
        {
            get { return GetProperty(CancellationEmailTemplateIdProperty); }
            set { SetProperty(CancellationEmailTemplateIdProperty, value); }
        }
        public static readonly PropertyInfo<bool?> SendCancellationInfoEmailProperty = RegisterProperty<bool?>(c => c.SendCancellationInfoEmail);
        public bool? SendCancellationInfoEmail
        {
            get { return GetProperty(SendCancellationInfoEmailProperty); }
            set { SetProperty(SendCancellationInfoEmailProperty, value); }
        }
        public static readonly PropertyInfo<string> CancellationInfoEmailListProperty = RegisterProperty<string>(c => c.CancellationInfoEmailList);
        public string CancellationInfoEmailList
        {
            get { return GetProperty(CancellationInfoEmailListProperty); }
            set { SetProperty(CancellationInfoEmailListProperty, value); }
        }
        public static readonly PropertyInfo<bool?> SendRescheduleEmailProperty = RegisterProperty<bool?>(c => c.SendRescheduleEmail);
        public bool? SendRescheduleEmail
        {
            get { return GetProperty(SendRescheduleEmailProperty); }
            set { SetProperty(SendRescheduleEmailProperty, value); }
        }
        public static readonly PropertyInfo<int?> RescheduleEmailTemplateIdProperty = RegisterProperty<int?>(c => c.RescheduleEmailTemplateId);
        public int? RescheduleEmailTemplateId
        {
            get { return GetProperty(RescheduleEmailTemplateIdProperty); }
            set { SetProperty(RescheduleEmailTemplateIdProperty, value); }
        }
        public static readonly PropertyInfo<bool?> SendRescheduleInfoEmailProperty = RegisterProperty<bool?>(c => c.SendRescheduleInfoEmail);
        public bool? SendRescheduleInfoEmail
        {
            get { return GetProperty(SendRescheduleInfoEmailProperty); }
            set { SetProperty(SendRescheduleInfoEmailProperty, value); }
        }
        public static readonly PropertyInfo<string> RescheduleInfoEmailListProperty = RegisterProperty<string>(c => c.RescheduleInfoEmailList);
        public string RescheduleInfoEmailList
        {
            get { return GetProperty(RescheduleInfoEmailListProperty); }
            set { SetProperty(RescheduleInfoEmailListProperty, value); }
        }
        public static readonly PropertyInfo<int?> HTMLPagesStylingIdProperty = RegisterProperty<int?>(c => c.HTMLPagesStylingId);
        public int? HTMLPagesStylingId
        {
            get { return GetProperty(HTMLPagesStylingIdProperty); }
            set { SetProperty(HTMLPagesStylingIdProperty, value); }
        }
        [Create]
        [RunLocal]
        private void Create()
        {
            BusinessRules.CheckRules();
        }
        [Fetch]
        private void Fetch(int id, [Inject] IOnlineSettingDal dal)
        {
            var data = dal.Fetch(id);
            using (BypassPropertyChecks)
            {
                PropertyId = data.PropertyId;
                AcceptCustomerSignIn = data.AcceptCustomerSignIn;
                AcceptPMSSignIn = data.AcceptPMSSignIn;
                AcceptGoogleSignIn = data.AcceptGoogleSignIn;
                FacebookLink = data.FacebookLink;
                InstagramLink = data.InstagramLink;
                GoogleLink = data.GoogleLink;
                TwitterLink = data.TwitterLink;
                AcceptTreatments = data.AcceptTreatments;
                AcceptPackages = data.AcceptPackages;
                AcceptMemberships = data.AcceptMemberships;
                AcceptCosmetics = data.AcceptCosmetics;
                SendConfirmationEmail = data.SendConfirmationEmail;
                ConfirmationEmailTemplateId = data.ConfirmationEmailTemplateId;
                SendInfoEmail = data.SendInfoEmail;
                SendInfoEmailList = data.SendInfoEmailList;
                ValidPaymentCreditCard = data.ValidPaymentCreditCard;
                CreditCardPaymentTypeId = data.CreditCardPaymentTypeId;
                ValidPaymentPayPal = data.ValidPaymentPayPal;
                PayPalPaymentTypeId = data.PayPalPaymentTypeId;
                ValidPaymentPayOnDay = data.ValidPaymentPayOnDay;
                ValidPaymentViva = data.ValidPaymentViva;
                VivaPaymentTypeId = data.VivaPaymentTypeId;
                InvoiceIssue = data.InvoiceIssue;
                CreditCreate = data.CreditCreate;
                SendInvoiceEmail = data.SendInvoiceEmail;
                InvoiceEmailTemplateId = data.InvoiceEmailTemplateId;
                SendEnquiryEmail = data.SendEnquiryEmail;
                EnquiryEmailTemplateId = data.EnquiryEmailTemplateId;
                GoogleAnalyticsGtag1 = data.GoogleAnalyticsGtag1;
                GoogleAnalyticsGtag2 = data.GoogleAnalyticsGtag2;
                PaymentMerchantId = data.PaymentMerchantId;
                PaymentSecretCode = data.PaymentSecretCode;
                PaymentConfirmUrl = data.PaymentConfirmUrl;
                PaymentCancelUrl = data.PaymentCancelUrl;
                PaymentGatewayUrl = data.PaymentGatewayUrl;
                SendCancellationEmail = data.SendCancellationEmail;
                CancellationEmailTemplateId = data.CancellationEmailTemplateId;
                SendCancellationInfoEmail = data.SendCancellationInfoEmail;
                CancellationInfoEmailList = data.CancellationInfoEmailList;
                SendRescheduleEmail = data.SendRescheduleEmail;
                RescheduleEmailTemplateId = data.RescheduleEmailTemplateId;
                SendRescheduleInfoEmail = data.SendRescheduleInfoEmail;
                RescheduleInfoEmailList = data.RescheduleInfoEmailList;
                HTMLPagesStylingId = data.HTMLPagesStylingId;
            }
        }
        [FetchChild]
        private void Fetch(DOnlineSettingDto item)
        {
            PropertyId = item.PropertyId;
            AcceptCustomerSignIn = item.AcceptCustomerSignIn;
            AcceptPMSSignIn = item.AcceptPMSSignIn;
            AcceptGoogleSignIn = item.AcceptGoogleSignIn;
            FacebookLink = item.FacebookLink;
            InstagramLink = item.InstagramLink;
            GoogleLink = item.GoogleLink;
            TwitterLink = item.TwitterLink;
            AcceptTreatments = item.AcceptTreatments;
            AcceptPackages = item.AcceptPackages;
            AcceptMemberships = item.AcceptMemberships;
            AcceptCosmetics = item.AcceptCosmetics;
            SendConfirmationEmail = item.SendConfirmationEmail;
            ConfirmationEmailTemplateId = item.ConfirmationEmailTemplateId;
            SendInfoEmail = item.SendInfoEmail;
            SendInfoEmailList = item.SendInfoEmailList;
            ValidPaymentCreditCard = item.ValidPaymentCreditCard;
            CreditCardPaymentTypeId = item.CreditCardPaymentTypeId;
            ValidPaymentPayPal = item.ValidPaymentPayPal;
            PayPalPaymentTypeId = item.PayPalPaymentTypeId;
            ValidPaymentPayOnDay = item.ValidPaymentPayOnDay;
            ValidPaymentViva = item.ValidPaymentViva;
            VivaPaymentTypeId = item.VivaPaymentTypeId;
            InvoiceIssue = item.InvoiceIssue;
            CreditCreate = item.CreditCreate;
            SendInvoiceEmail = item.SendInvoiceEmail;
            InvoiceEmailTemplateId = item.InvoiceEmailTemplateId;
            SendEnquiryEmail = item.SendEnquiryEmail;
            EnquiryEmailTemplateId = item.EnquiryEmailTemplateId;
            GoogleAnalyticsGtag1 = item.GoogleAnalyticsGtag1;
            GoogleAnalyticsGtag2 = item.GoogleAnalyticsGtag2;
            PaymentMerchantId = item.PaymentMerchantId;
            PaymentSecretCode = item.PaymentSecretCode;
            PaymentConfirmUrl = item.PaymentConfirmUrl;
            PaymentCancelUrl = item.PaymentCancelUrl;
            PaymentGatewayUrl = item.PaymentGatewayUrl;
            SendCancellationEmail = item.SendCancellationEmail;
            CancellationEmailTemplateId = item.CancellationEmailTemplateId;
            SendCancellationInfoEmail = item.SendCancellationInfoEmail;
            CancellationInfoEmailList = item.CancellationInfoEmailList;
            SendRescheduleEmail = item.SendRescheduleEmail;
            RescheduleEmailTemplateId = item.RescheduleEmailTemplateId;
            SendRescheduleInfoEmail = item.SendRescheduleInfoEmail;
            RescheduleInfoEmailList = item.RescheduleInfoEmailList;
            HTMLPagesStylingId = item.HTMLPagesStylingId;
        }
        [Insert]
        private void Insert([Inject] IOnlineSettingDal dal)
        {
            using (BypassPropertyChecks)
            {
                var item = new DOnlineSettingDto
                {
                    PropertyId = this.PropertyId,
                    AcceptCustomerSignIn = this.AcceptCustomerSignIn,
                    AcceptPMSSignIn = this.AcceptPMSSignIn,
                    AcceptGoogleSignIn = this.AcceptGoogleSignIn,
                    FacebookLink = this.FacebookLink,
                    InstagramLink = this.InstagramLink,
                    GoogleLink = this.GoogleLink,
                    TwitterLink = this.TwitterLink,
                    AcceptTreatments = this.AcceptTreatments,
                    AcceptPackages = this.AcceptPackages,
                    AcceptMemberships = this.AcceptMemberships,
                    AcceptCosmetics = this.AcceptCosmetics,
                    SendConfirmationEmail = this.SendConfirmationEmail,
                    ConfirmationEmailTemplateId = this.ConfirmationEmailTemplateId,
                    SendInfoEmail = this.SendInfoEmail,
                    SendInfoEmailList = this.SendInfoEmailList,
                    ValidPaymentCreditCard = this.ValidPaymentCreditCard,
                    CreditCardPaymentTypeId = this.CreditCardPaymentTypeId,
                    ValidPaymentPayPal = this.ValidPaymentPayPal,
                    PayPalPaymentTypeId = this.PayPalPaymentTypeId,
                    ValidPaymentPayOnDay = this.ValidPaymentPayOnDay,
                    ValidPaymentViva = this.ValidPaymentViva,
                    VivaPaymentTypeId = this.VivaPaymentTypeId,
                    InvoiceIssue = this.InvoiceIssue,
                    CreditCreate = this.CreditCreate,
                    SendInvoiceEmail = this.SendInvoiceEmail,
                    InvoiceEmailTemplateId = this.InvoiceEmailTemplateId,
                    SendEnquiryEmail = this.SendEnquiryEmail,
                    EnquiryEmailTemplateId = this.EnquiryEmailTemplateId,
                    GoogleAnalyticsGtag1 = this.GoogleAnalyticsGtag1,
                    GoogleAnalyticsGtag2 = this.GoogleAnalyticsGtag2,
                    PaymentMerchantId = this.PaymentMerchantId,
                    PaymentSecretCode = this.PaymentSecretCode,
                    PaymentConfirmUrl = this.PaymentConfirmUrl,
                    PaymentCancelUrl = this.PaymentCancelUrl,
                    PaymentGatewayUrl = this.PaymentGatewayUrl,
                    SendCancellationEmail = this.SendCancellationEmail,
                    CancellationEmailTemplateId = this.CancellationEmailTemplateId,
                    SendCancellationInfoEmail = this.SendCancellationInfoEmail,
                    CancellationInfoEmailList = this.CancellationInfoEmailList,
                    SendRescheduleEmail = this.SendRescheduleEmail,
                    RescheduleEmailTemplateId = this.RescheduleEmailTemplateId,
                    SendRescheduleInfoEmail = this.SendRescheduleInfoEmail,
                    RescheduleInfoEmailList = this.RescheduleInfoEmailList,
                    HTMLPagesStylingId = this.HTMLPagesStylingId,
                };
                dal.Insert(item);
                PropertyId = item.PropertyId;
            }
            FieldManager.UpdateChildren(this);
        }
        [Update]
        private void Update([Inject] IOnlineSettingDal dal)
        {
            using (BypassPropertyChecks)
            {
                var item = new DOnlineSettingDto
                {
                    PropertyId = this.PropertyId,
                    AcceptCustomerSignIn = this.AcceptCustomerSignIn,
                    AcceptPMSSignIn = this.AcceptPMSSignIn,
                    AcceptGoogleSignIn = this.AcceptGoogleSignIn,
                    FacebookLink = this.FacebookLink,
                    InstagramLink = this.InstagramLink,
                    GoogleLink = this.GoogleLink,
                    TwitterLink = this.TwitterLink,
                    AcceptTreatments = this.AcceptTreatments,
                    AcceptPackages = this.AcceptPackages,
                    AcceptMemberships = this.AcceptMemberships,
                    AcceptCosmetics = this.AcceptCosmetics,
                    SendConfirmationEmail = this.SendConfirmationEmail,
                    ConfirmationEmailTemplateId = this.ConfirmationEmailTemplateId,
                    SendInfoEmail = this.SendInfoEmail,
                    SendInfoEmailList = this.SendInfoEmailList,
                    ValidPaymentCreditCard = this.ValidPaymentCreditCard,
                    CreditCardPaymentTypeId = this.CreditCardPaymentTypeId,
                    ValidPaymentPayPal = this.ValidPaymentPayPal,
                    PayPalPaymentTypeId = this.PayPalPaymentTypeId,
                    ValidPaymentPayOnDay = this.ValidPaymentPayOnDay,
                    ValidPaymentViva = this.ValidPaymentViva,
                    VivaPaymentTypeId = this.VivaPaymentTypeId,
                    InvoiceIssue = this.InvoiceIssue,
                    CreditCreate = this.CreditCreate,
                    SendInvoiceEmail = this.SendInvoiceEmail,
                    InvoiceEmailTemplateId = this.InvoiceEmailTemplateId,
                    SendEnquiryEmail = this.SendEnquiryEmail,
                    EnquiryEmailTemplateId = this.EnquiryEmailTemplateId,
                    GoogleAnalyticsGtag1 = this.GoogleAnalyticsGtag1,
                    GoogleAnalyticsGtag2 = this.GoogleAnalyticsGtag2,
                    PaymentMerchantId = this.PaymentMerchantId,
                    PaymentSecretCode = this.PaymentSecretCode,
                    PaymentConfirmUrl = this.PaymentConfirmUrl,
                    PaymentCancelUrl = this.PaymentCancelUrl,
                    PaymentGatewayUrl = this.PaymentGatewayUrl,
                    SendCancellationEmail = this.SendCancellationEmail,
                    CancellationEmailTemplateId = this.CancellationEmailTemplateId,
                    SendCancellationInfoEmail = this.SendCancellationInfoEmail,
                    CancellationInfoEmailList = this.CancellationInfoEmailList,
                    SendRescheduleEmail = this.SendRescheduleEmail,
                    RescheduleEmailTemplateId = this.RescheduleEmailTemplateId,
                    SendRescheduleInfoEmail = this.SendRescheduleInfoEmail,
                    RescheduleInfoEmailList = this.RescheduleInfoEmailList,
                    HTMLPagesStylingId = this.HTMLPagesStylingId
                };
                dal.Update(item);
            }
            FieldManager.UpdateChildren(this.PropertyId);
        }
        [Delete]
        private void Delete(int id, [Inject] IOnlineSettingDal dal)
        {
            dal.Delete(id);
        }
    }
}
