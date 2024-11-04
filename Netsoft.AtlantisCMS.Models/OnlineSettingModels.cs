using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Netsoft.AtlantisCMS.Models
{
    public class OnlineSettingModels
    {
        public int PropertyId { get; set; }
        public bool? AcceptCustomerSignIn { get; set; }
        public bool? AcceptPMSSignIn { get; set; }
        public bool? AcceptGoogleSignIn { get; set; }
        public string? FacebookLink { get; set; }
        public string? InstagramLink { get; set; }
        public string? GoogleLink { get; set; }
        public string? TwitterLink { get; set; }
        public bool? AcceptTreatments { get; set; }
        public bool? AcceptPackages { get; set; }
        public bool? AcceptMemberships { get; set; }
        public bool? AcceptCosmetics { get; set; }
        public bool? SendConformationEmail { get; set; }
        public int? ConfirmationEmailTemplateId { get; set; }
        public bool? SendInfoEmail { get; set; }
        public string? SendInfoEmailList { get; set; }
        public bool? ValidPaymentCreditCard { get; set; }
        public int? CreditCardPaymentTypeId { get; set; }
        public bool? ValidPaymentPayPal { get; set; }
        public int? PayPalPaymentTypeId { get; set; }
        public bool? ValidPaymentPayOnDay { get; set; }
        public bool? ValidPaymentViva { get; set; }
        public int? VivaPaymentTypeId { get; set; }
        public bool? InvoiceIssue { get; set; }
        public bool? CreditCreate { get; set; }
        public bool? SendInvoiceEmail { get; set; }
        public int? InvoiceEmaiTemplateId { get; set; }
        public bool? SendEnquiryEmail { get; set; }
        public int? EnquiryEmailTemplateId { get; set; }
        public string? GoogleAnalyticsGtag1 { get; set; }
        public string? GoogleAnalyticsGtag2 { get; set; }
        public string? PaymentMerchantId { get; set; }
        public string? PaymentSecretCode { get; set; }
        public string? PaymentConfirmUrl { get; set; }
        public string? PaymentCancelUrl { get; set; }
        public string? PaymentGatewayUrl { get; set; }
        public bool? SendCancellationEmail { get; set; }
        public int? CancellationEmailTemplateId { get; set; }
        public bool? SendCancellationInfoEmail { get; set; }
        public string? CancellationInfoEmailList { get; set; }
        public bool? RescheduleEmail { get; set; }
        public int? RescheduleEmailTemplateId { get; set; }
        public bool? SendRescheduleInfoEmail { get; set; }
        public string? RescheduleInfoEmailList { get; set; }
        public int? HTMLPagesStylingId { get; set; }
    }
}
