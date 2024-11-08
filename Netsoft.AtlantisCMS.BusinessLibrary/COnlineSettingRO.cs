using Csla;
using Csla.DataPortalClient;
using Netsoft.AtlantisCMS.Dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Netsoft.AtlantisCMS.BusinessLibrary
{
    [Serializable]
    public class COnlineSettingRO : ReadOnlyBase<COnlineSettingRO>
    {
        public static readonly PropertyInfo<int> PropIdProperty = RegisterProperty<int>(c => c.PropertyId);
        public int PropertyId
        {
            get { return GetProperty(PropIdProperty); }
            private set { LoadProperty(PropIdProperty, value); }
        }
        public static readonly PropertyInfo<bool?> AcceptCustomerSignInProperty = RegisterProperty<bool?>(c => c.AcceptCustomerSignIn);
        public bool? AcceptCustomerSignIn
        {
            get { return GetProperty(AcceptCustomerSignInProperty); }
            private set { LoadProperty(AcceptCustomerSignInProperty, value); }
        }
        public static readonly PropertyInfo<bool?> AcceptPMSSignInProperty = RegisterProperty<bool?>(c => c.AcceptPMSSignIn);
        public bool? AcceptPMSSignIn
        {
            get { return GetProperty(AcceptPMSSignInProperty); }
            private set { LoadProperty(AcceptPMSSignInProperty, value); }
        }
        public static readonly PropertyInfo<bool?> AcceptGoogleSignInProperty = RegisterProperty<bool?>(c => c.AcceptGoogleSignIn);
        public bool? AcceptGoogleSignIn
        {
            get { return GetProperty(AcceptGoogleSignInProperty); }
            private set { LoadProperty(AcceptGoogleSignInProperty, value); }
        }
        public static readonly PropertyInfo<string> FaceboolLinkProperty = RegisterProperty<string>(c => c.FacebookLink);
        public string FacebookLink
        {
            get { return GetProperty(FaceboolLinkProperty); }
            private set { LoadProperty(FaceboolLinkProperty, value); }
        }
        public static readonly PropertyInfo<string> InstagramLinkProperty = RegisterProperty<string>(c => c.InstagramLink);
        public string InstagramLink
        {
            get { return GetProperty(InstagramLinkProperty); }
            private set { LoadProperty(InstagramLinkProperty, value); }
        }
        public static readonly PropertyInfo<string> GoogleLinkProperty = RegisterProperty<string>(c => c.GoogleLink);
        public string GoogleLink
        {
            get { return GetProperty(GoogleLinkProperty); }
            private set { LoadProperty(GoogleLinkProperty, value); }
        }
        public static readonly PropertyInfo<string> TwitterLinkProperty = RegisterProperty<string>(c => c.TwitterLink);
        public string TwitterLink
        {
            get { return GetProperty(TwitterLinkProperty); }
            private set { LoadProperty(TwitterLinkProperty, value); }
        }
        public static readonly PropertyInfo<bool?> AcceptTreatmentsProperty = RegisterProperty<bool?>(c => c.AcceptTreatments);
        public bool? AcceptTreatments
        {
            get { return GetProperty(AcceptTreatmentsProperty); }
            private set { LoadProperty(AcceptTreatmentsProperty, value); }
        }
        public static readonly PropertyInfo<bool?> AcceptPackagesProperty = RegisterProperty<bool?>(c => c.AcceptPackages);
        public bool? AcceptPackages
        {
            get { return GetProperty(AcceptPackagesProperty); }
            private set { LoadProperty(AcceptPackagesProperty, value); }
        }
        public static readonly PropertyInfo<bool?> AcceptMembershipsProperty = RegisterProperty<bool?>(c => c.AcceptMemberships);
        public bool? AcceptMemberships
        {
            get { return GetProperty(AcceptMembershipsProperty); }
            private set { LoadProperty(AcceptMembershipsProperty, value); }
        }
        public static readonly PropertyInfo<bool?> AcceptCosmeticsProperty = RegisterProperty<bool?>(c => c.AcceptCosmetics);
        public bool? AcceptCosmetics
        {
            get { return GetProperty(AcceptCosmeticsProperty); }
            private set { LoadProperty(AcceptCosmeticsProperty, value); }
        }
        public static readonly PropertyInfo<bool?> SendConfirmationEmailProperty = RegisterProperty<bool?>(c => c.SendConfirmationEmail);
        public bool? SendConfirmationEmail
        {
            get { return GetProperty(SendConfirmationEmailProperty); }
            private set { LoadProperty(SendConfirmationEmailProperty, value); }
        }
        public static readonly PropertyInfo<int?>ConfirmationEmailTemplateIdProperty = RegisterProperty<int?>(c => c.ConfirmationEmailTemplateId);
        public int? ConfirmationEmailTemplateId
        {
            get { return GetProperty(ConfirmationEmailTemplateIdProperty); }
            private set { LoadProperty(ConfirmationEmailTemplateIdProperty, value); }
        }
        public static readonly PropertyInfo<bool?> SendInfoEmailProperty = RegisterProperty<bool?>(c => c.SendInfoEmail);
        public bool? SendInfoEmail
        {
            get { return GetProperty(SendInfoEmailProperty); }
            private set { LoadProperty(SendInfoEmailProperty, value); }
        }
        public static readonly PropertyInfo<string> SendInfoEmailListProperty = RegisterProperty<string>(c => c.SendInfoEmailList);
        public string SendInfoEmailList
        {
            get { return GetProperty(SendInfoEmailListProperty); }
            private set { LoadProperty(SendInfoEmailListProperty, value); }
        }
        public static readonly PropertyInfo<bool?> ValidPaymentCreditCardProperty = RegisterProperty<bool?>(c => c.ValidPaymentCreditCard);
        public bool? ValidPaymentCreditCard
        {
            get { return GetProperty(ValidPaymentCreditCardProperty); }
            private set { LoadProperty(ValidPaymentCreditCardProperty, value); }
        }
        public static readonly PropertyInfo<int?> CreditCardPaymentTypeIdProperty = RegisterProperty<int?>(c => c.CreditCardPaymentTypeId);
        public int? CreditCardPaymentTypeId
        {
            get { return GetProperty(CreditCardPaymentTypeIdProperty); }
            private set { LoadProperty(CreditCardPaymentTypeIdProperty, value); }
        }
        public static readonly PropertyInfo<bool?> ValidPaymentPayPalProperty = RegisterProperty<bool?>(c => c.ValidPaymentPayPal);
        public bool? ValidPaymentPayPal
        {
            get { return GetProperty(ValidPaymentPayPalProperty); }
            private set { LoadProperty(ValidPaymentPayPalProperty, value); }
        }
        public static readonly PropertyInfo<int?> PayPalPaymentTypeIdProperty = RegisterProperty<int?>(c => c.PayPalPaymentTypeId);
        public int? PayPalPaymentTypeId
        {
            get { return GetProperty(PayPalPaymentTypeIdProperty); }
            private set { LoadProperty(PayPalPaymentTypeIdProperty, value); }
        }
        public static readonly PropertyInfo<bool?> ValidPaymentPayOnDayProperty = RegisterProperty<bool?>(c => c.ValidPaymentPayOnDay);
        public bool? ValidPaymentPayOnDay
        {
            get { return GetProperty(ValidPaymentPayOnDayProperty); }
            private set { LoadProperty(ValidPaymentPayOnDayProperty, value); }
        }
        public static readonly PropertyInfo<bool?> ValidPaymentVivaProperty = RegisterProperty<bool?>(c => c.ValidPaymentViva);
        public bool? ValidPaymentViva
        {
            get { return GetProperty(ValidPaymentVivaProperty); }
            private set { LoadProperty(ValidPaymentVivaProperty, value); }
        }
        public static readonly PropertyInfo<int?> VivaPaymentTypeIdProperty = RegisterProperty<int?>(c => c.VivaPaymentTypeId);
        public int? VivaPaymentTypeId
        {
            get { return GetProperty(VivaPaymentTypeIdProperty); }
            private set { LoadProperty(VivaPaymentTypeIdProperty, value); }
        }
        public static readonly PropertyInfo<bool?> InvoiceIssueProperty = RegisterProperty<bool?>(c => c.InvoiceIssue);
        public bool? InvoiceIssue
        {
            get { return GetProperty(InvoiceIssueProperty); }
            private set { LoadProperty(InvoiceIssueProperty, value); }
        }
        public static readonly PropertyInfo<bool?> CreditCreateProperty = RegisterProperty<bool?>(c => c.CreditCreate);
        public bool? CreditCreate
        {
            get { return GetProperty(CreditCreateProperty); }
            private set { LoadProperty(CreditCreateProperty, value); }
        }
        public static readonly PropertyInfo<bool?> SendInvoiceEmailProperty = RegisterProperty<bool?>(c => c.SendInvoiceEmail);
        public bool? SendInvoiceEmail
        {
            get { return GetProperty(SendInvoiceEmailProperty); }
            private set { LoadProperty(SendInvoiceEmailProperty, value); }
        }
        public static readonly PropertyInfo<int?>InvoiceEmailtemplateIdProperty = RegisterProperty<int?>(c => c.InvoiceEmailTemplateId);
        public int? InvoiceEmailTemplateId
        {
            get { return GetProperty(InvoiceEmailtemplateIdProperty); }
            private set { LoadProperty(InvoiceEmailtemplateIdProperty, value); }
        }
        public static readonly PropertyInfo<bool?> SendEnquiryEmailProperty = RegisterProperty<bool?>(c => c.SendEnquiryEmail);
        public bool? SendEnquiryEmail
        {
            get { return GetProperty(SendEnquiryEmailProperty); }
            private set { LoadProperty(SendEnquiryEmailProperty, value); }
        }
        public static readonly PropertyInfo<int?> EnquiryEmailTemplateIdProperty = RegisterProperty<int?>(c => c.EnquiryEmailTemplateId);
        public int? EnquiryEmailTemplateId
        {
            get { return GetProperty(EnquiryEmailTemplateIdProperty); }
            private set { LoadProperty(EnquiryEmailTemplateIdProperty, value); }
        }
        public static readonly PropertyInfo<string> GoogleAnalyticsGtag1Property = RegisterProperty<string>(c => c.GoogleAnalyticsGtag1);
        public string GoogleAnalyticsGtag1
        {
            get { return GetProperty(GoogleAnalyticsGtag1Property); }
            private set { LoadProperty(GoogleAnalyticsGtag1Property, value); }
        }
        public static readonly PropertyInfo<string> GoogleAnalyticsGtag2Property = RegisterProperty<string>(c => c.GoogleAnalyticsGtag2);
        public string GoogleAnalyticsGtag2
        {
            get { return GetProperty(GoogleAnalyticsGtag2Property); }
            private set { LoadProperty(GoogleAnalyticsGtag2Property, value); }
        }
        public static readonly PropertyInfo<string> PaymentMerchantIdProperty = RegisterProperty<string>(c => c.PaymentMerchantId);
        public string PaymentMerchantId
        {
            get { return GetProperty(PaymentMerchantIdProperty); }
            private set { LoadProperty(PaymentMerchantIdProperty, value); }
        }
        public static readonly PropertyInfo<string> PaymentSecretCodeProperty = RegisterProperty<string>(c => c.PaymentSecretCode);
        public string PaymentSecretCode
        {
            get { return GetProperty(PaymentSecretCodeProperty); }
            private set { LoadProperty(PaymentSecretCodeProperty, value); }
        }
        public static readonly PropertyInfo<string> PaymentConfirmUrlProperty = RegisterProperty<string>(c => c.PaymentConfirmUrl);
        public string PaymentConfirmUrl
        {
            get { return GetProperty(PaymentConfirmUrlProperty); }
            private set { LoadProperty(PaymentConfirmUrlProperty, value); }
        }
        public static readonly PropertyInfo<string> PaymentCancelUrlProperty = RegisterProperty<string>(c => c.PaymentCancelUrl);
        public string PaymentCancelUrl
        {
            get { return GetProperty(PaymentCancelUrlProperty); }
            private set { LoadProperty(PaymentCancelUrlProperty, value); }
        }
        public static readonly PropertyInfo<string> PaymentGatewayUrlProperty = RegisterProperty<string>(c => c.PaymentGatewayUrl);
        public string PaymentGatewayUrl
        {
            get { return GetProperty(PaymentGatewayUrlProperty); }
            private set { LoadProperty(PaymentGatewayUrlProperty, value); }
        }
        public static readonly PropertyInfo<bool?> SendCancellationEmailProperty = RegisterProperty<bool?>(c => c.SendCancellationEmail);
        public bool? SendCancellationEmail
        {
            get { return GetProperty(SendCancellationEmailProperty); }
            private set { LoadProperty(SendCancellationEmailProperty, value); }
        }
        public static readonly PropertyInfo<int?> CancellationEmailTemplateIdProperty = RegisterProperty<int?>(c => c.CancellationEmailTemplateId);
        public int? CancellationEmailTemplateId
        {
            get { return GetProperty(CancellationEmailTemplateIdProperty); }
            private set { LoadProperty(CancellationEmailTemplateIdProperty, value); }
        }
        public static readonly PropertyInfo<bool?> SendCancellationInfoEmailProperty = RegisterProperty<bool?>(c => c.SendCancellationInfoEmail);
        public bool? SendCancellationInfoEmail
        {
            get { return GetProperty(SendCancellationInfoEmailProperty); }
            private set { LoadProperty(SendCancellationInfoEmailProperty, value); }
        }
        public static readonly PropertyInfo<string> CancellationInfoEmailListProperty = RegisterProperty<string>(c => c.CancellationInfoEmailList);
        public string CancellationInfoEmailList
        {
            get { return GetProperty(CancellationInfoEmailListProperty); }
            private set { LoadProperty(CancellationInfoEmailListProperty, value); }
        }
        public static readonly PropertyInfo<bool?> SendRescheduleEmailProperty = RegisterProperty<bool?>(c => c.SendRescheduleEmail);
        public bool? SendRescheduleEmail
        {
            get { return GetProperty(SendRescheduleEmailProperty); }
            private set { LoadProperty(SendRescheduleEmailProperty, value); }
        }
        public static readonly PropertyInfo<int?> RescheduleEmailTemplateIdProperty = RegisterProperty<int?>(c => c.RescheduleEmailTemplateId);
        public int? RescheduleEmailTemplateId
        {
            get { return GetProperty(RescheduleEmailTemplateIdProperty); }
            private set { LoadProperty(RescheduleEmailTemplateIdProperty, value); }
        }
        public static readonly PropertyInfo<bool?> SendRescheduleInfoEmailProperty = RegisterProperty<bool?>(c => c.SendRescheduleInfoEmail);
        public bool? SendRescheduleInfoEmail
        {
            get { return GetProperty(SendRescheduleInfoEmailProperty); }
            private set { LoadProperty(SendRescheduleInfoEmailProperty, value); }
        }
        public static readonly PropertyInfo<string> RescheduleInfoEmailListProperty = RegisterProperty<string>(c => c.RescheduleInfoEmailList);
        public string RescheduleInfoEmailList
        {
            get { return GetProperty(RescheduleInfoEmailListProperty); }
            private set { LoadProperty(RescheduleInfoEmailListProperty, value); }
        }
        public static readonly PropertyInfo<int?> HTMLPagesStylingIdProperty = RegisterProperty<int?>(c => c.HTMLPagesStylingId);
        public int? HTMLPagesStylingId
        {
            get { return GetProperty(HTMLPagesStylingIdProperty); }
            private set { LoadProperty(HTMLPagesStylingIdProperty, value); }
        }
        [Fetch]
        private void Fetch(int id, [Inject] IOnlineSettingDal dal, [Inject]IDataPortal<COnlineSettingRO> dataPortal)
        {
            var item = dal.Fetch(id);
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
        [FetchChild]
        private void FetchChild(DOnlineSettingDto item)
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
    }
}
